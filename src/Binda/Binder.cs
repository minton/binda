using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Binda.Utilities;

namespace Binda
{
    public class Binder
    {
        readonly Dictionary<Type, BindaRegistration> registrations;

        public Binder()
        {
            registrations = new Dictionary<Type, BindaRegistration>
                                {
                                    {typeof (TextBox), new BindaRegistration("Text", typeof (string))},
                                    {typeof(CheckBox), new BindaRegistration("Checked", typeof(bool))},
                                    {typeof(RadioButton), new BindaRegistration("Checked", typeof(bool))},
                                    {typeof(DateTimePicker), new BindaRegistration("Value", typeof(DateTime))}
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
            registrations.Add(control, new BindaRegistration(property, type));
        }

        /// <summary>
        /// Binds an object to a Form via property names.
        /// </summary>
        /// <param name="source">The object to be bound to the form</param>
        /// <param name="destination">A Windows Form</param>
        public void Bind(object source, Form destination)
        {
            Bind(source, destination, Enumerable.Empty<BindaAlias>().ToList());
        }
        /// <summary>
        /// Binds an object to a Form via property names including aliases.
        /// </summary>
        /// <param name="source">The object to be bound to the form.</param>
        /// <param name="destination">A Windows Form.</param>
        /// <param name="aliases">A list of BindaAlias.</param>
        public void Bind(object source, Form destination, List<BindaAlias> aliases)
        {
            var sourceProperties = source.GetType().GetProperties();
            var formControls = Reflector.GetAllControlsRecursive(destination).ToList();
            foreach (var control in formControls)
            {
                var controlPropertyName = control.Name;
                var alias = aliases.FirstOrDefault(x => x.DestinationAlias.ToUpper() == control.Name.ToUpper());

                if (alias != null)
                    controlPropertyName = alias.Property;

                var sourceProperty = sourceProperties.FirstOrDefault(x => x.Name.ToUpper() == controlPropertyName.ToUpper());
                if (sourceProperty == null) continue;

                BindaRegistration registration;
                if (!registrations.TryGetValue(control.GetType(), out registration)) continue;
                
                if (!registration.PropertyType.IsAssignableFrom(sourceProperty.PropertyType)) continue;
                var value = sourceProperty.GetValue(source, null);

                Reflector.SetPropertyValue(control, registration.AccessProperty, value);
            }
        }
    }
}