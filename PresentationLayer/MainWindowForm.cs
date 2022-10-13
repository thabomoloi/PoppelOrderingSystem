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
    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();

            HideAllSubmenu();
        }

        #region Hide/Show Submenu
        private void HideAllSubmenu()
        {
            ordersSubmenuPanel.Visible = false;
            customersSubmenuPanel.Visible = false;
        }

        private void ShowSubmenu(Panel submenuPanel)
        {
            if (submenuPanel.Visible == true)
                HideAllSubmenu();
            else
                submenuPanel.Visible = true;
        }
        #endregion
    }
}
