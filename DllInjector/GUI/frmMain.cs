// Dll Injector
// Copyright (C) 2013 Filip Traikov
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace DllInjector.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Injector.OnDllInjectErrorEventHandler += new Injector.OnDllInjectErrorDelegate(Injector_OnDllInjectErrorEventHandler);
        }

        OpenFileDialog fileDialog = new OpenFileDialog()
        {
            Filter = "*.dll|*.dll"
        };
        bool cancelApplicationExitEvent = true;

        void Injector_OnDllInjectErrorEventHandler(object sender, InjectorExceptionEventArgs e)
        {
            if (e.Type == InjectorExceptionType.Notification)
            {
                AddLogMessage(e.Message, Color.Orange);
            }
            else
            {
                // TODO: Log fatal exceptions to file.
            } 
        }

        void AddLogMessage(string message, Color color)
        {
            string timestamp = string.Format("[{0}] ", DateTime.Now.ToLongTimeString());
            rtxtbLog.AppendText(timestamp);
            rtxtbLog.SelectionColor = color;
            rtxtbLog.AppendText(message + Environment.NewLine);
            rtxtbLog.ScrollToCaret();
        }

        private void cboSystemProcesses_DropDown(object sender, EventArgs e)
        {
            cboSystemProcesses.Items.Clear();
            Process[] processList = Process.GetProcesses();
            foreach (var p in processList)
            {
                cboSystemProcesses.Items.Add(p.ProcessName);
            }
            cboSystemProcesses.Sorted = true;
        }

        private void btnSelectDll_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtbDllPath.Text = fileDialog.FileName;
            }
        }

        private Process GetSelectedProcess()
        {
            Process[] processes = Process.GetProcessesByName(cboSystemProcesses.Text);
            if (processes.Length == 0)
            {
                AddLogMessage("Process not found.", Color.Red);
                return null;
            }
            return processes[0];
        }

        private void btnInjectDll_Click(object sender, EventArgs e)
        {
            Process selectedProcess = GetSelectedProcess();
            if (selectedProcess == null)
                return;

            if (String.IsNullOrEmpty(txtbDllPath.Text))
            {
                AddLogMessage("Dll not selected or invalid dll path.", Color.Red);
                return;
            }
            else if (!System.IO.File.Exists(txtbDllPath.Text))
            {
                AddLogMessage("\'DLL to Inject\' not found !", Color.Red);
                return;
            }

            bool injected = Injector.InjectDll(selectedProcess, txtbDllPath.Text);
            if (injected)
            {
                AddLogMessage("Injection successful.", Color.Green);
            }
            else
            {
                AddLogMessage("Injection failed.", Color.Red);
            }
        }

        private void btnShowProcessLoadedModules_Click(object sender, EventArgs e)
        {
            Process selectedProcess = GetSelectedProcess();
            if (selectedProcess == null)
                return;

            try
            {
                frmLoadedModulesView loadedModules = new frmLoadedModulesView(selectedProcess);
                loadedModules.Show();
            }
            catch
            {
                AddLogMessage(string.Format("Access to '{0}' is denied.", selectedProcess.ProcessName), Color.Red);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = cancelApplicationExitEvent;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            cancelApplicationExitEvent = false;
            Application.Exit();
        }
    }
}