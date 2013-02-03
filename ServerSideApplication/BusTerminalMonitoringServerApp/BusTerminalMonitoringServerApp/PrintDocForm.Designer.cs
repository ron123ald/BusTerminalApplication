namespace BusTerminalMonitoringServerApp
{
    partial class PrintDocForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.documentBox = new System.Windows.Forms.RichTextBox();
            this.btnCancelPrint = new System.Windows.Forms.Button();
            this.btnOkPrint = new System.Windows.Forms.Button();
            this.printDocumentRecord = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOkPrint);
            this.panel1.Controls.Add(this.btnCancelPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 52);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.documentBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 349);
            this.panel2.TabIndex = 1;
            // 
            // documentBox
            // 
            this.documentBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentBox.Location = new System.Drawing.Point(0, 0);
            this.documentBox.Name = "documentBox";
            this.documentBox.Size = new System.Drawing.Size(718, 349);
            this.documentBox.TabIndex = 0;
            this.documentBox.Text = "";
            // 
            // btnCancelPrint
            // 
            this.btnCancelPrint.BackColor = System.Drawing.Color.Red;
            this.btnCancelPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelPrint.Location = new System.Drawing.Point(631, 6);
            this.btnCancelPrint.Name = "btnCancelPrint";
            this.btnCancelPrint.Size = new System.Drawing.Size(75, 43);
            this.btnCancelPrint.TabIndex = 0;
            this.btnCancelPrint.Text = "CANCEL";
            this.btnCancelPrint.UseVisualStyleBackColor = false;
            this.btnCancelPrint.Click += new System.EventHandler(this.btnCancelPrint_Click);
            // 
            // btnOkPrint
            // 
            this.btnOkPrint.BackColor = System.Drawing.Color.Lime;
            this.btnOkPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkPrint.Location = new System.Drawing.Point(550, 6);
            this.btnOkPrint.Name = "btnOkPrint";
            this.btnOkPrint.Size = new System.Drawing.Size(75, 43);
            this.btnOkPrint.TabIndex = 0;
            this.btnOkPrint.Text = "OK";
            this.btnOkPrint.UseVisualStyleBackColor = false;
            this.btnOkPrint.Click += new System.EventHandler(this.btnOkPrint_Click);
            // 
            // printDocumentRecord
            // 
            this.printDocumentRecord.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentRecord_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // PrintDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PrintDocForm";
            this.Text = "Server Database | Records";
            this.Load += new System.EventHandler(this.PrintDocForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox documentBox;
        private System.Windows.Forms.Button btnOkPrint;
        private System.Windows.Forms.Button btnCancelPrint;
        private System.Drawing.Printing.PrintDocument printDocumentRecord;
        private System.Windows.Forms.PrintDialog printDialog;
    }
}