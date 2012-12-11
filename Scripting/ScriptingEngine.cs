using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Windows;

namespace Scripting
{
    public class ScriptingEngine
    {
        private ScriptEngine scriptEngine;
        private ScriptScope scriptScope;
        
        private ScriptSource scriptSource;
        public ScriptSource ScriptSource
        {
            get { return scriptSource; }
            set { scriptSource = value; }
        }
        
        private ScriptOutputWindow outputWindow;
        public ScriptOutputWindow OutputWindow
        {
            get { return outputWindow; }
            set { outputWindow = value; }
        }

        public ScriptingEngine()
        {
            scriptEngine = Python.CreateEngine();
            scriptScope = scriptEngine.CreateScope();
            
            CreateOutputWindow();
            ConfigureScriptEngine();
        }

        public void SetSource(string sourceCode)
        {
            string source = sourceCode.Trim();
            ScriptSource = scriptEngine.CreateScriptSourceFromString(source);
        }

        public void Execute()
        {
            OutputWindow.Show();

            try
            {
                ScriptSource.Execute(scriptScope);
            }
            catch (Exception e)
            {
                Exception(e);
            }
        }

        public void Exception(Exception e)
        {
            OutputWindow.edOutput.Text += "\nError: ";
            OutputWindow.edOutput.Text += e.Message + "\n";
        }

        private void CreateOutputWindow()
        {
            OutputWindow = new ScriptOutputWindow();
            OutputWindow.btEnterCommand.Click += new RoutedEventHandler(RunCommand);
        }

        private void ConfigureScriptEngine()
        {
            MemoryStream ms = new MemoryStream();

            EventRaisingStreamWriter outputWriter = new EventRaisingStreamWriter(ms);
            outputWriter.StringWritten += new EventHandler<MyEvtArgs<string>>(sWr_StringWritten);

            scriptEngine.Runtime.IO.SetOutput(ms, outputWriter);
        }

        private void sWr_StringWritten(object sender, MyEvtArgs<string> e)
        {
            OutputWindow.edOutput.Text += e.Value;
        }

        private void RunCommand(object sender, RoutedEventArgs e)
        {
            SetSource(OutputWindow.edInput.Text);
            OutputWindow.edOutput.Text += ScriptSource.Execute(scriptScope) + "\n";
        }
    }
}
