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
            // TODO: Log exceptions to file.
            // AddLogMessage(+ e.Message, Color.Red);
        }

        void AddLogMessage(string message, Color color)
        {
            message = string.Format("[{0}] {1}{2}", DateTime.Now.ToLongTimeString(), message, Environment.NewLine);
            rtxtbLog.SelectionColor = color;
            rtxtbLog.AppendText(message);
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

        private void btnInjectDll_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName(cboSystemProcesses.Text);
            if (processes.Length == 0)
            {
                AddLogMessage("Process not found !", Color.Red);
                return;
            }

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

            bool injected = Injector.InjectDll(processes[0], txtbDllPath.Text);
            if (injected)
            {
                AddLogMessage("Injection successful.", Color.Green);
            }
            else
            {
                AddLogMessage("Injection failed.", Color.Red);
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