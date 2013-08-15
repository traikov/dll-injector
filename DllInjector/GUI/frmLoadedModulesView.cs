using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DllInjector.GUI
{
    public partial class frmLoadedModulesView : Form
    {
        public frmLoadedModulesView()
        {
            InitializeComponent();
        }

        public frmLoadedModulesView(Process process)
            : this()
        {
            this.Text = process.MainModule.FileName;

            foreach (ProcessModule module in process.Modules)
            {
                gridViewLoadedModules.Rows.Add(
                    "0x" + module.BaseAddress.ToString("X"),
                    "0x" + module.ModuleMemorySize.ToString("X"),
                    "0x" + module.EntryPointAddress.ToString("X"),
                    module.ModuleName,
                    module.FileVersionInfo.FileVersion,
                    module.FileName);
            }
        }

    }
}
