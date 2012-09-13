using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Binda.Utilities
{
    public static class Reflector
    {
        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }

        public static object GetPropertyValue(this object obj, string name)
        {
            var properties = obj.GetType().GetProperties();
            var propertyInfo = properties.FirstOrDefault(x => x.Name.ToUpperInvariant() == name.ToUpperInvariant());
            return propertyInfo == null ? null : propertyInfo.GetValue(obj, null);
        }
        public static void SetPropertyValue(this object obj, string propertyName, object value)
        {
            var properties = obj.GetType().GetProperties();
            var propertyInfo = properties.FirstOrDefault(x => x.Name.ToUpperInvariant() == propertyName.ToUpperInvariant());
            if (propertyInfo == null)
                return;
            propertyInfo.SetValue(obj, value, null);
        }
        public static IEnumerable<TControl> GetAllControlsRecursive<TControl>(this Control parent) where TControl : Control
        {
            foreach (var control in parent.Controls.OfType<TControl>())
            {
                yield return control;
                foreach (var child in control.GetAllControlsRecursive<TControl>())
                    yield return child;
            }
        }
    }
}