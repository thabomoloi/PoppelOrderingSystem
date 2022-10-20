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
    public partial class LoginForm : Form
    {
        private UserAccountHandler userAccountHandler;
        private MarketingClerkHandler clerkHandler;
        public static string username;
        public LoginForm()
        {
            userAccountHandler = new UserAccountHandler();
            clerkHandler = new MarketingClerkHandler();

            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter the Clerk ID.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (passwordTextbox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter the password.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MarketingClerk marketingClerk = new MarketingClerk
                {
                    ClerkID = usernameTextbox.Text.Trim()
                };
                int index = clerkHandler.FindIndex(marketingClerk);
                if (index == -1)
                {
                    MessageBox.Show("Please enter valid Clerk ID and password.", "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    marketingClerk = clerkHandler.Find(marketingClerk.ClerkID);
                    UserAccount user = userAccountHandler.Find(marketingClerk.UserID);

                    if (passwordTextbox.Text.Trim() == user.Password)
                    {
                        this.DialogResult = DialogResult.OK;
                        username = marketingClerk.FirstName;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid Clerk ID and password.", "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            this.DialogResult = DialogResult.OK;
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
