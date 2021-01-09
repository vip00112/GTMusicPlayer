namespace GTMusicPlayer
{
    partial class MiniForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniForm));
            this.metroLabel_title = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_next = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_prev = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lyricListControl = new GTMusicPlayer.LyricListControl();
            this.SuspendLayout();
            // 
            // metroLabel_title
            // 
            this.metroLabel_title.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_title.Location = new System.Drawing.Point(85, 30);
            this.metroLabel_title.Name = "metroLabel_title";
            this.metroLabel_title.Size = new System.Drawing.Size(214, 19);
            this.metroLabel_title.TabIndex = 1;
            this.metroLabel_title.Tag = "";
            this.metroLabel_title.Text = "Title";
            this.metroLabel_title.UseStyleColors = true;
            // 
            // metroLabel_next
            // 
            this.metroLabel_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_next.Enabled = false;
            this.metroLabel_next.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_next.Location = new System.Drawing.Point(62, 30);
            this.metroLabel_next.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel_next.Name = "metroLabel_next";
            this.metroLabel_next.Size = new System.Drawing.Size(20, 19);
            this.metroLabel_next.TabIndex = 8;
            this.metroLabel_next.Text = "▶I";
            this.metroLabel_next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel_next.UseStyleColors = true;
            // 
            // metroLabel_prev
            // 
            this.metroLabel_prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_prev.Enabled = false;
            this.metroLabel_prev.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_prev.Location = new System.Drawing.Point(20, 30);
            this.metroLabel_prev.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel_prev.Name = "metroLabel_prev";
            this.metroLabel_prev.Size = new System.Drawing.Size(20, 19);
            this.metroLabel_prev.TabIndex = 9;
            this.metroLabel_prev.Text = "I◀";
            this.metroLabel_prev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel_prev.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel1.Enabled = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(42, 30);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(20, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "▶";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseStyleColors = true;
            // 
            // lyricListControl
            // 
            this.lyricListControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lyricListControl.Location = new System.Drawing.Point(20, 52);
            this.lyricListControl.Name = "lyricListControl";
            this.lyricListControl.Size = new System.Drawing.Size(279, 44);
            this.lyricListControl.TabIndex = 10;
            this.lyricListControl.UseSelectable = true;
            // 
            // MiniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 119);
            this.Controls.Add(this.lyricListControl);
            this.Controls.Add(this.metroLabel_next);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel_prev);
            this.Controls.Add(this.metroLabel_title);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "MiniForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "GTMusicPlayer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MiniForm_FormClosing);
            this.Load += new System.EventHandler(this.MiniForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel_title;
        private MetroFramework.Controls.MetroLabel metroLabel_next;
        private MetroFramework.Controls.MetroLabel metroLabel_prev;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private LyricListControl lyricListControl;
    }
}