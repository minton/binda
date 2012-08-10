using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Binda.Utilities
{
    public class Reflector
    {
        public static object GetPropertyValue(object obj, string name)
        {
            var properties = obj.GetType().GetProperties();
            var propertyInfo = properties.FirstOrDefault(x => x.Name.ToUpperInvariant() == name.ToUpperInvariant());
            return propertyInfo == null ? null : propertyInfo.GetValue(obj, null);
        }
        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            var properties = obj.GetType().GetProperties();
            var propertyInfo = properties.FirstOrDefault(x => x.Name.ToUpperInvariant() == propertyName.ToUpperInvariant());
            if (propertyInfo == null)
                return;
            propertyInfo.SetValue(obj, value, null);
        }
        public static IEnumerable<Control> GetAllControlsRecursive(Control parent)
        {
            var results = new List<Control>();
            foreach (Control control in parent.Controls)
            {
                results.Add(control);
                if (control.Controls.Count > 0)
                    results.AddRange(GetAllControlsRecursive(control));
            }
            return results;
        }
    }
}