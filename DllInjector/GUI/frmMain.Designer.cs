namespace DllInjector.GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInjectDll = new System.Windows.Forms.Button();
            this.cboSystemProcesses = new System.Windows.Forms.ComboBox();
            this.btnSelectDll = new System.Windows.Forms.Button();
            this.txtbDllPath = new System.Windows.Forms.TextBox();
            this.rtxtbLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnInjectDll
            // 
            this.btnInjectDll.Location = new System.Drawing.Point(12, 153);
            this.btnInjectDll.Name = "btnInjectDll";
            this.btnInjectDll.Size = new System.Drawing.Size(310, 24);
            this.btnInjectDll.TabIndex = 0;
            this.btnInjectDll.Text = "Inject";
            this.btnInjectDll.UseVisualStyleBackColor = true;
            this.btnInjectDll.Click += new System.EventHandler(this.btnInjectDll_Click);
            // 
            // cboSystemProcesses
            // 
            this.cboSystemProcesses.FormattingEnabled = true;
            this.cboSystemProcesses.Location = new System.Drawing.Point(12, 12);
            this.cboSystemProcesses.Name = "cboSystemProcesses";
            this.cboSystemProcesses.Size = new System.Drawing.Size(310, 21);
            this.cboSystemProcesses.TabIndex = 1;
            this.cboSystemProcesses.Text = "Click here to select process..";
            this.cboSystemProcesses.SelectedIndexChanged += new System.EventHandler(this.cboSystemProcesses_SelectedIndexChanged);
            this.cboSystemProcesses.DropDown += new System.EventHandler(this.cboSystemProcesses_DropDown);
            // 
            // btnSelectDll
            // 
            this.btnSelectDll.Location = new System.Drawing.Point(247, 40);
            this.btnSelectDll.Name = "btnSelectDll";
            this.btnSelectDll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDll.TabIndex = 2;
            this.btnSelectDll.Text = "Select Dll";
            this.btnSelectDll.UseVisualStyleBackColor = true;
            this.btnSelectDll.Click += new System.EventHandler(this.btnSelectDll_Click);
            // 
            // txtbDllPath
            // 
            this.txtbDllPath.Location = new System.Drawing.Point(12, 42);
            this.txtbDllPath.Name = "txtbDllPath";
            this.txtbDllPath.ReadOnly = true;
            this.txtbDllPath.Size = new System.Drawing.Size(229, 20);
            this.txtbDllPath.TabIndex = 3;
            // 
            // rtxtbLog
            // 
            this.rtxtbLog.Location = new System.Drawing.Point(12, 69);
            this.rtxtbLog.Name = "rtxtbLog";
            this.rtxtbLog.ReadOnly = true;
            this.rtxtbLog.Size = new System.Drawing.Size(310, 71);
            this.rtxtbLog.TabIndex = 4;
            this.rtxtbLog.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 189);
            this.Controls.Add(this.rtxtbLog);
            this.Controls.Add(this.txtbDllPath);
            this.Controls.Add(this.btnSelectDll);
            this.Controls.Add(this.cboSystemProcesses);
            this.Controls.Add(this.btnInjectDll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Dll Injector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInjectDll;
        private System.Windows.Forms.ComboBox cboSystemProcesses;
        private System.Windows.Forms.Button btnSelectDll;
        private System.Windows.Forms.TextBox txtbDllPath;
        private System.Windows.Forms.RichTextBox rtxtbLog;
    }
}