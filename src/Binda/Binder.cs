using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Binda.Utilities;

namespace Binda
{
    public class Binder
    {
        private readonly IDictionary<Type, BindaStrategy> _typeStrategies;
        private readonly IDictionary<Control, BindaStrategy> _controlStrategies;

        readonly List<ControlPrefix> _controlPrefixes;
        ControlPrefix _controlPrefix;

        public Binder()
        {
            _typeStrategies =
                new Dictionary<Type, BindaStrategy>
                {
                    {typeof (TextBox), new DefaultBindaStrategy("Text")},
                    {typeof (CheckBox), new DefaultBindaStrategy("Checked")},
                    {typeof (RadioButton), new DefaultBindaStrategy("Checked")},
                    {typeof (DateTimePicker), new DefaultBindaStrategy("Value")},
                    {typeof (NumericUpDown), new DefaultBindaStrategy("Value")},
                    {typeof (ComboBox), new ListControlBindaStrategy()},
                    {typeof (TreeView), new TreeViewBindaStrategy()}
                };
            _controlStrategies = new Dictionary<Control, BindaStrategy>();
        }

        /// <summary>
        /// Add a new Default Binda Strategy for a control type
        /// </summary>
        /// <param name="controlType"></param>
        /// <param name="propertyName"></param>
        public void AddRegistration(Type controlType, string propertyName)
        {
            AddRegistration(controlType, new DefaultBindaStrategy(propertyName));
        }

        /// <summary>
        /// Add a Custom Binda Strategy for a control type.
        /// </summary>
        /// <param name="controlType"></param>
        /// <param name="strategy"></param>
        public void AddRegistration(Type controlType, BindaStrategy strategy)
        {
            _typeStrategies[controlType] = strategy;
        }

        /// <summary>
        /// Add a Custom Binda Strategy for specific controls
        /// </summary>
        /// <param name="strategy"></param>
        /// <param name="controls"></param>
        public void AddRegistration(BindaStrategy strategy, params Control[] controls)
        {
            Array.ForEach(controls, x => _controlStrategies[x] = strategy);
        }

        public void AddControlPrefix(ControlPrefix controlPrefix)
        {
            _controlPrefix = controlPrefix;
        }

        /// <summary>
        /// Binds an object to a Control via property names including optional aliases.
        /// </summary>
        /// <param name="source">Any POCO.</param>
        /// <param name="destination">A Windows Forms Control</param>
        /// <param name="aliases">A list of BindaAliases (optional).</param>
        public void Bind(object source, Control destination, IList<BindaAlias> aliases = null)
        {
            InternalBindToControl(source, destination, aliases);
        }

        /// <summary>
        /// Binds a Control to an object via property names including optional aliases.
        /// </summary>
        /// <param name="source">A Windows Forms Control.</param>
        /// <param name="destination">Any POCO.</param>
        /// <param name="aliases">A list of BindaAliases (optional).</param>
        public void Bind(Control source, object destination, IList<BindaAlias> aliases = null)
        {
            InternalBindToObject(source, destination, aliases);
        }

        private void InternalBindToControl(object source, Control destination, IList<BindaAlias> aliases)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (destination == null) throw new ArgumentNullException("destination");
            aliases = aliases ?? Enumerable.Empty<BindaAlias>().ToList();

            var sourceProperties = source.GetType().GetProperties();
            var controls = GetControlsFor(destination);
            foreach (var control in controls)
            {
                var controlName = _controlPrefix == null ? control.Name : _controlPrefix.RemovePrefix(control.Name);
                var alias = aliases.FirstOrDefault(x => string.Equals(x.DestinationAlias, controlName, StringComparison.OrdinalIgnoreCase));
                var finalControlName = alias == null ? controlName : alias.Property;
                var sourceProperty = sourceProperties.FirstOrDefault(x => string.Equals(x.Name, finalControlName, StringComparison.OrdinalIgnoreCase));
                if (sourceProperty == null) continue;
                var strategy = GetStrategyFor(control);
                if (source.GetType().GetInterfaces().Any(x => x == typeof(INotifyPropertyChanged)))
                    strategy.BindControl(control, source, sourceProperty.Name);
                else
                    strategy.SetControlValue(control, source, sourceProperty.Name);
            }
        }

        private void InternalBindToObject(Control source, object destination, IList<BindaAlias> aliases)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (destination == null) throw new ArgumentNullException("destination");
            aliases = aliases ?? Enumerable.Empty<BindaAlias>().ToList();

            var controls = GetControlsFor(source);
            var properties = destination.GetType().GetProperties().Where(property => property.CanWrite);
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var alias = aliases.FirstOrDefault(x => string.Equals(x.Property, property.Name, StringComparison.OrdinalIgnoreCase));
                if (alias != null)
                    propertyName = alias.DestinationAlias;

                var control = controls.FirstOrDefault(x => string.Equals(_controlPrefix == null ? x.Name : _controlPrefix.RemovePrefix(x.Name), propertyName, StringComparison.OrdinalIgnoreCase));
                if (control == null) continue;

                var strategy = GetStrategyFor(control);
                var value = strategy.GetControlValue(control);
                property.SetValue(destination, value, null);
            }
        }

        private BindaStrategy GetStrategyFor(Control control)
        {
            return
                _controlStrategies.ContainsKey(control)
                    ? _controlStrategies[control]
                    : _typeStrategies[control.GetType()];
        }

        private IList<Control> GetControlsFor(Control control)
        {
            return
                control
                    .GetAllControlsRecursive<Control>()
                    .Where(x =>
                        _controlStrategies.ContainsKey(x) ||
                        _typeStrategies.ContainsKey(x.GetType()))
                    .ToList();
        }
    }
}