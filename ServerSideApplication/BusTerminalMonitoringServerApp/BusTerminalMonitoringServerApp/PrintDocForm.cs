
namespace BusTerminalMonitoringServerApp
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class PrintDocForm : Form
    {
        private string data = string.Empty;

        public PrintDocForm(string data)
        {
            this.data = data;

            InitializeComponent();
        }

        private void PrintDocForm_Load(object sender, EventArgs e)
        {
            this.documentBox.AppendText(this.data);
        }

        private void printDocumentRecord_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(this.documentBox.Text, this.documentBox.Font, Brushes.Black, 100, 20);
            e.Graphics.PageUnit = GraphicsUnit.Inch;
        }

        private void btnOkPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.printDialog.Document = this.printDocumentRecord;
                if (this.printDialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.printDocumentRecord.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error printing documents", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnCancelPrint_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
