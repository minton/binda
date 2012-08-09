using System;
using System.Windows.Forms;

namespace BindaTests.NeededObjects
{
    public partial class MySampleForm : Form
    {
        public MySampleForm()
        {
            InitializeComponent();
        }

        public string Title { get { return txtTitle.Text; } set { txtTitle.Text = value; } }
        public string Author { get { return txtAuthor.Text; } set { txtAuthor.Text = value; } }
        public string Body { get { return txtBody.Text; } set { txtBody.Text = value; } }
        public DateTime Date { get { return dtpDate.Value; } set { dtpDate.Value = value; } }
    }
}
