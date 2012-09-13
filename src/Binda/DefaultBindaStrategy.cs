using System.Windows.Forms;
using Binda.Utilities;

namespace Binda
{
    public class DefaultBindaStrategy : BindaStrategy
    {
        public DefaultBindaStrategy(string controlPropertyName)
        {
            Set = SetControlValue;
            Get = GetControlValue;
            Bind = BindControl;
            ControlPropertyName = controlPropertyName;
        }

        public string ControlPropertyName { get; private set; }

        void BindControl(Control control, object dataSource, string dataMember)
        {
            control.DataBindings.Add(ControlPropertyName, dataSource, dataMember, true,
                                     DataSourceUpdateMode.OnPropertyChanged);
        }

        void SetControlValue(Control control, object value)
        {
            control.SetPropertyValue(ControlPropertyName, value);
        }

        object GetControlValue(Control control)
        {
            return control.GetPropertyValue(ControlPropertyName);
        }
    }
}