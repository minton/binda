using System.Collections;
using System.Windows.Forms;
using Inflector;

namespace Binda
{
    public class ListControlBindaStrategy : BindaStrategy
    {
        public override void BindControl(Control control, object source, string propertyName)
        {
            SetControlValue(control, source, propertyName);
            control.DataBindings.Add("SelectedValue", source,
                                     propertyName, true,
                                     DataSourceUpdateMode.OnPropertyChanged);

        }

        public override void SetControlValue(Control control, object source, string propertyName)
        {
            var listControl = control as ListControl;
            if (listControl == null) return;
            var sourceProperty = source.GetType().GetProperty(propertyName);
            if (sourceProperty == null) return;
            var value = sourceProperty.GetValue(source, null);
            var collection = GetCollection(source, propertyName, value);
            listControl.DataSource = collection;
            listControl.SelectedIndex = collection.IndexOf(value);
        }

        protected IList GetCollection(object source, string propertyName, object value)
        {
            var collectionPropertyName = propertyName.Pluralize();
            var collectionProperty = source.GetType().GetProperty(collectionPropertyName);
            var collection = collectionProperty == null ? new[] {value} : (IList) collectionProperty.GetValue(source, null);
            return collection;
        }

        public override object GetControlValue(Control control)
        {
            var listControl = control as ListControl;
            if (listControl == null) return null;
            var list = ((IList) listControl.DataSource);
            if (listControl.SelectedIndex >= list.Count || listControl.SelectedIndex < 0) return null;
            return list[listControl.SelectedIndex];
        }
    }
}