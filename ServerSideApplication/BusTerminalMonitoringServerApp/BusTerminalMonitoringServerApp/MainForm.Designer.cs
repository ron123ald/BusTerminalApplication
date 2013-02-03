namespace BusTerminalMonitoringServerApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuBarStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearLogStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.LogControl = new System.Windows.Forms.TabControl();
            this.LogPage = new System.Windows.Forms.TabPage();
            this.ServerLogBox = new System.Windows.Forms.RichTextBox();
            this.OptionPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.StartDateTime = new System.Windows.Forms.DateTimePicker();
            this.EndDateTime = new System.Windows.Forms.DateTimePicker();
            this.MenuBarStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.LogControl.SuspendLayout();
            this.LogPage.SuspendLayout();
            this.OptionPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBarStrip
            // 
            this.MenuBarStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuBarStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuBarStrip.Name = "MenuBarStrip";
            this.MenuBarStrip.Size = new System.Drawing.Size(724, 24);
            this.MenuBarStrip.TabIndex = 2;
            this.MenuBarStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearLogStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // ClearLogStripMenuItem
            // 
            this.ClearLogStripMenuItem.Name = "ClearLogStripMenuItem";
            this.ClearLogStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ClearLogStripMenuItem.Text = "&Clear Logs";
            this.ClearLogStripMenuItem.Click += new System.EventHandler(this.ClearLogStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // DateTimer
            // 
            this.DateTimer.Enabled = true;
            this.DateTimer.Tick += new System.EventHandler(this.DateTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DateTimeLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 46);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.DateTimeLabel.Location = new System.Drawing.Point(556, 20);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.DateTimeLabel.TabIndex = 0;
            // 
            // LogControl
            // 
            this.LogControl.Controls.Add(this.LogPage);
            this.LogControl.Controls.Add(this.OptionPage);
            this.LogControl.Location = new System.Drawing.Point(12, 79);
            this.LogControl.Name = "LogControl";
            this.LogControl.SelectedIndex = 0;
            this.LogControl.Size = new System.Drawing.Size(700, 385);
            this.LogControl.TabIndex = 4;
            // 
            // LogPage
            // 
            this.LogPage.Controls.Add(this.ServerLogBox);
            this.LogPage.Location = new System.Drawing.Point(4, 22);
            this.LogPage.Name = "LogPage";
            this.LogPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogPage.Size = new System.Drawing.Size(692, 359);
            this.LogPage.TabIndex = 0;
            this.LogPage.Text = "Log";
            this.LogPage.UseVisualStyleBackColor = true;
            // 
            // ServerLogBox
            // 
            this.ServerLogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ServerLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerLogBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerLogBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ServerLogBox.Location = new System.Drawing.Point(3, 3);
            this.ServerLogBox.Name = "ServerLogBox";
            this.ServerLogBox.ReadOnly = true;
            this.ServerLogBox.Size = new System.Drawing.Size(686, 353);
            this.ServerLogBox.TabIndex = 2;
            this.ServerLogBox.Text = "";
            // 
            // OptionPage
            // 
            this.OptionPage.Controls.Add(this.groupBox2);
            this.OptionPage.Location = new System.Drawing.Point(4, 22);
            this.OptionPage.Name = "OptionPage";
            this.OptionPage.Padding = new System.Windows.Forms.Padding(3);
            this.OptionPage.Size = new System.Drawing.Size(692, 359);
            this.OptionPage.TabIndex = 1;
            this.OptionPage.Text = "Option";
            this.OptionPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EndDateTime);
            this.groupBox2.Controls.Add(this.StartDateTime);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Location = new System.Drawing.Point(6, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 180);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print Logs";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Gray;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(142, 137);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "SHOW";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // StartDateTime
            // 
            this.StartDateTime.Location = new System.Drawing.Point(17, 55);
            this.StartDateTime.Name = "StartDateTime";
            this.StartDateTime.Size = new System.Drawing.Size(200, 20);
            this.StartDateTime.TabIndex = 1;
            // 
            // EndDateTime
            // 
            this.EndDateTime.Location = new System.Drawing.Point(17, 94);
            this.EndDateTime.Name = "EndDateTime";
            this.EndDateTime.Size = new System.Drawing.Size(200, 20);
            this.EndDateTime.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 476);
            this.Controls.Add(this.LogControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MenuBarStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBarStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bus Terminal Monitoring System | Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.MenuBarStrip.ResumeLayout(false);
            this.MenuBarStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.LogControl.ResumeLayout(false);
            this.LogPage.ResumeLayout(false);
            this.OptionPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBarStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearLogStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer DateTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.TabControl LogControl;
        private System.Windows.Forms.TabPage LogPage;
        private System.Windows.Forms.RichTextBox ServerLogBox;
        private System.Windows.Forms.TabPage OptionPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker EndDateTime;
        private System.Windows.Forms.DateTimePicker StartDateTime;
    }
}

