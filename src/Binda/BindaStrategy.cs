using System.Windows.Forms;

namespace Binda
{
    public abstract class BindaStrategy
    {
        protected string ControlPrefix;
        public abstract void BindControl(Control control, object source, string propertyName);
        public abstract void SetControlValue(Control control, object source, string propertyName);
        public abstract object GetControlValue(Control control);
    }
}