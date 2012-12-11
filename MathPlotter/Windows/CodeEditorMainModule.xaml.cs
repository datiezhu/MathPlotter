using System;
using System.Windows.Controls;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using MathPlotter.Support;
using Microsoft.Win32;
using MathPlotter.Resources;
using Scripting;
using System.Windows;

namespace MathPlotter.Windows
{
    /// <summary>
    /// Interaction logic for CodeEditorMainModule.xaml
    /// </summary>
    public partial class CodeEditorMainModule : Page
    {
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
            }
        }

        private ScriptingEngine scriptEngine;

        public CodeEditorMainModule()
        {
            InitializeComponent();
            AddPythonCodeFormater();
            scriptEngine = new ScriptingEngine();
        }

        public void AddPythonCodeFormater()
        {
            try
            {
                this.edScript.SyntaxHighlighting =
                     HighlightingLoader.Load(new XmlTextReader("Resources\\Python.xshd"),
                        HighlightingManager.Instance);
            }
            catch (Exception e)
            {
                DialogBox msg = new DialogBox("Error!", e.Message, DialogBox.Buttons.Ok);
                msg.ShowDialog();
            }
        }

        public void SaveFile()
        {
            if (FileName != null)
            { 
                edScript.Save(FileName);
            }
            else
            {
                SaveAsFile();
            }
        }

        public void SaveAsFile()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = ConstString.ScriptEditorFileNameFilter;
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == true)
            {
                FileName = saveDialog.FileName;
                edScript.Save(FileName);
            }
        }

        public void OpenFile()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = ConstString.ScriptEditorFileNameFilter;
            openDialog.RestoreDirectory = true;
            if (openDialog.ShowDialog() == true)
            {
                FileName = openDialog.FileName;
                edScript.Load(FileName);
            }
        }

        public void NewFile()
        {
            if (edScript.Text.Length > 0)
            {
                DialogBox dlg = new DialogBox("New file...", "Do you want to save existing file?", DialogBox.Buttons.YesNo);
                if (dlg.ShowDialog() == true)
                {
                    SaveFile();
                    
                }
                edScript.Text = "";
            }
        }

        public void TestScript()
        {
            SaveFile();
            if (fileName != null)
            {
                /*
                string strCmdText;
                strCmdText = this.fileName;
                System.Diagnostics.Process.Start("python.exe", strCmdText);
               */
                scriptEngine.SetSource(edScript.Text);
                scriptEngine.Execute();
            }
        }

        private void btOpen_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFile();
        }

        private void btSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveFile();
        }

        private void btSaveAs_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveAsFile();
        }

        private void btNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NewFile();
        }

        private void btTest_Click(object sender, RoutedEventArgs e)
        {
            TestScript();
        }
    }
}
