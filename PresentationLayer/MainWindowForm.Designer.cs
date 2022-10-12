
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
            this.SuspendLayout();
            // 
            // sidemenuPanel
            // 
            this.sidemenuPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sidemenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidemenuPanel.Location = new System.Drawing.Point(0, 0);
            this.sidemenuPanel.Name = "sidemenuPanel";
            this.sidemenuPanel.Size = new System.Drawing.Size(200, 461);
            this.sidemenuPanel.TabIndex = 0;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.sidemenuPanel);
            this.Name = "MainWindowForm";
            this.Text = "MainWindowForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidemenuPanel;
    }
}