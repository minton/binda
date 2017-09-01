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

            listControl.DataSource = null;
            listControl.DataSource = GetCollection(source, propertyName, value);
            // DataSource == null; will reset the Display/Value Members...
            listControl.DisplayMember = "Value";
            listControl.ValueMember = "Key";

            // NullValueException if we set SelectedValue to null. 
            // By default it will be null since we reset the Datasource
            if (value != null) { listControl.SelectedValue = value; }
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