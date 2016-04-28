using System.Reflection;
using System.Windows.Forms;

namespace Binda
{
    public class KeyValueListStrategy : ListControlBindaStrategy
    {
        public override void SetControlValue(Control control, object source, string propertyName)
        {
            ListControl listControl;
            PropertyInfo valueProperty;
            if ((listControl = control as ListControl) == null ||
                (valueProperty = source.GetType().GetProperty(propertyName)) == null)
            {
                return;
            }
            var value = valueProperty.GetValue(source, null);

            // DataSource == null; will reset the Display/Value Members...
            listControl.DataSource = GetCollection(source, propertyName, value);
            listControl.DisplayMember = "Value";
            listControl.ValueMember = "Key";

            listControl.SelectedValue = value;
        }

        public override object GetControlValue(Control control)
        {
            return
                control is ListControl
                    ? ((ListControl) control).SelectedValue
                    : null;
        }
    }
}