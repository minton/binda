using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Binda.Utilities;

namespace Binda
{
    public class Binder
    {
        public Dictionary<Type, BindaRegistration> registrations;

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
        public void AddRegistration(Type controlType, string accessProperty, Type propertyType)
        {
            registrations.Add(controlType, new BindaRegistration(accessProperty, propertyType));
        }

        public void Bind(object source, Form destination)
        {
            var sourceProperties = source.GetType().GetProperties();
            var formControls = Reflector.GetAllControlsRecursive(destination).ToList();
            foreach (var control in formControls)
            {
                var sourceProperty = sourceProperties.FirstOrDefault(x => x.Name.ToUpper() == control.Name.ToUpper());
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