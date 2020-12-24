namespace GTMusicPlayer
{
    partial class MusicListControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicListControl));
            this.metroPanel_bottom = new MetroFramework.Controls.MetroPanel();
            this.metroLabel_file = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_count = new MetroFramework.Controls.MetroLabel();
            this.stackPanel = new GTMusicPlayer.StackPanel();
            this.metroContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.menuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.metroPanel_bottom.SuspendLayout();
            this.metroContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel_bottom
            // 
            this.metroPanel_bottom.Controls.Add(this.metroLabel_file);
            this.metroPanel_bottom.Controls.Add(this.metroLabel_count);
            resources.ApplyResources(this.metroPanel_bottom, "metroPanel_bottom");
            this.metroPanel_bottom.HorizontalScrollbarBarColor = true;
            this.metroPanel_bottom.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_bottom.HorizontalScrollbarSize = 10;
            this.metroPanel_bottom.Name = "metroPanel_bottom";
            this.metroPanel_bottom.VerticalScrollbarBarColor = true;
            this.metroPanel_bottom.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_bottom.VerticalScrollbarSize = 10;
            // 
            // metroLabel_file
            // 
            this.metroLabel_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_file.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_file.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            resources.ApplyResources(this.metroLabel_file, "metroLabel_file");
            this.metroLabel_file.Name = "metroLabel_file";
            this.metroLabel_file.Click += new System.EventHandler(this.metroLabel_file_Click);
            // 
            // metroLabel_count
            // 
            resources.ApplyResources(this.metroLabel_count, "metroLabel_count");
            this.metroLabel_count.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroLabel_count.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_count.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel_count.Name = "metroLabel_count";
            // 
            // stackPanel
            // 
            this.stackPanel.AllowDrop = true;
            resources.ApplyResources(this.stackPanel, "stackPanel");
            this.stackPanel.EmptySpaceBetween = 15;
            this.stackPanel.EmptySpaceLeft = 5;
            this.stackPanel.EmptySpaceTop = 5;
            this.stackPanel.HorizontalScrollbar = true;
            this.stackPanel.HorizontalScrollbarBarColor = false;
            this.stackPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.stackPanel.HorizontalScrollbarSize = 5;
            this.stackPanel.Name = "stackPanel";
            this.stackPanel.UseStyleColors = true;
            this.stackPanel.VerticalScrollbar = true;
            this.stackPanel.VerticalScrollbarBarColor = true;
            this.stackPanel.VerticalScrollbarHighlightOnWheel = false;
            this.stackPanel.VerticalScrollbarSize = 5;
            this.stackPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.stackPanel_DragDrop);
            this.stackPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.stackPanel_DragEnter);
            // 
            // metroContextMenu
            // 
            this.metroContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_file});
            this.metroContextMenu.Name = "metroContextMenu";
            resources.ApplyResources(this.metroContextMenu, "metroContextMenu");
            this.metroContextMenu.UseStyleColors = true;
            this.metroContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.metroContextMenu_Opening);
            // 
            // menuItem_file
            // 
            this.menuItem_file.Name = "menuItem_file";
            resources.ApplyResources(this.menuItem_file, "menuItem_file");
            this.menuItem_file.Click += new System.EventHandler(this.menuItem_file_Click);
            // 
            // MusicListControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.metroContextMenu;
            this.Controls.Add(this.stackPanel);
            this.Controls.Add(this.metroPanel_bottom);
            this.Name = "MusicListControl";
            this.metroPanel_bottom.ResumeLayout(false);
            this.metroPanel_bottom.PerformLayout();
            this.metroContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel_bottom;
        private StackPanel stackPanel;
        private MetroFramework.Controls.MetroLabel metroLabel_count;
        private MetroFramework.Controls.MetroLabel metroLabel_file;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem_file;
    }
}
