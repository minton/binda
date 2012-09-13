using System;
using System.Windows.Forms;

namespace Binda
{
    public abstract class BindaStrategy
    {
        public Action<Control, object, string> Set { get; protected set; }
        public Func<Control, object> Get { get; protected set; }
        public Action<Control, object, string> Bind { get; protected set; } 
    }
}