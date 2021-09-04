using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContextMenuDemo.Data
{
    public enum Command
    {
        Update, Delete
    }
    public class ContextMenuItem
    {
        public string Text { get; set; }
        public Command Command { get; set; }
        public string Icon { get; set; }
        public bool Separator { get; set; }
        public List<ContextMenuItem> Items { get; set; }
    }
}
