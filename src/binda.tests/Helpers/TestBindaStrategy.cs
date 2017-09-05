using System.Windows.Forms;
using Binda;

namespace BindaTests.Helpers
{
    public class TestBindaStrategy : BindaStrategy
    {
        public bool WasBound = false;
        public override void BindControl(Control control, object source, string propertyName)
        {
            WasBound = true;
        }

        public bool WasSet = false;
        public override void SetControlValue(Control control, object source, string propertyName)
        {
            WasSet = true;
        }

        public object GetValue { get; set; }
        public override object GetControlValue(Control control)
        {
            return GetValue;
        }
    }
}