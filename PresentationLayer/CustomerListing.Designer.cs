
namespace PoppelOrderingSystem.PresentationLayer
{
    partial class CustomerListing
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
            this.customerDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDataGridView
            // 
            this.customerDataGridView.AllowUserToOrderColumns = true;
            this.customerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGridView.Location = new System.Drawing.Point(12, 38);
            this.customerDataGridView.Name = "customerDataGridView";
            this.customerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGridView.Size = new System.Drawing.Size(776, 258);
            this.customerDataGridView.TabIndex = 0;
            // 
            // CustomerListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 308);
            this.Controls.Add(this.customerDataGridView);
            this.Name = "CustomerListing";
            this.Text = "CustomerListing";
            this.Load += new System.EventHandler(this.CustomerListing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customerDataGridView;
    }
}