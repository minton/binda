using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Binda.Utilities;
using Inflector;

namespace Binda
{
    public class Binder
    {
        readonly Dictionary<Type, BindaRegistration> _registrations;

        public Binder()
        {
            _registrations = new Dictionary<Type, BindaRegistration>
                                {
                                    {typeof (TextBox), new BindaRegistration("Text", typeof (string))},
                                    {typeof(CheckBox), new BindaRegistration("Checked", typeof(bool))},
                                    {typeof(RadioButton), new BindaRegistration("Checked", typeof(bool))},
                                    {typeof(DateTimePicker), new BindaRegistration("Value", typeof(DateTime))},
									{typeof(ComboBox), new BindaRegistration("SelectedItem", typeof(object))}
                                };
        }
        /// <summary>
        /// Add a new BindaRegistration to the Binder.
        /// </summary>
        /// <param name="control">The type of the custom control.</param>
        /// <param name="property">The property used to get/set the value on the control.</param>
        /// <param name="type">The data type of the property.</param>
        public void AddRegistration(Type control, string property, Type type)
        {
            _registrations.Add(control, new BindaRegistration(property, type));
        }

        /// <summary>
        /// Binds an object to a Form via property names.
        /// </summary>
        /// <param name="source">Any POCO.</param>
        /// <param name="destination">A Windows Form</param>
        public void Bind(object source, Form destination)
        {
            Bind(source, destination, Enumerable.Empty<BindaAlias>().ToList());
        }
        /// <summary>
        /// Binds an object to a Form via property names including aliases.
        /// </summary>
        /// <param name="source">Any POCO.</param>
        /// <param name="destination">A Windows Form.</param>
        /// <param name="aliases">A list of BindaAlias.</param>
        public void Bind(object source, Form destination, List<BindaAlias> aliases)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (destination == null) throw new ArgumentNullException("destination");
            var sourceProperties = source.GetType().GetProperties();
            var controls = destination.GetAllControlsRecursive<Control>().ToList();
            foreach (var control in controls)
            {
                var controlPropertyName = control.Name;
                var alias = aliases.FirstOrDefault(x => x.DestinationAlias.ToUpper() == control.Name.ToUpper());

                if (alias != null)
                    controlPropertyName = alias.Property;

                var sourceProperty = sourceProperties.FirstOrDefault(x => x.Name.ToUpper() == controlPropertyName.ToUpper());
                if (sourceProperty == null) continue;

                var listControl = control as ListControl;
                var collectionProperty = sourceProperties.FirstOrDefault(x => x.Name.ToUpper() == controlPropertyName.Pluralize().ToUpper());
                if (listControl != null && collectionProperty != null && typeof(IList).IsAssignableFrom(collectionProperty.PropertyType))
                {
                    var collection = (IList)collectionProperty.GetValue(source, null);
                    var value = sourceProperty.GetValue(source, null);
                    listControl.DataSource = collection;
                    listControl.SelectedIndex = collection.IndexOf(value);
                }
                else
                {
                    BindaRegistration registration;
                    if (!_registrations.TryGetValue(control.GetType(), out registration)) continue;
                    if (!registration.PropertyType.IsAssignableFrom(sourceProperty.PropertyType)) continue;
                    var value = sourceProperty.GetValue(source, null);
                    control.SetPropertyValue(registration.AccessProperty, value);
                }
            }
        }
        /// <summary>
        /// Binds a Form to an object via property names.
        /// </summary>
        /// <param name="source">A Windows Form.</param>
        /// <param name="destination">Any POCO.</param>
        public void Bind(Form source, object destination)
        {
            Bind(source, destination, Enumerable.Empty<BindaAlias>().ToList());
        }
        /// <summary>
        /// Binds a Form to an object via property names including aliases.
        /// </summary>
        /// <param name="source">A Windows Form.</param>
        /// <param name="destination">Any POCO.</param>
        /// <param name="aliases">A list of BindaAlias.</param>
        public void Bind(Form source, object destination, List<BindaAlias> aliases)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (destination == null) throw new ArgumentNullException("destination");
            var properties = destination.GetType().GetProperties().Where(property => property.CanWrite);
            var controls = source.GetAllControlsRecursive<Control>().ToList();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var alias = aliases.FirstOrDefault(x => x.Property.ToUpper() == property.Name.ToUpper());
                if (alias != null)
                    propertyName = alias.DestinationAlias;

                var control = controls.FirstOrDefault(x => x.Name.ToUpper() == propertyName.ToUpper());
                if (control == null) continue;

                BindaRegistration registration;
                if (!_registrations.TryGetValue(control.GetType(), out registration)) continue;
                if (!registration.PropertyType.IsAssignableFrom(property.PropertyType)) continue;

                var value = control.GetPropertyValue(registration.AccessProperty);
                property.SetValue(destination, value, null);
            }
        }
    }
}