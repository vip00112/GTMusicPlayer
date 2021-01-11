namespace GTMusicPlayer
{
    partial class LyricEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LyricEditForm));
            this.metroTextBox_title = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox_singer = new MetroFramework.Controls.MetroTextBox();
            this.metroButton_search = new MetroFramework.Controls.MetroButton();
            this.stackPanel_header = new GTMusicPlayer.StackPanel();
            this.metroButton_save = new MetroFramework.Controls.MetroButton();
            this.metroButton_load = new MetroFramework.Controls.MetroButton();
            this.lyricListControl = new GTMusicPlayer.LyricListControl();
            this.SuspendLayout();
            // 
            // metroTextBox_title
            // 
            // 
            // 
            // 
            this.metroTextBox_title.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.metroTextBox_title.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.metroTextBox_title.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.metroTextBox_title.CustomButton.Name = "";
            this.metroTextBox_title.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.metroTextBox_title.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_title.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.metroTextBox_title.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_title.CustomButton.UseSelectable = true;
            this.metroTextBox_title.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.metroTextBox_title.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox_title, "metroTextBox_title");
            this.metroTextBox_title.MaxLength = 32767;
            this.metroTextBox_title.Name = "metroTextBox_title";
            this.metroTextBox_title.PasswordChar = '\0';
            this.metroTextBox_title.PromptText = "Title";
            this.metroTextBox_title.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_title.SelectedText = "";
            this.metroTextBox_title.SelectionLength = 0;
            this.metroTextBox_title.SelectionStart = 0;
            this.metroTextBox_title.ShortcutsEnabled = true;
            this.metroTextBox_title.UseSelectable = true;
            this.metroTextBox_title.UseStyleColors = true;
            this.metroTextBox_title.WaterMark = "Title";
            this.metroTextBox_title.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_title.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox_singer
            // 
            // 
            // 
            // 
            this.metroTextBox_singer.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.metroTextBox_singer.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
            this.metroTextBox_singer.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.metroTextBox_singer.CustomButton.Name = "";
            this.metroTextBox_singer.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.metroTextBox_singer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_singer.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.metroTextBox_singer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_singer.CustomButton.UseSelectable = true;
            this.metroTextBox_singer.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
            this.metroTextBox_singer.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox_singer, "metroTextBox_singer");
            this.metroTextBox_singer.MaxLength = 32767;
            this.metroTextBox_singer.Name = "metroTextBox_singer";
            this.metroTextBox_singer.PasswordChar = '\0';
            this.metroTextBox_singer.PromptText = "Singer";
            this.metroTextBox_singer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_singer.SelectedText = "";
            this.metroTextBox_singer.SelectionLength = 0;
            this.metroTextBox_singer.SelectionStart = 0;
            this.metroTextBox_singer.ShortcutsEnabled = true;
            this.metroTextBox_singer.UseSelectable = true;
            this.metroTextBox_singer.UseStyleColors = true;
            this.metroTextBox_singer.WaterMark = "Singer";
            this.metroTextBox_singer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_singer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton_search
            // 
            resources.ApplyResources(this.metroButton_search, "metroButton_search");
            this.metroButton_search.Name = "metroButton_search";
            this.metroButton_search.UseSelectable = true;
            this.metroButton_search.Click += new System.EventHandler(this.metroButton_search_Click);
            // 
            // stackPanel_header
            // 
            resources.ApplyResources(this.stackPanel_header, "stackPanel_header");
            this.stackPanel_header.EmptySpaceBetween = 15;
            this.stackPanel_header.EmptySpaceLeft = 5;
            this.stackPanel_header.EmptySpaceTop = 5;
            this.stackPanel_header.HorizontalScrollbar = true;
            this.stackPanel_header.HorizontalScrollbarBarColor = true;
            this.stackPanel_header.HorizontalScrollbarHighlightOnWheel = false;
            this.stackPanel_header.HorizontalScrollbarSize = 5;
            this.stackPanel_header.IsNotMove = false;
            this.stackPanel_header.Name = "stackPanel_header";
            this.stackPanel_header.ScrollMoveControlCount = 0;
            this.stackPanel_header.UseStyleColors = true;
            this.stackPanel_header.VerticalScrollbar = true;
            this.stackPanel_header.VerticalScrollbarBarColor = true;
            this.stackPanel_header.VerticalScrollbarHighlightOnWheel = false;
            this.stackPanel_header.VerticalScrollbarSize = 5;
            // 
            // metroButton_save
            // 
            resources.ApplyResources(this.metroButton_save, "metroButton_save");
            this.metroButton_save.Name = "metroButton_save";
            this.metroButton_save.UseSelectable = true;
            this.metroButton_save.Click += new System.EventHandler(this.metroButton_save_Click);
            // 
            // metroButton_load
            // 
            resources.ApplyResources(this.metroButton_load, "metroButton_load");
            this.metroButton_load.Name = "metroButton_load";
            this.metroButton_load.UseSelectable = true;
            this.metroButton_load.Click += new System.EventHandler(this.metroButton_load_Click);
            // 
            // lyricListControl
            // 
            this.lyricListControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lyricListControl, "lyricListControl");
            this.lyricListControl.Name = "lyricListControl";
            this.lyricListControl.UseSelectable = true;
            // 
            // LyricEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lyricListControl);
            this.Controls.Add(this.metroButton_load);
            this.Controls.Add(this.metroButton_save);
            this.Controls.Add(this.metroButton_search);
            this.Controls.Add(this.stackPanel_header);
            this.Controls.Add(this.metroTextBox_singer);
            this.Controls.Add(this.metroTextBox_title);
            this.MaximizeBox = false;
            this.Name = "LyricEditForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Load += new System.EventHandler(this.LyricEditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextBox_title;
        private MetroFramework.Controls.MetroTextBox metroTextBox_singer;
        private MetroFramework.Controls.MetroButton metroButton_search;
        private StackPanel stackPanel_header;
        private LyricListControl lyricListControl;
        private MetroFramework.Controls.MetroButton metroButton_save;
        private MetroFramework.Controls.MetroButton metroButton_load;
    }
}