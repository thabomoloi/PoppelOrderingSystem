using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem.PresentationLayer
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        #region Clear All TextBox Controls
        private void ClearAll()
        {
            custNoTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            phoneNoTextBox.Text = "";
            emailTextBox.Text = "";
            streetTextBox.Text = "";
            cityTextBox.Text = "";
            suburbTextBox.Text = "";
            postCodeTextBox.Text = "";
            provinceComboBox.ResetText();
        }
        #endregion
        #region ClearButton Click Event
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        #endregion
    }
}
