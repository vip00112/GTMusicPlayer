namespace GTMusicPlayer
{
    partial class AlbumListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumListControl));
            this.stackPanel = new GTMusicPlayer.StackPanel();
            this.metroPanel_bottom = new MetroFramework.Controls.MetroPanel();
            this.metroLabel_create = new MetroFramework.Controls.MetroLabel();
            this.metroPanel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackPanel
            // 
            resources.ApplyResources(this.stackPanel, "stackPanel");
            this.stackPanel.EmptySpaceBetween = 20;
            this.stackPanel.EmptySpaceLeft = 5;
            this.stackPanel.EmptySpaceTop = 5;
            this.stackPanel.HorizontalScrollbarBarColor = false;
            this.stackPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.stackPanel.HorizontalScrollbarSize = 5;
            this.stackPanel.Name = "stackPanel";
            this.stackPanel.UseStyleColors = true;
            this.stackPanel.VerticalScrollbar = true;
            this.stackPanel.VerticalScrollbarBarColor = true;
            this.stackPanel.VerticalScrollbarHighlightOnWheel = false;
            this.stackPanel.VerticalScrollbarSize = 5;
            // 
            // metroPanel_bottom
            // 
            this.metroPanel_bottom.Controls.Add(this.metroLabel_create);
            resources.ApplyResources(this.metroPanel_bottom, "metroPanel_bottom");
            this.metroPanel_bottom.HorizontalScrollbarBarColor = true;
            this.metroPanel_bottom.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_bottom.HorizontalScrollbarSize = 10;
            this.metroPanel_bottom.Name = "metroPanel_bottom";
            this.metroPanel_bottom.VerticalScrollbarBarColor = true;
            this.metroPanel_bottom.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_bottom.VerticalScrollbarSize = 10;
            // 
            // metroLabel_create
            // 
            resources.ApplyResources(this.metroLabel_create, "metroLabel_create");
            this.metroLabel_create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_create.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_create.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel_create.Name = "metroLabel_create";
            this.metroLabel_create.Click += new System.EventHandler(this.metroLabel_create_Click);
            // 
            // AlbumListControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackPanel);
            this.Controls.Add(this.metroPanel_bottom);
            this.Name = "AlbumListControl";
            this.UseStyleColors = true;
            this.metroPanel_bottom.ResumeLayout(false);
            this.metroPanel_bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private StackPanel stackPanel;
        private MetroFramework.Controls.MetroPanel metroPanel_bottom;
        private MetroFramework.Controls.MetroLabel metroLabel_create;
    }
}
