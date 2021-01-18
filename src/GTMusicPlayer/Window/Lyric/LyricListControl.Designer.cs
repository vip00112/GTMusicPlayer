namespace GTMusicPlayer
{
    partial class LyricListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LyricListControl));
            this.stackPanel = new GTMusicPlayer.StackPanel();
            this.metroContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.menuItem_sync = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_minus01 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_plus01 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_minus05 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_plus05 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_minus10 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_plus10 = new System.Windows.Forms.ToolStripMenuItem();
            this.metroContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackPanel
            // 
            resources.ApplyResources(this.stackPanel, "stackPanel");
            this.stackPanel.ContextMenuStrip = this.metroContextMenu;
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
            // 
            // metroContextMenu
            // 
            this.metroContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_sync});
            this.metroContextMenu.Name = "metroContextMenu";
            resources.ApplyResources(this.metroContextMenu, "metroContextMenu");
            this.metroContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.metroContextMenu_Opening);
            // 
            // menuItem_sync
            // 
            this.menuItem_sync.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_minus01,
            this.menuItem_plus01,
            this.menuItem_minus05,
            this.menuItem_plus05,
            this.menuItem_minus10,
            this.menuItem_plus10});
            this.menuItem_sync.Name = "menuItem_sync";
            resources.ApplyResources(this.menuItem_sync, "menuItem_sync");
            // 
            // menuItem_minus01
            // 
            this.menuItem_minus01.Name = "menuItem_minus01";
            resources.ApplyResources(this.menuItem_minus01, "menuItem_minus01");
            this.menuItem_minus01.Click += new System.EventHandler(this.menuItem_minus01_Click);
            // 
            // menuItem_plus01
            // 
            this.menuItem_plus01.Name = "menuItem_plus01";
            resources.ApplyResources(this.menuItem_plus01, "menuItem_plus01");
            this.menuItem_plus01.Click += new System.EventHandler(this.menuItem_plus01_Click);
            // 
            // menuItem_minus05
            // 
            this.menuItem_minus05.Name = "menuItem_minus05";
            resources.ApplyResources(this.menuItem_minus05, "menuItem_minus05");
            this.menuItem_minus05.Click += new System.EventHandler(this.menuItem_minus05_Click);
            // 
            // menuItem_plus05
            // 
            this.menuItem_plus05.Name = "menuItem_plus05";
            resources.ApplyResources(this.menuItem_plus05, "menuItem_plus05");
            this.menuItem_plus05.Click += new System.EventHandler(this.menuItem_plus05_Click);
            // 
            // menuItem_minus10
            // 
            this.menuItem_minus10.Name = "menuItem_minus10";
            resources.ApplyResources(this.menuItem_minus10, "menuItem_minus10");
            this.menuItem_minus10.Click += new System.EventHandler(this.menuItem_minus10_Click);
            // 
            // menuItem_plus10
            // 
            this.menuItem_plus10.Name = "menuItem_plus10";
            resources.ApplyResources(this.menuItem_plus10, "menuItem_plus10");
            this.menuItem_plus10.Click += new System.EventHandler(this.menuItem_plus10_Click);
            // 
            // LyricListControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackPanel);
            this.Name = "LyricListControl";
            this.metroContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private StackPanel stackPanel;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem_sync;
        private System.Windows.Forms.ToolStripMenuItem menuItem_minus01;
        private System.Windows.Forms.ToolStripMenuItem menuItem_plus01;
        private System.Windows.Forms.ToolStripMenuItem menuItem_minus05;
        private System.Windows.Forms.ToolStripMenuItem menuItem_plus05;
        private System.Windows.Forms.ToolStripMenuItem menuItem_minus10;
        private System.Windows.Forms.ToolStripMenuItem menuItem_plus10;
    }
}
