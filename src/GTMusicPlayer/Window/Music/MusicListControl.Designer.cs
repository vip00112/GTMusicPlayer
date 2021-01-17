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
            this.metroLabel_delete = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_add = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_count = new MetroFramework.Controls.MetroLabel();
            this.metroContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.menuItem_add = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_deleteSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_deleteWithoutSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_deleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_editLyric = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_editTag = new System.Windows.Forms.ToolStripMenuItem();
            this.stackPanel = new GTMusicPlayer.StackPanel();
            this.metroPanel_bottom.SuspendLayout();
            this.metroContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel_bottom
            // 
            resources.ApplyResources(this.metroPanel_bottom, "metroPanel_bottom");
            this.metroPanel_bottom.Controls.Add(this.metroLabel_delete);
            this.metroPanel_bottom.Controls.Add(this.metroLabel_add);
            this.metroPanel_bottom.Controls.Add(this.metroLabel_count);
            this.metroPanel_bottom.HorizontalScrollbarBarColor = true;
            this.metroPanel_bottom.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_bottom.HorizontalScrollbarSize = 10;
            this.metroPanel_bottom.Name = "metroPanel_bottom";
            this.metroPanel_bottom.VerticalScrollbarBarColor = true;
            this.metroPanel_bottom.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_bottom.VerticalScrollbarSize = 10;
            // 
            // metroLabel_delete
            // 
            resources.ApplyResources(this.metroLabel_delete, "metroLabel_delete");
            this.metroLabel_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_delete.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_delete.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_delete.Name = "metroLabel_delete";
            this.metroLabel_delete.Click += new System.EventHandler(this.metroLabel_delete_Click);
            // 
            // metroLabel_add
            // 
            resources.ApplyResources(this.metroLabel_add, "metroLabel_add");
            this.metroLabel_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_add.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_add.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_add.Name = "metroLabel_add";
            this.metroLabel_add.Click += new System.EventHandler(this.metroLabel_add_Click);
            // 
            // metroLabel_count
            // 
            resources.ApplyResources(this.metroLabel_count, "metroLabel_count");
            this.metroLabel_count.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroLabel_count.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_count.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel_count.Name = "metroLabel_count";
            // 
            // metroContextMenu
            // 
            resources.ApplyResources(this.metroContextMenu, "metroContextMenu");
            this.metroContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_add,
            this.deleteToolStripMenuItem,
            this.menuItem_editLyric,
            this.menuItem_editTag});
            this.metroContextMenu.Name = "metroContextMenu";
            this.metroContextMenu.UseStyleColors = true;
            this.metroContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.metroContextMenu_Opening);
            // 
            // menuItem_add
            // 
            resources.ApplyResources(this.menuItem_add, "menuItem_add");
            this.menuItem_add.Name = "menuItem_add";
            this.menuItem_add.Click += new System.EventHandler(this.menuItem_add_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_deleteSelected,
            this.menuItem_deleteWithoutSelected,
            this.menuItem_deleteAll});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            // 
            // menuItem_deleteSelected
            // 
            resources.ApplyResources(this.menuItem_deleteSelected, "menuItem_deleteSelected");
            this.menuItem_deleteSelected.Name = "menuItem_deleteSelected";
            this.menuItem_deleteSelected.Click += new System.EventHandler(this.menuItem_deleteSelected_Click);
            // 
            // menuItem_deleteWithoutSelected
            // 
            resources.ApplyResources(this.menuItem_deleteWithoutSelected, "menuItem_deleteWithoutSelected");
            this.menuItem_deleteWithoutSelected.Name = "menuItem_deleteWithoutSelected";
            this.menuItem_deleteWithoutSelected.Click += new System.EventHandler(this.menuItem_deleteWithoutSelected_Click);
            // 
            // menuItem_deleteAll
            // 
            resources.ApplyResources(this.menuItem_deleteAll, "menuItem_deleteAll");
            this.menuItem_deleteAll.Name = "menuItem_deleteAll";
            this.menuItem_deleteAll.Click += new System.EventHandler(this.menuItem_deleteAll_Click);
            // 
            // menuItem_editLyric
            // 
            resources.ApplyResources(this.menuItem_editLyric, "menuItem_editLyric");
            this.menuItem_editLyric.Name = "menuItem_editLyric";
            this.menuItem_editLyric.Click += new System.EventHandler(this.menuItem_editLyric_Click);
            // 
            // menuItem_editTag
            // 
            resources.ApplyResources(this.menuItem_editTag, "menuItem_editTag");
            this.menuItem_editTag.Name = "menuItem_editTag";
            this.menuItem_editTag.Click += new System.EventHandler(this.menuItem_editTag_Click);
            // 
            // stackPanel
            // 
            resources.ApplyResources(this.stackPanel, "stackPanel");
            this.stackPanel.AllowDrop = true;
            this.stackPanel.EmptySpaceBetween = 15;
            this.stackPanel.EmptySpaceLeft = 5;
            this.stackPanel.EmptySpaceTop = 5;
            this.stackPanel.HorizontalScrollbar = true;
            this.stackPanel.HorizontalScrollbarBarColor = false;
            this.stackPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.stackPanel.HorizontalScrollbarSize = 5;
            this.stackPanel.IsNotMove = false;
            this.stackPanel.Name = "stackPanel";
            this.stackPanel.ScrollMoveControlCount = 0;
            this.stackPanel.UseStyleColors = true;
            this.stackPanel.VerticalScrollbar = true;
            this.stackPanel.VerticalScrollbarBarColor = true;
            this.stackPanel.VerticalScrollbarHighlightOnWheel = false;
            this.stackPanel.VerticalScrollbarSize = 5;
            this.stackPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.stackPanel_DragDrop);
            this.stackPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.stackPanel_DragEnter);
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
        private MetroFramework.Controls.MetroLabel metroLabel_add;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem_add;
        private MetroFramework.Controls.MetroLabel metroLabel_delete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_deleteSelected;
        private System.Windows.Forms.ToolStripMenuItem menuItem_deleteWithoutSelected;
        private System.Windows.Forms.ToolStripMenuItem menuItem_deleteAll;
        private System.Windows.Forms.ToolStripMenuItem menuItem_editLyric;
        private System.Windows.Forms.ToolStripMenuItem menuItem_editTag;
    }
}
