namespace GTMusicPlayer
{
    partial class MusicListItemControl
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
            this.metroLabel_title = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_singer = new MetroFramework.Controls.MetroLabel();
            this.metroTile_play = new MetroFramework.Controls.MetroTile();
            this.metroLabel_durationTime = new MetroFramework.Controls.MetroLabel();
            this.metroToolTip = new MetroFramework.Components.MetroToolTip();
            this.metroLabel_delete = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_move = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel_title
            // 
            this.metroLabel_title.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_title.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_title.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_title.ForeColor = System.Drawing.Color.White;
            this.metroLabel_title.Location = new System.Drawing.Point(8, 0);
            this.metroLabel_title.Name = "metroLabel_title";
            this.metroLabel_title.Size = new System.Drawing.Size(203, 15);
            this.metroLabel_title.TabIndex = 0;
            this.metroLabel_title.Text = "Title";
            this.metroLabel_title.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.metroLabel_MouseDoubleClick);
            this.metroLabel_title.MouseEnter += new System.EventHandler(this.metroLabel_title_MouseEnter);
            this.metroLabel_title.MouseLeave += new System.EventHandler(this.metroLabel_title_MouseLeave);
            // 
            // metroLabel_singer
            // 
            this.metroLabel_singer.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_singer.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_singer.ForeColor = System.Drawing.Color.White;
            this.metroLabel_singer.Location = new System.Drawing.Point(8, 15);
            this.metroLabel_singer.Name = "metroLabel_singer";
            this.metroLabel_singer.Size = new System.Drawing.Size(178, 15);
            this.metroLabel_singer.TabIndex = 0;
            this.metroLabel_singer.Text = "Singer";
            this.metroLabel_singer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.metroLabel_MouseDoubleClick);
            // 
            // metroTile_play
            // 
            this.metroTile_play.ActiveControl = null;
            this.metroTile_play.Enabled = false;
            this.metroTile_play.Location = new System.Drawing.Point(0, 0);
            this.metroTile_play.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.metroTile_play.Name = "metroTile_play";
            this.metroTile_play.PaintTileCount = false;
            this.metroTile_play.Size = new System.Drawing.Size(5, 30);
            this.metroTile_play.TabIndex = 1;
            this.metroTile_play.UseSelectable = true;
            this.metroTile_play.UseStyleColors = true;
            this.metroTile_play.Visible = false;
            // 
            // metroLabel_durationTime
            // 
            this.metroLabel_durationTime.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_durationTime.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_durationTime.ForeColor = System.Drawing.Color.White;
            this.metroLabel_durationTime.Location = new System.Drawing.Point(189, 15);
            this.metroLabel_durationTime.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel_durationTime.Name = "metroLabel_durationTime";
            this.metroLabel_durationTime.Size = new System.Drawing.Size(40, 15);
            this.metroLabel_durationTime.TabIndex = 0;
            this.metroLabel_durationTime.Text = "00:00";
            this.metroLabel_durationTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.metroLabel_durationTime.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.metroLabel_MouseDoubleClick);
            // 
            // metroToolTip
            // 
            this.metroToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip.StyleManager = null;
            this.metroToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel_delete
            // 
            this.metroLabel_delete.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_delete.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_delete.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_delete.ForeColor = System.Drawing.Color.White;
            this.metroLabel_delete.Location = new System.Drawing.Point(214, 0);
            this.metroLabel_delete.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel_delete.Name = "metroLabel_delete";
            this.metroLabel_delete.Size = new System.Drawing.Size(15, 15);
            this.metroLabel_delete.TabIndex = 0;
            this.metroLabel_delete.Text = "x";
            this.metroLabel_delete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel_delete.Click += new System.EventHandler(this.metroLabel_delete_Click);
            // 
            // metroLabel_move
            // 
            this.metroLabel_move.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_move.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.metroLabel_move.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_move.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_move.ForeColor = System.Drawing.Color.White;
            this.metroLabel_move.Location = new System.Drawing.Point(229, 0);
            this.metroLabel_move.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel_move.Name = "metroLabel_move";
            this.metroLabel_move.Size = new System.Drawing.Size(15, 30);
            this.metroLabel_move.TabIndex = 0;
            this.metroLabel_move.Text = "≡";
            this.metroLabel_move.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel_move.MouseDown += new System.Windows.Forms.MouseEventHandler(this.metroLabel_move_MouseDown);
            this.metroLabel_move.MouseMove += new System.Windows.Forms.MouseEventHandler(this.metroLabel_move_MouseMove);
            this.metroLabel_move.MouseUp += new System.Windows.Forms.MouseEventHandler(this.metroLabel_move_MouseUp);
            // 
            // MusicListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTile_play);
            this.Controls.Add(this.metroLabel_move);
            this.Controls.Add(this.metroLabel_delete);
            this.Controls.Add(this.metroLabel_durationTime);
            this.Controls.Add(this.metroLabel_singer);
            this.Controls.Add(this.metroLabel_title);
            this.Name = "MusicListItemControl";
            this.Size = new System.Drawing.Size(244, 30);
            this.UseStyleColors = true;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel_title;
        private MetroFramework.Controls.MetroLabel metroLabel_singer;
        private MetroFramework.Controls.MetroTile metroTile_play;
        private MetroFramework.Controls.MetroLabel metroLabel_durationTime;
        private MetroFramework.Components.MetroToolTip metroToolTip;
        private MetroFramework.Controls.MetroLabel metroLabel_delete;
        private MetroFramework.Controls.MetroLabel metroLabel_move;
    }
}
