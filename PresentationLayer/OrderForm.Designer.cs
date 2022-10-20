
namespace PoppelOrderingSystem.PresentationLayer
{
    partial class OrderForm
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
            this.orderTabControl = new System.Windows.Forms.TabControl();
            this.addItemsTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.orderItemsTab = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.prodGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.instockLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.filterBox = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.viewOrder = new FontAwesome.Sharp.IconButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.addToOrderButton = new System.Windows.Forms.Button();
            this.viewOrderButton = new System.Windows.Forms.Button();
            this.orderTabControl.SuspendLayout();
            this.addItemsTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodGridView)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderTabControl
            // 
            this.orderTabControl.Controls.Add(this.addItemsTab);
            this.orderTabControl.Controls.Add(this.orderItemsTab);
            this.orderTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderTabControl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderTabControl.Location = new System.Drawing.Point(0, 0);
            this.orderTabControl.Name = "orderTabControl";
            this.orderTabControl.SelectedIndex = 0;
            this.orderTabControl.Size = new System.Drawing.Size(800, 561);
            this.orderTabControl.TabIndex = 0;
            // 
            // addItemsTab
            // 
            this.addItemsTab.Controls.Add(this.panel6);
            this.addItemsTab.Controls.Add(this.panel2);
            this.addItemsTab.Controls.Add(this.panel1);
            this.addItemsTab.Location = new System.Drawing.Point(4, 30);
            this.addItemsTab.Name = "addItemsTab";
            this.addItemsTab.Padding = new System.Windows.Forms.Padding(3);
            this.addItemsTab.Size = new System.Drawing.Size(792, 527);
            this.addItemsTab.TabIndex = 0;
            this.addItemsTab.Text = "Add Items";
            this.addItemsTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 351);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.prodGridView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.panel4.Size = new System.Drawing.Size(786, 179);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 60);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.filterBox);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.iconPictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panel5.Size = new System.Drawing.Size(480, 60);
            this.panel5.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.iconPictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 30;
            this.iconPictureBox1.Location = new System.Drawing.Point(20, 15);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 30);
            this.iconPictureBox1.TabIndex = 6;
            this.iconPictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 0);
            this.panel1.Size = new System.Drawing.Size(786, 42);
            this.panel1.TabIndex = 0;
            // 
            // orderItemsTab
            // 
            this.orderItemsTab.Location = new System.Drawing.Point(4, 30);
            this.orderItemsTab.Name = "orderItemsTab";
            this.orderItemsTab.Padding = new System.Windows.Forms.Padding(3);
            this.orderItemsTab.Size = new System.Drawing.Size(792, 416);
            this.orderItemsTab.TabIndex = 1;
            this.orderItemsTab.Text = "Order Items";
            this.orderItemsTab.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tableLayoutPanel1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 239);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(20);
            this.panel9.Size = new System.Drawing.Size(786, 112);
            this.panel9.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.24883F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.75117F));
            this.tableLayoutPanel1.Controls.Add(this.priceLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.instockLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.itemLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(746, 72);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selected item:";
            // 
            // prodGridView
            // 
            this.prodGridView.AllowUserToAddRows = false;
            this.prodGridView.AllowUserToDeleteRows = false;
            this.prodGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.prodGridView.Location = new System.Drawing.Point(20, 0);
            this.prodGridView.MultiSelect = false;
            this.prodGridView.Name = "prodGridView";
            this.prodGridView.ReadOnly = true;
            this.prodGridView.RowTemplate.ReadOnly = true;
            this.prodGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prodGridView.Size = new System.Drawing.Size(746, 175);
            this.prodGridView.TabIndex = 1;
            this.prodGridView.SelectionChanged += new System.EventHandler(this.prodGridView_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "In Stock:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Price:";
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(146, 0);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(41, 21);
            this.itemLabel.TabIndex = 3;
            this.itemLabel.Text = "item";
            // 
            // instockLabel
            // 
            this.instockLabel.AutoSize = true;
            this.instockLabel.Location = new System.Drawing.Point(146, 26);
            this.instockLabel.Name = "instockLabel";
            this.instockLabel.Size = new System.Drawing.Size(41, 21);
            this.instockLabel.TabIndex = 4;
            this.instockLabel.Text = "item";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(146, 52);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(41, 20);
            this.priceLabel.TabIndex = 5;
            this.priceLabel.Text = "item";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.searchBox);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(52, 15);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(188, 30);
            this.panel7.TabIndex = 8;
            // 
            // searchBox
            // 
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(188, 29);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(240, 15);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(19, 30);
            this.panel10.TabIndex = 9;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(259, 15);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(60, 30);
            this.panel8.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(55, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filter";
            // 
            // filterBox
            // 
            this.filterBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.filterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterBox.FormattingEnabled = true;
            this.filterBox.Items.AddRange(new object[] {
            "All",
            "In Stock",
            "Out Of Stock"});
            this.filterBox.Location = new System.Drawing.Point(319, 15);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(136, 29);
            this.filterBox.TabIndex = 11;
            this.filterBox.SelectedIndexChanged += new System.EventHandler(this.filterBox_SelectedIndexChanged);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.viewOrder);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(480, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(0, 0, 20, 5);
            this.panel11.Size = new System.Drawing.Size(306, 60);
            this.panel11.TabIndex = 1;
            // 
            // viewOrder
            // 
            this.viewOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.viewOrder.FlatAppearance.BorderSize = 0;
            this.viewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewOrder.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(78)))), ((int)(((byte)(59)))));
            this.viewOrder.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.viewOrder.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(78)))), ((int)(((byte)(59)))));
            this.viewOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.viewOrder.IconSize = 35;
            this.viewOrder.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.viewOrder.Location = new System.Drawing.Point(224, 0);
            this.viewOrder.Name = "viewOrder";
            this.viewOrder.Size = new System.Drawing.Size(62, 55);
            this.viewOrder.TabIndex = 1;
            this.viewOrder.Text = "0";
            this.viewOrder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.viewOrder.UseVisualStyleBackColor = true;
            this.viewOrder.Click += new System.EventHandler(this.viewOrder_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.viewOrderButton);
            this.panel6.Controls.Add(this.addToOrderButton);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 396);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(20);
            this.panel6.Size = new System.Drawing.Size(786, 80);
            this.panel6.TabIndex = 2;
            // 
            // addToOrderButton
            // 
            this.addToOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.addToOrderButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.addToOrderButton.FlatAppearance.BorderSize = 0;
            this.addToOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToOrderButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToOrderButton.ForeColor = System.Drawing.Color.White;
            this.addToOrderButton.Location = new System.Drawing.Point(20, 20);
            this.addToOrderButton.Name = "addToOrderButton";
            this.addToOrderButton.Size = new System.Drawing.Size(175, 40);
            this.addToOrderButton.TabIndex = 3;
            this.addToOrderButton.Text = "Add Item To Order";
            this.addToOrderButton.UseVisualStyleBackColor = false;
            this.addToOrderButton.Click += new System.EventHandler(this.addToOrderButton_Click);
            // 
            // viewOrderButton
            // 
            this.viewOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.viewOrderButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.viewOrderButton.FlatAppearance.BorderSize = 0;
            this.viewOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewOrderButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewOrderButton.ForeColor = System.Drawing.Color.White;
            this.viewOrderButton.Location = new System.Drawing.Point(591, 20);
            this.viewOrderButton.Name = "viewOrderButton";
            this.viewOrderButton.Size = new System.Drawing.Size(175, 40);
            this.viewOrderButton.TabIndex = 4;
            this.viewOrderButton.Text = "View Order";
            this.viewOrderButton.UseVisualStyleBackColor = false;
            this.viewOrderButton.Click += new System.EventHandler(this.viewOrderButton_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.orderTabControl);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.orderTabControl.ResumeLayout(false);
            this.addItemsTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel9.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodGridView)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl orderTabControl;
        private System.Windows.Forms.TabPage addItemsTab;
        private System.Windows.Forms.TabPage orderItemsTab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView prodGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label instockLabel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ComboBox filterBox;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private FontAwesome.Sharp.IconButton viewOrder;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button viewOrderButton;
        private System.Windows.Forms.Button addToOrderButton;
    }
}