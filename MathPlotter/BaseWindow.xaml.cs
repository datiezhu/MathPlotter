using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using MathPlotter.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace MathPlotter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        public BaseWindow()
        {
            items = new ObservableCollection<ModuleList.Module>();

            InitializeComponent();
            this.MouseLeftButtonDown += (o, e) => DragMove();
            var pages = ModuleList.Items;
            frmFrame.Navigate(pages.FirstOrDefault(x => x.Name == "Start").Page);
            GenerateMenuItems();
        }

        public ObservableCollection<MathPlotter.Windows.ModuleList.Module> items { get; set; }

        private void GenerateMenuItems()
        {
            foreach (MathPlotter.Windows.ModuleList.Module module in ModuleList.Items)
            {
                listBox1.Items.Add(module.Name);
            }
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
