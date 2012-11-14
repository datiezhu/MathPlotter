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
            InitializeComponent();
            this.MouseLeftButtonDown += (o, e) => DragMove();
            var pages = ModuleList.Items;
            frmFrame.Navigate(pages.FirstOrDefault(x => x.Name == "Start").Page);
            GenerateMenuItems();
        }
        
        private void GenerateMenuItems()
        {
            foreach (MathPlotter.Windows.ModuleList.Module module in ModuleList.Items)
            {
                lbMenu.Items.Add(module.Name);
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

        private void lbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.frmFrame.Navigate(ModuleList.Items.SingleOrDefault(p => p.Name == (string)lbMenu.SelectedItem).Page);
        }
    }
}
