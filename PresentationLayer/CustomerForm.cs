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
            HideTabPageHeaders();
            customerTabPages.SelectTab(addCustomerTab);
        }

        #region Hide Tab Page Headers
        public void HideTabPageHeaders()
        {
            customerTabPages.Appearance = TabAppearance.FlatButtons;
            customerTabPages.ItemSize = new Size(0, 1);
            customerTabPages.SizeMode = TabSizeMode.Fixed;
        }
        #endregion
    }
}
