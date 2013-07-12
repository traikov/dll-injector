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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnInjectDll = new System.Windows.Forms.Button();
            this.cboSystemProcesses = new System.Windows.Forms.ComboBox();
            this.btnSelectDll = new System.Windows.Forms.Button();
            this.txtbDllPath = new System.Windows.Forms.TextBox();
            this.rtxtbLog = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInjectDll
            // 
            this.btnInjectDll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInjectDll.Location = new System.Drawing.Point(216, 141);
            this.btnInjectDll.Name = "btnInjectDll";
            this.btnInjectDll.Size = new System.Drawing.Size(84, 24);
            this.btnInjectDll.TabIndex = 0;
            this.btnInjectDll.Text = "Inject";
            this.btnInjectDll.UseVisualStyleBackColor = true;
            this.btnInjectDll.Click += new System.EventHandler(this.btnInjectDll_Click);
            // 
            // cboSystemProcesses
            // 
            this.cboSystemProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboSystemProcesses.FormattingEnabled = true;
            this.cboSystemProcesses.Location = new System.Drawing.Point(6, 19);
            this.cboSystemProcesses.Name = "cboSystemProcesses";
            this.cboSystemProcesses.Size = new System.Drawing.Size(271, 21);
            this.cboSystemProcesses.TabIndex = 1;
            this.cboSystemProcesses.Text = "Click here to select process..";
            this.cboSystemProcesses.SelectedIndexChanged += new System.EventHandler(this.cboSystemProcesses_SelectedIndexChanged);
            this.cboSystemProcesses.DropDown += new System.EventHandler(this.cboSystemProcesses_DropDown);
            // 
            // btnSelectDll
            // 
            this.btnSelectDll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectDll.Location = new System.Drawing.Point(246, 19);
            this.btnSelectDll.Name = "btnSelectDll";
            this.btnSelectDll.Size = new System.Drawing.Size(31, 20);
            this.btnSelectDll.TabIndex = 2;
            this.btnSelectDll.Text = "...";
            this.btnSelectDll.UseVisualStyleBackColor = true;
            this.btnSelectDll.Click += new System.EventHandler(this.btnSelectDll_Click);
            // 
            // txtbDllPath
            // 
            this.txtbDllPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbDllPath.Location = new System.Drawing.Point(6, 19);
            this.txtbDllPath.Name = "txtbDllPath";
            this.txtbDllPath.ReadOnly = true;
            this.txtbDllPath.Size = new System.Drawing.Size(234, 20);
            this.txtbDllPath.TabIndex = 3;
            // 
            // rtxtbLog
            // 
            this.rtxtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxtbLog.Location = new System.Drawing.Point(6, 15);
            this.rtxtbLog.Name = "rtxtbLog";
            this.rtxtbLog.ReadOnly = true;
            this.rtxtbLog.Size = new System.Drawing.Size(271, 72);
            this.rtxtbLog.TabIndex = 4;
            this.rtxtbLog.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSystemProcesses);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 55);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target Process";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbDllPath);
            this.groupBox2.Controls.Add(this.btnSelectDll);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 62);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DLL to Inject";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(12, 141);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 24);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtxtbLog);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 97);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 288);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInjectDll);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Dll Injector";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInjectDll;
        private System.Windows.Forms.ComboBox cboSystemProcesses;
        private System.Windows.Forms.Button btnSelectDll;
        private System.Windows.Forms.TextBox txtbDllPath;
        private System.Windows.Forms.RichTextBox rtxtbLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}