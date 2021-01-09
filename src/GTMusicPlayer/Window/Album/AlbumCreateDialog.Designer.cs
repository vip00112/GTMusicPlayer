namespace GTMusicPlayer
{
    partial class AlbumCreateDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumCreateDialog));
            this.metroTextBox_name = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox_description = new MetroFramework.Controls.MetroTextBox();
            this.metroButton_ok = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroTextBox_name
            // 
            // 
            // 
            // 
            this.metroTextBox_name.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.metroTextBox_name.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.metroTextBox_name.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.metroTextBox_name.CustomButton.Name = "";
            this.metroTextBox_name.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.metroTextBox_name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_name.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.metroTextBox_name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_name.CustomButton.UseSelectable = true;
            this.metroTextBox_name.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.metroTextBox_name.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox_name, "metroTextBox_name");
            this.metroTextBox_name.MaxLength = 32767;
            this.metroTextBox_name.Name = "metroTextBox_name";
            this.metroTextBox_name.PasswordChar = '\0';
            this.metroTextBox_name.PromptText = "Name";
            this.metroTextBox_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_name.SelectedText = "";
            this.metroTextBox_name.SelectionLength = 0;
            this.metroTextBox_name.SelectionStart = 0;
            this.metroTextBox_name.ShortcutsEnabled = true;
            this.metroTextBox_name.UseSelectable = true;
            this.metroTextBox_name.UseStyleColors = true;
            this.metroTextBox_name.WaterMark = "Name";
            this.metroTextBox_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox_description
            // 
            // 
            // 
            // 
            this.metroTextBox_description.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.metroTextBox_description.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
            this.metroTextBox_description.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.metroTextBox_description.CustomButton.Name = "";
            this.metroTextBox_description.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.metroTextBox_description.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_description.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.metroTextBox_description.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_description.CustomButton.UseSelectable = true;
            this.metroTextBox_description.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
            this.metroTextBox_description.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox_description, "metroTextBox_description");
            this.metroTextBox_description.MaxLength = 32767;
            this.metroTextBox_description.Name = "metroTextBox_description";
            this.metroTextBox_description.PasswordChar = '\0';
            this.metroTextBox_description.PromptText = "Description";
            this.metroTextBox_description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_description.SelectedText = "";
            this.metroTextBox_description.SelectionLength = 0;
            this.metroTextBox_description.SelectionStart = 0;
            this.metroTextBox_description.ShortcutsEnabled = true;
            this.metroTextBox_description.UseSelectable = true;
            this.metroTextBox_description.UseStyleColors = true;
            this.metroTextBox_description.WaterMark = "Description";
            this.metroTextBox_description.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_description.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton_ok
            // 
            resources.ApplyResources(this.metroButton_ok, "metroButton_ok");
            this.metroButton_ok.Name = "metroButton_ok";
            this.metroButton_ok.UseSelectable = true;
            this.metroButton_ok.Click += new System.EventHandler(this.metroButton_ok_Click);
            // 
            // AlbumCreateDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroButton_ok);
            this.Controls.Add(this.metroTextBox_description);
            this.Controls.Add(this.metroTextBox_name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlbumCreateDialog";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AlbumCreateDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextBox_name;
        private MetroFramework.Controls.MetroTextBox metroTextBox_description;
        private MetroFramework.Controls.MetroButton metroButton_ok;
    }
}