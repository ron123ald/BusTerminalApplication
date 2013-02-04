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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintDocForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOkPrint = new System.Windows.Forms.Button();
            this.btnCancelPrint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.documentBox = new System.Windows.Forms.RichTextBox();
            this.printDocumentRecord = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.btnPreview = new System.Windows.Forms.Button();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnOkPrint);
            this.panel1.Controls.Add(this.btnCancelPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 52);
            this.panel1.TabIndex = 0;
            // 
            // btnOkPrint
            // 
            this.btnOkPrint.BackColor = System.Drawing.Color.Lime;
            this.btnOkPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkPrint.Location = new System.Drawing.Point(507, 5);
            this.btnOkPrint.Name = "btnOkPrint";
            this.btnOkPrint.Size = new System.Drawing.Size(75, 43);
            this.btnOkPrint.TabIndex = 0;
            this.btnOkPrint.Text = "OK";
            this.btnOkPrint.UseVisualStyleBackColor = false;
            this.btnOkPrint.Click += new System.EventHandler(this.btnOkPrint_Click);
            // 
            // btnCancelPrint
            // 
            this.btnCancelPrint.BackColor = System.Drawing.Color.Red;
            this.btnCancelPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelPrint.Location = new System.Drawing.Point(588, 5);
            this.btnCancelPrint.Name = "btnCancelPrint";
            this.btnCancelPrint.Size = new System.Drawing.Size(75, 43);
            this.btnCancelPrint.TabIndex = 0;
            this.btnCancelPrint.Text = "CANCEL";
            this.btnCancelPrint.UseVisualStyleBackColor = false;
            this.btnCancelPrint.Click += new System.EventHandler(this.btnCancelPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.documentBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 349);
            this.panel2.TabIndex = 1;
            // 
            // documentBox
            // 
            this.documentBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentBox.Location = new System.Drawing.Point(0, 0);
            this.documentBox.Name = "documentBox";
            this.documentBox.Size = new System.Drawing.Size(671, 349);
            this.documentBox.TabIndex = 0;
            this.documentBox.Text = "";
            // 
            // printDocumentRecord
            // 
            this.printDocumentRecord.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentRecord_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Gray;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Location = new System.Drawing.Point(426, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 43);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            this.printPreviewDialog.Load += new System.EventHandler(this.printPreviewDialog_Load);
            // 
            // PrintDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 401);
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
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}