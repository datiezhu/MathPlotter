using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MathPlotter.Windows
{
    public static class ModuleList
    {
        public struct Module
        {
            public string Name;
            public Page Page;

            public Module(string name, Page page)
            {
                this.Name = name;
                this.Page = page;
            }
        }

        private static List<Module> items;
        public static IEnumerable<Module> Items
        {
            get
            {
                return items;
            }
        }

        static ModuleList()
        {
            items = new List<Module>();
            items.Add(new Module("Okno testowe", new Test()));
        }
    }
}
