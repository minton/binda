using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BindaTests.NeededObjects;

namespace BindaTests
{
    public static class Extensions
    {
        public static List<TreeNode> GetAllNodesRecursive(this TreeView treeView)
        {
            return GetAllNodesRecursive(treeView.Nodes);
        }
        
        static List<TreeNode> GetAllNodesRecursive(IEnumerable nodes)
        {
            var allNodes = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                allNodes.Add(node);
                if (node.Nodes.Count != 0)
                    allNodes.AddRange(GetAllNodesRecursive(node.Nodes));
            }
            return allNodes;
        } 
        
        public static TreeNode GetNodeCommentByAuthor(this IEnumerable<TreeNode> nodes, string author)
        {
            return nodes.Single(x => (x.Tag as Comment).Author == author);
        }

        public static Comment GetCommentByAuthor(this IEnumerable<Comment> comments, string author)
        {
            return comments.Single(x => x.Author == author);
        }
    }
}