using System;
namespace BusTerminalServer
{
    using System.Windows.Forms;

    public partial class ConfigurationForm : Form
    {
        #region Serial Property
        /// <summary>
        /// </summary>
        public string PortName
        {
            get { return this.PortNameBox.Text; }
        }
        /// <summary>
        /// </summary>
        public int BaudRate
        {
            get { return int.Parse(this.BaudRateBox.Text); }
        }
        /// <summary>
        /// </summary>
        public System.IO.Ports.Parity Parity
        {
            get { return (System.IO.Ports.Parity)this.ParityBox.SelectedIndex; }
        }
        /// <summary>
        /// </summary>
        public System.IO.Ports.StopBits StopBits
        {
            get { return (System.IO.Ports.StopBits)this.StopBitsBox.SelectedIndex; }
        }

        #endregion
        /// <summary>
        /// Constructor for ConfigurationForm
        /// </summary>
        public ConfigurationForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Triggers whenever the user clicks on submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            /// Message Box dialog result
            DialogResult result = default(DialogResult);
            try
            {
                /// Validate All Fields
                /// Check if PortNameBox's value is Null or Empty
                if (!string.IsNullOrEmpty(this.PortNameBox.Text))
                {
                    /// Check if BaudRateBox's value is Null or Empty
                    if (!string.IsNullOrEmpty(this.BaudRateBox.Text))
                    {
                        /// Set Dialog result to Ok
                        /// when dialoag result is Ok means Serial can now be Initialize.
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        /// Throw an Argument Null Exception for User to see that the the PortNameBox is NULL or Empty
                        throw new ArgumentNullException("Baud Rate", "Baud Rate cannot be NULL or Empty");
                }
                else
                    /// Throw an Argument Null Exception for User to see that the the PortNameBox is NULL or Empty
                    throw new ArgumentNullException("Port Name", "Port name cannot be NULL or Empty");
            }
            catch (Exception ex)
            {
                /// Show Message Box with exception message details.
                result = MessageBox.Show(this, ex.Message, "Exception Occured", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                /// Check the result of MessageBox
                if (result == DialogResult.Retry)
                {
                    ClearComponent();
                    /// Focus in the Port Name Box
                    this.PortNameBox.Focus();
                }
                else if (result == DialogResult.Cancel)
                {
                    /// Set Dialog result to Ok
                    /// when dialoag result is Ok means Serial can now be Initialize.
                    this.DialogResult = result;
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Clear Component 
        ///   - Port Name Box
        ///   - Baud Rate Box
        /// </summary>
        private void ClearComponent()
        {
            this.PortNameBox.Clear();
            this.BaudRateBox.Clear();
        }
    }
}
