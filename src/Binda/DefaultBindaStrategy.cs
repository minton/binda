using System.Windows.Forms;
using Binda.Utilities;

namespace Binda
{
    public class DefaultBindaStrategy : BindaStrategy
    {
        public DefaultBindaStrategy(string controlPropertyName)
        {
            ControlPropertyName = controlPropertyName;
        }

        public string ControlPropertyName { get; private set; }

        public override void BindControl(Control control, object source, string propertyName)
        {
            control.DataBindings.Add(ControlPropertyName, source, propertyName, true,
                                     DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void SetControlValue(Control control, object source, string propertyName)
        {
            var sourceProperty = source.GetType().GetProperty(propertyName);
            if (sourceProperty == null) return;
            var value = sourceProperty.GetValue(source, null);
            control.SetPropertyValue(ControlPropertyName, value);
        }

        public override object GetControlValue(Control control)
        {
            return control.GetPropertyValue(ControlPropertyName);
        }
    }
}