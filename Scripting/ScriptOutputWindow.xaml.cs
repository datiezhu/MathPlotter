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
using System.Windows.Automation.Peers;


using System.Windows.Automation.Provider;namespace Scripting
{
    /// <summary>
    /// Interaction logic for ScriptOutputWindow.xaml
    /// </summary>
    public partial class ScriptOutputWindow : Window
    {
        public ScriptOutputWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (o, e) => DragMove();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void edInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonAutomationPeer peer = new ButtonAutomationPeer(btEnterCommand);
                IInvokeProvider invokeProv =
                  peer.GetPattern(PatternInterface.Invoke)
                  as IInvokeProvider;
                invokeProv.Invoke();
            }
        }
    }
}
