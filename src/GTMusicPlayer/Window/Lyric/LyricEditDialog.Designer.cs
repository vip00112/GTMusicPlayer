namespace GTMusicPlayer
{
    partial class LyricEditDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LyricEditDialog));
            this.metroTextBox_text = new MetroFramework.Controls.MetroTextBox();
            this.metroButton_ok = new MetroFramework.Controls.MetroButton();
            this.metroTextBox_min = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox_sec = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox_ms = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroTextBox_text
            // 
            // 
            // 
            // 
            this.metroTextBox_text.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.metroTextBox_text.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.metroTextBox_text.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.metroTextBox_text.CustomButton.Name = "";
            this.metroTextBox_text.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.metroTextBox_text.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_text.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.metroTextBox_text.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_text.CustomButton.UseSelectable = true;
            this.metroTextBox_text.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.metroTextBox_text.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox_text, "metroTextBox_text");
            this.metroTextBox_text.MaxLength = 32767;
            this.metroTextBox_text.Multiline = true;
            this.metroTextBox_text.Name = "metroTextBox_text";
            this.metroTextBox_text.PasswordChar = '\0';
            this.metroTextBox_text.PromptText = "Text";
            this.metroTextBox_text.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_text.SelectedText = "";
            this.metroTextBox_text.SelectionLength = 0;
            this.metroTextBox_text.SelectionStart = 0;
            this.metroTextBox_text.ShortcutsEnabled = true;
            this.metroTextBox_text.UseSelectable = true;
            this.metroTextBox_text.UseStyleColors = true;
            this.metroTextBox_text.WaterMark = "Text";
            this.metroTextBox_text.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_text.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton_ok
            // 
            resources.ApplyResources(this.metroButton_ok, "metroButton_ok");
            this.metroButton_ok.Name = "metroButton_ok";
            this.metroButton_ok.UseSelectable = true;
            this.metroButton_ok.Click += new System.EventHandler(this.metroButton_ok_Click);
            // 
            // metroTextBox_min
            // 
            // 
            // 
            // 
            this.metroTextBox_min.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.metroTextBox_min.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
            this.metroTextBox_min.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.metroTextBox_min.CustomButton.Name = "";
            this.metroTextBox_min.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.metroTextBox_min.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_min.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.metroTextBox_min.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_min.CustomButton.UseSelectable = true;
            this.metroTextBox_min.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
            this.metroTextBox_min.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox_min, "metroTextBox_min");
            this.metroTextBox_min.MaxLength = 2;
            this.metroTextBox_min.Name = "metroTextBox_min";
            this.metroTextBox_min.PasswordChar = '\0';
            this.metroTextBox_min.PromptText = "00";
            this.metroTextBox_min.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_min.SelectedText = "";
            this.metroTextBox_min.SelectionLength = 0;
            this.metroTextBox_min.SelectionStart = 0;
            this.metroTextBox_min.ShortcutsEnabled = true;
            this.metroTextBox_min.UseSelectable = true;
            this.metroTextBox_min.UseStyleColors = true;
            this.metroTextBox_min.WaterMark = "00";
            this.metroTextBox_min.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_min.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox_min.TextChanged += new System.EventHandler(this.metroTextBox_TextChanged);
            // 
            // metroTextBox_sec
            // 
            // 
            // 
            // 
            this.metroTextBox_sec.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.metroTextBox_sec.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode2")));
            this.metroTextBox_sec.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.metroTextBox_sec.CustomButton.Name = "";
            this.metroTextBox_sec.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.metroTextBox_sec.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_sec.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
            this.metroTextBox_sec.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_sec.CustomButton.UseSelectable = true;
            this.metroTextBox_sec.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible2")));
            this.metroTextBox_sec.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox_sec, "metroTextBox_sec");
            this.metroTextBox_sec.MaxLength = 2;
            this.metroTextBox_sec.Name = "metroTextBox_sec";
            this.metroTextBox_sec.PasswordChar = '\0';
            this.metroTextBox_sec.PromptText = "00";
            this.metroTextBox_sec.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_sec.SelectedText = "";
            this.metroTextBox_sec.SelectionLength = 0;
            this.metroTextBox_sec.SelectionStart = 0;
            this.metroTextBox_sec.ShortcutsEnabled = true;
            this.metroTextBox_sec.UseSelectable = true;
            this.metroTextBox_sec.UseStyleColors = true;
            this.metroTextBox_sec.WaterMark = "00";
            this.metroTextBox_sec.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_sec.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox_sec.TextChanged += new System.EventHandler(this.metroTextBox_TextChanged);
            // 
            // metroTextBox_ms
            // 
            // 
            // 
            // 
            this.metroTextBox_ms.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.metroTextBox_ms.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode3")));
            this.metroTextBox_ms.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location3")));
            this.metroTextBox_ms.CustomButton.Name = "";
            this.metroTextBox_ms.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size3")));
            this.metroTextBox_ms.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_ms.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex3")));
            this.metroTextBox_ms.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_ms.CustomButton.UseSelectable = true;
            this.metroTextBox_ms.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible3")));
            this.metroTextBox_ms.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox_ms, "metroTextBox_ms");
            this.metroTextBox_ms.MaxLength = 2;
            this.metroTextBox_ms.Name = "metroTextBox_ms";
            this.metroTextBox_ms.PasswordChar = '\0';
            this.metroTextBox_ms.PromptText = "00";
            this.metroTextBox_ms.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_ms.SelectedText = "";
            this.metroTextBox_ms.SelectionLength = 0;
            this.metroTextBox_ms.SelectionStart = 0;
            this.metroTextBox_ms.ShortcutsEnabled = true;
            this.metroTextBox_ms.UseSelectable = true;
            this.metroTextBox_ms.UseStyleColors = true;
            this.metroTextBox_ms.WaterMark = "00";
            this.metroTextBox_ms.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_ms.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox_ms.TextChanged += new System.EventHandler(this.metroTextBox_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // LyricEditDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton_ok);
            this.Controls.Add(this.metroTextBox_ms);
            this.Controls.Add(this.metroTextBox_sec);
            this.Controls.Add(this.metroTextBox_min);
            this.Controls.Add(this.metroTextBox_text);
            this.DisplayHeader = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LyricEditDialog";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.LyricEditDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox metroTextBox_text;
        private MetroFramework.Controls.MetroButton metroButton_ok;
        private MetroFramework.Controls.MetroTextBox metroTextBox_min;
        private MetroFramework.Controls.MetroTextBox metroTextBox_sec;
        private MetroFramework.Controls.MetroTextBox metroTextBox_ms;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}