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
            public string Group;
            public Page Page;

            public Module(string name, string group, Page page)
            {
                this.Name = name;
                this.Group = group;
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
            items.Add(new Module("Start", "Main Menu", new StartPage()));
            items.Add(new Module("Script Editor", "Editors", new CodeEditorMainModule()));
            items.Add(new Module("Plotter", "Designers", new PlotterMainModule()));
        }
    }
}
