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
            this.stackPanel = new GTMusicPlayer.StackPanel();
            this.SuspendLayout();
            // 
            // stackPanel
            // 
            this.stackPanel.AutoScroll = true;
            this.stackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel.EmptySpaceBetween = 15;
            this.stackPanel.EmptySpaceLeft = 5;
            this.stackPanel.EmptySpaceTop = 5;
            this.stackPanel.HorizontalScrollbar = true;
            this.stackPanel.HorizontalScrollbarBarColor = false;
            this.stackPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.stackPanel.HorizontalScrollbarSize = 5;
            this.stackPanel.Location = new System.Drawing.Point(0, 0);
            this.stackPanel.Name = "stackPanel";
            this.stackPanel.Size = new System.Drawing.Size(265, 365);
            this.stackPanel.TabIndex = 0;
            this.stackPanel.UseStyleColors = true;
            this.stackPanel.VerticalScrollbar = true;
            this.stackPanel.VerticalScrollbarBarColor = true;
            this.stackPanel.VerticalScrollbarHighlightOnWheel = false;
            this.stackPanel.VerticalScrollbarSize = 5;
            // 
            // LyricListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackPanel);
            this.Name = "LyricListControl";
            this.Size = new System.Drawing.Size(265, 365);
            this.ResumeLayout(false);

        }

        #endregion

        private StackPanel stackPanel;
    }
}
