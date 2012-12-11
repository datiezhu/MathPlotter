using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MathPlotter.Support
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        public enum Buttons
        {
            Ok, YesNo, OkCancel, YesNoCancel
        }

        public DialogBox()
        {
            InitializeComponent();
        }

        public DialogBox(string title, string message, Buttons buttons)
        {
            InitializeComponent();
            this.MessageName.Text = title;
            this.MessageText.Text = message;
            
            switch(buttons)
            {
                case Buttons.Ok:
                    btOK.Visibility = Visibility.Visible;
                    btNo.Visibility = Visibility.Collapsed;
                    btYes.Visibility = Visibility.Collapsed;
                    btCancel.Visibility = Visibility.Collapsed;
                    break;
                case Buttons.OkCancel:
                    btOK.Visibility = Visibility.Visible;
                    btNo.Visibility = Visibility.Collapsed;
                    btYes.Visibility = Visibility.Collapsed;
                    btCancel.Visibility = Visibility.Visible;
                    break;
                case Buttons.YesNo:
                    btOK.Visibility = Visibility.Collapsed;
                    btNo.Visibility = Visibility.Visible;
                    btYes.Visibility = Visibility.Visible;
                    btCancel.Visibility = Visibility.Collapsed;
                    break;
                case Buttons.YesNoCancel:
                    btOK.Visibility = Visibility.Collapsed;
                    btNo.Visibility = Visibility.Visible;
                    btYes.Visibility = Visibility.Visible;
                    btCancel.Visibility = Visibility.Visible;
                    break;
            }
            this.MouseLeftButtonDown += (o, e) => DragMove();
        }

        private void btYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }

        private void btNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        /* EXAMPLE OF USE:
         * 
            DialogBox db = new DialogBox("Test", "Wiadomość \n \n \n \n test", MathPlotter.Support.DialogBox.Buttons.OkCancel);
            db.ShowDialog();
            if (db.DialogResult == false)
            {
                this.Close();
            }
         * 
        */
    
    }
}
