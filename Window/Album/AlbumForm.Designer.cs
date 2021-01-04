namespace GTMusicPlayer
{
    partial class AlbumForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumForm));
            this.musicListControl = new GTMusicPlayer.MusicListControl();
            this.albumListControl = new GTMusicPlayer.AlbumListControl();
            this.SuspendLayout();
            // 
            // musicListControl
            // 
            this.musicListControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.musicListControl, "musicListControl");
            this.musicListControl.Name = "musicListControl";
            this.musicListControl.TabStop = false;
            this.musicListControl.UseSelectable = true;
            // 
            // albumListControl
            // 
            resources.ApplyResources(this.albumListControl, "albumListControl");
            this.albumListControl.Name = "albumListControl";
            this.albumListControl.TabStop = false;
            this.albumListControl.UseSelectable = true;
            this.albumListControl.UseStyleColors = true;
            // 
            // AlbumForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.albumListControl);
            this.Controls.Add(this.musicListControl);
            this.MaximizeBox = false;
            this.Name = "AlbumForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Load += new System.EventHandler(this.AlbumForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AlbumForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private MusicListControl musicListControl;
        private AlbumListControl albumListControl;
    }
}