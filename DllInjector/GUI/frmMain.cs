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
            Injector.OnDllInjectEventHandler += new Injector.OnDllInjectDelegate(Injector_OnDllInject);
        }

        OpenFileDialog fileDialog = new OpenFileDialog()
        {
            Filter = "*.dll|*.dll"
        };
        Process selectedProcess = null;

        void Injector_OnDllInject(object sender, DllInjectEventArgs e)
        {
            Color messageColor = e.Failed ? Color.Red : Color.Green;
            AddLogMessage(e.StatusMessage, messageColor);
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

        private void cboSystemProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProcess = Process.GetProcessesByName(cboSystemProcesses.Text)[0];
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
            if (selectedProcess == null)
            {
                AddLogMessage("Process not found !", Color.Red);
                return;
            }
            if (String.IsNullOrEmpty(txtbDllPath.Text))
            {
                AddLogMessage("Dll not selected or invalid dll path.", Color.Red);
                return;
            }

            Injector.InjectDll(selectedProcess, txtbDllPath.Text);   
        }
    }
}