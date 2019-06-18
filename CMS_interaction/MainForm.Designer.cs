namespace CMS_interaction
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addComputerToCMSButton = new System.Windows.Forms.Button();
            this.addComputerToDomain = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addComputerToCMSButton
            // 
            this.addComputerToCMSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addComputerToCMSButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addComputerToCMSButton.Location = new System.Drawing.Point(12, 12);
            this.addComputerToCMSButton.Name = "addComputerToCMSButton";
            this.addComputerToCMSButton.Size = new System.Drawing.Size(212, 34);
            this.addComputerToCMSButton.TabIndex = 4;
            this.addComputerToCMSButton.Text = "Add Computer To CMS";
            this.addComputerToCMSButton.UseVisualStyleBackColor = true;
            this.addComputerToCMSButton.Click += new System.EventHandler(this.AddComputerToCMSButton_Click);
            // 
            // addComputerToDomain
            // 
            this.addComputerToDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addComputerToDomain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addComputerToDomain.Location = new System.Drawing.Point(12, 52);
            this.addComputerToDomain.Name = "addComputerToDomain";
            this.addComputerToDomain.Size = new System.Drawing.Size(212, 34);
            this.addComputerToDomain.TabIndex = 4;
            this.addComputerToDomain.Text = "Add Computer To Domain";
            this.addComputerToDomain.UseVisualStyleBackColor = true;
            this.addComputerToDomain.Click += new System.EventHandler(this.AddComputerToDomain_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = global::CMS_interaction.Resources.ExitIcon;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(12, 92);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(212, 34);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 136);
            this.Controls.Add(this.addComputerToDomain);
            this.Controls.Add(this.addComputerToCMSButton);
            this.Controls.Add(this.ExitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CMS Interactor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button addComputerToCMSButton;
        private System.Windows.Forms.Button addComputerToDomain;
    }
}