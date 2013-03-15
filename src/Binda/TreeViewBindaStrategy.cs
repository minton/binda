using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Binda
{
    public class TreeViewBindaStrategy : BindaStrategy
    {
        public override void BindControl(Control control, object source, string propertyName){}

        public override void SetControlValue(Control control, object source, string propertyName)
        {
            var treeView = control as TreeView;
            if (treeView == null) return;
            var values = GetChildItems(source, propertyName);
            if (values == null) return;
            treeView.Nodes.AddRange(GetChildNodes(values, propertyName));
        }

        TreeNode[] GetChildNodes(IEnumerable values, string propertyName)
        {
            var nodes = new List<TreeNode>();
            foreach (var item in values)
            {
                var node = new TreeNode(item.ToString()) { Tag = item };
                var childValues = GetChildItems(item, propertyName);
                var childNodes = GetChildNodes(childValues, propertyName);
                if (childNodes.Any())
                    node.Nodes.AddRange(childNodes);

                nodes.Add(node);
            }
            return nodes.ToArray();
        }
        
        IEnumerable GetChildItems(object source, string propertyName)
        {
            var sourceProperty = source.GetType().GetProperty(propertyName);
            if (sourceProperty == null) return Enumerable.Empty<object>();
            var values = sourceProperty.GetValue(source, null) as IEnumerable;
            return values;
        }

        public override object GetControlValue(Control control)
        {
            var treeView = control as TreeView;
            if (treeView == null) return null;

            var firstNode = treeView.Nodes.Cast<TreeNode>().FirstOrDefault();
            if (firstNode == null) return null;

            var list = (IList)Activator.CreateInstance(typeof (List<>).MakeGenericType(firstNode.Tag.GetType()));

            foreach (TreeNode node in treeView.Nodes)
            {
                var item = node.Tag;
                list.Add(item);
            }
            return list;
        }
    }
}