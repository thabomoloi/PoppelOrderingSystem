
namespace PoppelOrderingSystem.PresentationLayer
{
    partial class MainWindowForm
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
            this.sidemenuPanel = new System.Windows.Forms.Panel();
            this.logoutButton = new FontAwesome.Sharp.IconButton();
            this.spacingPanel = new System.Windows.Forms.Panel();
            this.reportButton = new FontAwesome.Sharp.IconButton();
            this.productsButton = new FontAwesome.Sharp.IconButton();
            this.customersSubmenuPanel = new System.Windows.Forms.Panel();
            this.listCustomersButton = new FontAwesome.Sharp.IconButton();
            this.addCustomerButton = new FontAwesome.Sharp.IconButton();
            this.customersButton = new FontAwesome.Sharp.IconButton();
            this.ordersSubmenuPanel = new System.Windows.Forms.Panel();
            this.listOrdersButton = new FontAwesome.Sharp.IconButton();
            this.newOrderButton = new FontAwesome.Sharp.IconButton();
            this.ordersButton = new FontAwesome.Sharp.IconButton();
            this.dashboardButton = new FontAwesome.Sharp.IconButton();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.childFormPanel = new System.Windows.Forms.Panel();
            this.sidemenuPanel.SuspendLayout();
            this.customersSubmenuPanel.SuspendLayout();
            this.ordersSubmenuPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidemenuPanel
            // 
            this.sidemenuPanel.AutoScroll = true;
            this.sidemenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(78)))), ((int)(((byte)(59)))));
            this.sidemenuPanel.Controls.Add(this.logoutButton);
            this.sidemenuPanel.Controls.Add(this.spacingPanel);
            this.sidemenuPanel.Controls.Add(this.reportButton);
            this.sidemenuPanel.Controls.Add(this.productsButton);
            this.sidemenuPanel.Controls.Add(this.customersSubmenuPanel);
            this.sidemenuPanel.Controls.Add(this.customersButton);
            this.sidemenuPanel.Controls.Add(this.ordersSubmenuPanel);
            this.sidemenuPanel.Controls.Add(this.ordersButton);
            this.sidemenuPanel.Controls.Add(this.dashboardButton);
            this.sidemenuPanel.Controls.Add(this.logoPanel);
            this.sidemenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidemenuPanel.Location = new System.Drawing.Point(0, 0);
            this.sidemenuPanel.Name = "sidemenuPanel";
            this.sidemenuPanel.Size = new System.Drawing.Size(250, 676);
            this.sidemenuPanel.TabIndex = 0;
            // 
            // logoutButton
            // 
            this.logoutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.logoutButton.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.logoutButton.IconColor = System.Drawing.Color.Gainsboro;
            this.logoutButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logoutButton.IconSize = 32;
            this.logoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.Location = new System.Drawing.Point(0, 590);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.logoutButton.Size = new System.Drawing.Size(250, 50);
            this.logoutButton.TabIndex = 10;
            this.logoutButton.Text = "Logout";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // spacingPanel
            // 
            this.spacingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.spacingPanel.Location = new System.Drawing.Point(0, 530);
            this.spacingPanel.Name = "spacingPanel";
            this.spacingPanel.Size = new System.Drawing.Size(250, 60);
            this.spacingPanel.TabIndex = 9;
            // 
            // reportButton
            // 
            this.reportButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportButton.FlatAppearance.BorderSize = 0;
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.reportButton.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.reportButton.IconColor = System.Drawing.Color.Gainsboro;
            this.reportButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reportButton.IconSize = 32;
            this.reportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportButton.Location = new System.Drawing.Point(0, 480);
            this.reportButton.Name = "reportButton";
            this.reportButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.reportButton.Size = new System.Drawing.Size(250, 50);
            this.reportButton.TabIndex = 8;
            this.reportButton.Text = "Report";
            this.reportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // productsButton
            // 
            this.productsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.productsButton.FlatAppearance.BorderSize = 0;
            this.productsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.productsButton.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.productsButton.IconColor = System.Drawing.Color.Gainsboro;
            this.productsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.productsButton.IconSize = 32;
            this.productsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.productsButton.Location = new System.Drawing.Point(0, 430);
            this.productsButton.Name = "productsButton";
            this.productsButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.productsButton.Size = new System.Drawing.Size(250, 50);
            this.productsButton.TabIndex = 7;
            this.productsButton.Text = "Products";
            this.productsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.productsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.productsButton.UseVisualStyleBackColor = true;
            this.productsButton.Click += new System.EventHandler(this.productsButton_Click);
            // 
            // customersSubmenuPanel
            // 
            this.customersSubmenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.customersSubmenuPanel.Controls.Add(this.listCustomersButton);
            this.customersSubmenuPanel.Controls.Add(this.addCustomerButton);
            this.customersSubmenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.customersSubmenuPanel.Location = new System.Drawing.Point(0, 340);
            this.customersSubmenuPanel.Name = "customersSubmenuPanel";
            this.customersSubmenuPanel.Size = new System.Drawing.Size(250, 90);
            this.customersSubmenuPanel.TabIndex = 6;
            // 
            // listCustomersButton
            // 
            this.listCustomersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.listCustomersButton.FlatAppearance.BorderSize = 0;
            this.listCustomersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listCustomersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCustomersButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.listCustomersButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.listCustomersButton.IconColor = System.Drawing.Color.Gainsboro;
            this.listCustomersButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.listCustomersButton.IconSize = 24;
            this.listCustomersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.listCustomersButton.Location = new System.Drawing.Point(0, 45);
            this.listCustomersButton.Name = "listCustomersButton";
            this.listCustomersButton.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.listCustomersButton.Size = new System.Drawing.Size(250, 45);
            this.listCustomersButton.TabIndex = 7;
            this.listCustomersButton.Text = "List Customers";
            this.listCustomersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.listCustomersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.listCustomersButton.UseVisualStyleBackColor = true;
            this.listCustomersButton.Click += new System.EventHandler(this.listCustomersButton_Click);
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addCustomerButton.FlatAppearance.BorderSize = 0;
            this.addCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCustomerButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.addCustomerButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.addCustomerButton.IconColor = System.Drawing.Color.Gainsboro;
            this.addCustomerButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addCustomerButton.IconSize = 24;
            this.addCustomerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addCustomerButton.Location = new System.Drawing.Point(0, 0);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.addCustomerButton.Size = new System.Drawing.Size(250, 45);
            this.addCustomerButton.TabIndex = 6;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addCustomerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // customersButton
            // 
            this.customersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.customersButton.FlatAppearance.BorderSize = 0;
            this.customersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customersButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.customersButton.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.customersButton.IconColor = System.Drawing.Color.Gainsboro;
            this.customersButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.customersButton.IconSize = 32;
            this.customersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customersButton.Location = new System.Drawing.Point(0, 290);
            this.customersButton.Name = "customersButton";
            this.customersButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.customersButton.Size = new System.Drawing.Size(250, 50);
            this.customersButton.TabIndex = 5;
            this.customersButton.Text = "Customers";
            this.customersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.customersButton.UseVisualStyleBackColor = true;
            this.customersButton.Click += new System.EventHandler(this.customersButton_Click);
            // 
            // ordersSubmenuPanel
            // 
            this.ordersSubmenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.ordersSubmenuPanel.Controls.Add(this.listOrdersButton);
            this.ordersSubmenuPanel.Controls.Add(this.newOrderButton);
            this.ordersSubmenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ordersSubmenuPanel.Location = new System.Drawing.Point(0, 200);
            this.ordersSubmenuPanel.Name = "ordersSubmenuPanel";
            this.ordersSubmenuPanel.Size = new System.Drawing.Size(250, 90);
            this.ordersSubmenuPanel.TabIndex = 3;
            // 
            // listOrdersButton
            // 
            this.listOrdersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.listOrdersButton.FlatAppearance.BorderSize = 0;
            this.listOrdersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listOrdersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOrdersButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.listOrdersButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.listOrdersButton.IconColor = System.Drawing.Color.Gainsboro;
            this.listOrdersButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.listOrdersButton.IconSize = 24;
            this.listOrdersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.listOrdersButton.Location = new System.Drawing.Point(0, 45);
            this.listOrdersButton.Name = "listOrdersButton";
            this.listOrdersButton.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.listOrdersButton.Size = new System.Drawing.Size(250, 45);
            this.listOrdersButton.TabIndex = 4;
            this.listOrdersButton.Text = "List Orders";
            this.listOrdersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.listOrdersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.listOrdersButton.UseVisualStyleBackColor = true;
            this.listOrdersButton.Click += new System.EventHandler(this.listOrdersButton_Click);
            // 
            // newOrderButton
            // 
            this.newOrderButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.newOrderButton.FlatAppearance.BorderSize = 0;
            this.newOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newOrderButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.newOrderButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.newOrderButton.IconColor = System.Drawing.Color.Gainsboro;
            this.newOrderButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.newOrderButton.IconSize = 24;
            this.newOrderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newOrderButton.Location = new System.Drawing.Point(0, 0);
            this.newOrderButton.Name = "newOrderButton";
            this.newOrderButton.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.newOrderButton.Size = new System.Drawing.Size(250, 45);
            this.newOrderButton.TabIndex = 3;
            this.newOrderButton.Text = "Start New Order";
            this.newOrderButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newOrderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newOrderButton.UseVisualStyleBackColor = true;
            this.newOrderButton.Click += new System.EventHandler(this.newOrderButton_Click);
            // 
            // ordersButton
            // 
            this.ordersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ordersButton.FlatAppearance.BorderSize = 0;
            this.ordersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ordersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordersButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ordersButton.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.ordersButton.IconColor = System.Drawing.Color.Gainsboro;
            this.ordersButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ordersButton.IconSize = 32;
            this.ordersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersButton.Location = new System.Drawing.Point(0, 150);
            this.ordersButton.Name = "ordersButton";
            this.ordersButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ordersButton.Size = new System.Drawing.Size(250, 50);
            this.ordersButton.TabIndex = 2;
            this.ordersButton.Text = "Orders";
            this.ordersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ordersButton.UseVisualStyleBackColor = true;
            this.ordersButton.Click += new System.EventHandler(this.ordersButton_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardButton.FlatAppearance.BorderSize = 0;
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.dashboardButton.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.dashboardButton.IconColor = System.Drawing.Color.Gainsboro;
            this.dashboardButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dashboardButton.IconSize = 32;
            this.dashboardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.Location = new System.Drawing.Point(0, 100);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.dashboardButton.Size = new System.Drawing.Size(250, 50);
            this.dashboardButton.TabIndex = 1;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(250, 100);
            this.logoPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.headerPanel.Controls.Add(this.label1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(250, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(814, 60);
            this.headerPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 15, 10, 10);
            this.label1.Size = new System.Drawing.Size(195, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(250, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 2);
            this.panel2.TabIndex = 2;
            // 
            // childFormPanel
            // 
            this.childFormPanel.BackColor = System.Drawing.SystemColors.Control;
            this.childFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childFormPanel.Location = new System.Drawing.Point(250, 62);
            this.childFormPanel.Name = "childFormPanel";
            this.childFormPanel.Size = new System.Drawing.Size(814, 614);
            this.childFormPanel.TabIndex = 3;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 676);
            this.Controls.Add(this.childFormPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidemenuPanel);
            this.Name = "MainWindowForm";
            this.Text = "MainWindowForm";
            this.sidemenuPanel.ResumeLayout(false);
            this.customersSubmenuPanel.ResumeLayout(false);
            this.ordersSubmenuPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidemenuPanel;
        private FontAwesome.Sharp.IconButton dashboardButton;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel ordersSubmenuPanel;
        private FontAwesome.Sharp.IconButton listOrdersButton;
        private FontAwesome.Sharp.IconButton newOrderButton;
        private FontAwesome.Sharp.IconButton ordersButton;
        private FontAwesome.Sharp.IconButton reportButton;
        private FontAwesome.Sharp.IconButton productsButton;
        private System.Windows.Forms.Panel customersSubmenuPanel;
        private FontAwesome.Sharp.IconButton listCustomersButton;
        private FontAwesome.Sharp.IconButton addCustomerButton;
        private FontAwesome.Sharp.IconButton customersButton;
        private FontAwesome.Sharp.IconButton logoutButton;
        private System.Windows.Forms.Panel spacingPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel childFormPanel;
    }
}