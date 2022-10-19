using FontAwesome.Sharp;
using PoppelOrderingSystem.BusinessLayer;
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
        #region Fields
        private IconButton activeButton;
        private Form activeChildForm;
        #endregion

        #region Constructor
        public MainWindowForm()
        {
            InitializeComponent();
            //  Hide all submenus by default
            HideAllSubmenu();
            
        }

        #endregion

        #region Hide/Show Submenu
        private void HideAllSubmenu()
        {
            ordersSubmenuPanel.Visible = false;
            customersSubmenuPanel.Visible = false;
            productsSubmenuPanel.Visible = false;
        }

        private void ShowSubmenu(Panel submenuPanel)
        {
            if (submenuPanel.Visible == true)
                HideAllSubmenu();
            else
            {
                HideAllSubmenu();
                submenuPanel.Visible = true;
            }
        }
        #endregion

        #region  Active Button - Change Background Colors
        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                DeactivateButton();
                activeButton = (IconButton)sender;
                activeButton.BackColor = ColorsRGB.CYAN_900;
            }
        }
        private void DeactivateButton()
        {
            if (activeButton != null)
            {
                activeButton.BackColor = ColorsRGB.EMERALD_900;
            }
        }
        #endregion

        #region Child Form Handler
        private void OpenChildForm(Form childForm)
        {
            if (activeChildForm != null)
                activeChildForm.Close();

            activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;

            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region Sidemenu buttons click events
        private void dashboardButton_Click(object sender, EventArgs e)
        {
            HideAllSubmenu();
            ActivateButton(sender);
        }

        private void ordersButton_Click(object sender, EventArgs e)
        {
            ShowSubmenu(ordersSubmenuPanel);
            ActivateButton(sender);
        }

        #region Order Submenu
        private void newOrderButton_Click(object sender, EventArgs e)
        {

        }

        private void listOrdersButton_Click(object sender, EventArgs e)
        {

        }
        #endregion 

        private void customersButton_Click(object sender, EventArgs e)
        {
            ShowSubmenu(customersSubmenuPanel);
        }

        #region Customers Submenu
        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            ActivateButton(customersButton);
            HideAllSubmenu();
            OpenChildForm(new CustomerForm(new CustomerController(), new AccountHandler(), new AddressHandler()));
        }

        private void listCustomersButton_Click(object sender, EventArgs e)
        {
            ActivateButton(customersButton);
            HideAllSubmenu();
            OpenChildForm(new CustomerListing());
        }
        #endregion

        private void productsButton_Click(object sender, EventArgs e)
        {
            HideAllSubmenu();
            ShowSubmenu(productsSubmenuPanel);
        }
        #region Products submenu
        private void catalogProductsButton_Click(object sender, EventArgs e)
        {
            ActivateButton(productsButton);
            HideAllSubmenu();
            OpenChildForm(new CatalogProductsForm());
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            ActivateButton(productsButton);
            HideAllSubmenu();
            OpenChildForm(new InventoryForm());
        }
        #endregion
        private void reportButton_Click(object sender, EventArgs e)
        {
            HideAllSubmenu();
            ActivateButton(sender);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            HideAllSubmenu();
            ActivateButton(sender);
        }
        #endregion

        

        
    }
}
