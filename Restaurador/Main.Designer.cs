namespace Restaurador
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDatabases = new System.Windows.Forms.ComboBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtSourceFilePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkSettings = new System.Windows.Forms.LinkLabel();
            this.groupSource = new System.Windows.Forms.GroupBox();
            this.Database = new System.Windows.Forms.Label();
            this.txtSourceDatabaseName = new System.Windows.Forms.TextBox();
            this.groupDestination = new System.Windows.Forms.GroupBox();
            this.chkActivatesPhysicalChange = new System.Windows.Forms.CheckBox();
            this.chkActivatesLogicalChange = new System.Windows.Forms.CheckBox();
            this.groupPhysical = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhysicalLogFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhysicalDataFile = new System.Windows.Forms.TextBox();
            this.groupLogical = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLogicalDataName = new System.Windows.Forms.TextBox();
            this.txtLogicalLogName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStripStatusLabelKillProcesses = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupSource.SuspendLayout();
            this.groupDestination.SuspendLayout();
            this.groupPhysical.SuspendLayout();
            this.groupLogical.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Sql Server files|*.bak";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(436, 19);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 11;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Database";
            // 
            // cbxDatabases
            // 
            this.cbxDatabases.FormattingEnabled = true;
            this.cbxDatabases.Location = new System.Drawing.Point(73, 19);
            this.cbxDatabases.Name = "cbxDatabases";
            this.cbxDatabases.Size = new System.Drawing.Size(433, 21);
            this.cbxDatabases.TabIndex = 9;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(476, 17);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(30, 23);
            this.btnOpenFile.TabIndex = 8;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtSourceFilePath
            // 
            this.txtSourceFilePath.Location = new System.Drawing.Point(70, 19);
            this.txtSourceFilePath.Name = "txtSourceFilePath";
            this.txtSourceFilePath.Size = new System.Drawing.Size(398, 20);
            this.txtSourceFilePath.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Path";
            // 
            // lnkSettings
            // 
            this.lnkSettings.AutoSize = true;
            this.lnkSettings.Location = new System.Drawing.Point(6, 24);
            this.lnkSettings.Name = "lnkSettings";
            this.lnkSettings.Size = new System.Drawing.Size(66, 13);
            this.lnkSettings.TabIndex = 12;
            this.lnkSettings.TabStop = true;
            this.lnkSettings.Text = "[ Settings... ]";
            this.lnkSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSettings_LinkClicked);
            // 
            // groupSource
            // 
            this.groupSource.AutoSize = true;
            this.groupSource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupSource.Controls.Add(this.Database);
            this.groupSource.Controls.Add(this.txtSourceDatabaseName);
            this.groupSource.Controls.Add(this.txtSourceFilePath);
            this.groupSource.Controls.Add(this.label4);
            this.groupSource.Controls.Add(this.btnOpenFile);
            this.groupSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSource.Location = new System.Drawing.Point(0, 0);
            this.groupSource.Name = "groupSource";
            this.groupSource.Size = new System.Drawing.Size(515, 84);
            this.groupSource.TabIndex = 13;
            this.groupSource.TabStop = false;
            this.groupSource.Text = "Source";
            // 
            // Database
            // 
            this.Database.AutoSize = true;
            this.Database.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database.Location = new System.Drawing.Point(6, 48);
            this.Database.Name = "Database";
            this.Database.Size = new System.Drawing.Size(53, 13);
            this.Database.TabIndex = 11;
            this.Database.Text = "Database";
            // 
            // txtSourceDatabaseName
            // 
            this.txtSourceDatabaseName.Enabled = false;
            this.txtSourceDatabaseName.Location = new System.Drawing.Point(70, 45);
            this.txtSourceDatabaseName.Name = "txtSourceDatabaseName";
            this.txtSourceDatabaseName.Size = new System.Drawing.Size(398, 20);
            this.txtSourceDatabaseName.TabIndex = 10;
            // 
            // groupDestination
            // 
            this.groupDestination.AutoSize = true;
            this.groupDestination.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupDestination.Controls.Add(this.chkActivatesPhysicalChange);
            this.groupDestination.Controls.Add(this.chkActivatesLogicalChange);
            this.groupDestination.Controls.Add(this.groupPhysical);
            this.groupDestination.Controls.Add(this.groupLogical);
            this.groupDestination.Controls.Add(this.label5);
            this.groupDestination.Controls.Add(this.cbxDatabases);
            this.groupDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDestination.Location = new System.Drawing.Point(0, 84);
            this.groupDestination.Name = "groupDestination";
            this.groupDestination.Size = new System.Drawing.Size(515, 294);
            this.groupDestination.TabIndex = 14;
            this.groupDestination.TabStop = false;
            this.groupDestination.Text = "Destination";
            this.groupDestination.Resize += new System.EventHandler(this.groupDestination_Resize);
            // 
            // chkActivatesPhysicalChange
            // 
            this.chkActivatesPhysicalChange.AutoSize = true;
            this.chkActivatesPhysicalChange.Location = new System.Drawing.Point(9, 129);
            this.chkActivatesPhysicalChange.Name = "chkActivatesPhysicalChange";
            this.chkActivatesPhysicalChange.Size = new System.Drawing.Size(15, 14);
            this.chkActivatesPhysicalChange.TabIndex = 23;
            this.chkActivatesPhysicalChange.UseVisualStyleBackColor = true;
            this.chkActivatesPhysicalChange.CheckedChanged += new System.EventHandler(this.chkActivatesPhysicalChange_CheckedChanged);
            // 
            // chkActivatesLogicalChange
            // 
            this.chkActivatesLogicalChange.AutoSize = true;
            this.chkActivatesLogicalChange.Location = new System.Drawing.Point(9, 46);
            this.chkActivatesLogicalChange.Name = "chkActivatesLogicalChange";
            this.chkActivatesLogicalChange.Size = new System.Drawing.Size(15, 14);
            this.chkActivatesLogicalChange.TabIndex = 22;
            this.chkActivatesLogicalChange.UseVisualStyleBackColor = true;
            this.chkActivatesLogicalChange.CheckedChanged += new System.EventHandler(this.chkActivatesLogicalChange_CheckedChanged);
            // 
            // groupPhysical
            // 
            this.groupPhysical.Controls.Add(this.label3);
            this.groupPhysical.Controls.Add(this.txtPhysicalLogFile);
            this.groupPhysical.Controls.Add(this.label6);
            this.groupPhysical.Controls.Add(this.txtPhysicalDataFile);
            this.groupPhysical.Enabled = false;
            this.groupPhysical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPhysical.Location = new System.Drawing.Point(30, 129);
            this.groupPhysical.Name = "groupPhysical";
            this.groupPhysical.Size = new System.Drawing.Size(476, 77);
            this.groupPhysical.TabIndex = 21;
            this.groupPhysical.TabStop = false;
            this.groupPhysical.Text = "Physical";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Data";
            // 
            // txtPhysicalLogFile
            // 
            this.txtPhysicalLogFile.Location = new System.Drawing.Point(54, 45);
            this.txtPhysicalLogFile.Name = "txtPhysicalLogFile";
            this.txtPhysicalLogFile.Size = new System.Drawing.Size(416, 20);
            this.txtPhysicalLogFile.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Log";
            // 
            // txtPhysicalDataFile
            // 
            this.txtPhysicalDataFile.Location = new System.Drawing.Point(54, 19);
            this.txtPhysicalDataFile.Name = "txtPhysicalDataFile";
            this.txtPhysicalDataFile.Size = new System.Drawing.Size(416, 20);
            this.txtPhysicalDataFile.TabIndex = 12;
            // 
            // groupLogical
            // 
            this.groupLogical.Controls.Add(this.label8);
            this.groupLogical.Controls.Add(this.txtLogicalDataName);
            this.groupLogical.Controls.Add(this.txtLogicalLogName);
            this.groupLogical.Controls.Add(this.label7);
            this.groupLogical.Enabled = false;
            this.groupLogical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupLogical.Location = new System.Drawing.Point(30, 46);
            this.groupLogical.Name = "groupLogical";
            this.groupLogical.Size = new System.Drawing.Size(476, 77);
            this.groupLogical.TabIndex = 20;
            this.groupLogical.TabStop = false;
            this.groupLogical.Text = "Logical name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Data";
            // 
            // txtLogicalDataName
            // 
            this.txtLogicalDataName.Location = new System.Drawing.Point(54, 19);
            this.txtLogicalDataName.Name = "txtLogicalDataName";
            this.txtLogicalDataName.Size = new System.Drawing.Size(416, 20);
            this.txtLogicalDataName.TabIndex = 16;
            // 
            // txtLogicalLogName
            // 
            this.txtLogicalLogName.Location = new System.Drawing.Point(54, 45);
            this.txtLogicalLogName.Name = "txtLogicalLogName";
            this.txtLogicalLogName.Size = new System.Drawing.Size(416, 20);
            this.txtLogicalLogName.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Log";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabelKillProcesses});
            this.statusStrip1.Location = new System.Drawing.Point(0, 356);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(515, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.RightToLeftLayout = true;
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lnkSettings);
            this.groupBox1.Controls.Add(this.btnRestore);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 61);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // toolStripStatusLabelKillProcesses
            // 
            this.toolStripStatusLabelKillProcesses.Name = "toolStripStatusLabelKillProcesses";
            this.toolStripStatusLabelKillProcesses.Size = new System.Drawing.Size(0, 17);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 378);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupDestination);
            this.Controls.Add(this.groupSource);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurador (for Sql Server Backups)";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.groupSource.ResumeLayout(false);
            this.groupSource.PerformLayout();
            this.groupDestination.ResumeLayout(false);
            this.groupDestination.PerformLayout();
            this.groupPhysical.ResumeLayout(false);
            this.groupPhysical.PerformLayout();
            this.groupLogical.ResumeLayout(false);
            this.groupLogical.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxDatabases;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtSourceFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lnkSettings;
        private System.Windows.Forms.GroupBox groupSource;
        private System.Windows.Forms.GroupBox groupDestination;
        private System.Windows.Forms.Label Database;
        private System.Windows.Forms.TextBox txtSourceDatabaseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhysicalLogFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhysicalDataFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLogicalLogName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLogicalDataName;
        private System.Windows.Forms.GroupBox groupLogical;
        private System.Windows.Forms.GroupBox groupPhysical;
        private System.Windows.Forms.CheckBox chkActivatesLogicalChange;
        private System.Windows.Forms.CheckBox chkActivatesPhysicalChange;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelKillProcesses;
    }
}

