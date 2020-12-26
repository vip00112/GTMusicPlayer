namespace GTMusicPlayer
{
    partial class ALSongLyricHeaderControl
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
            this.metroLabel_singer = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_title = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_id = new MetroFramework.Controls.MetroLabel();
            this.metroTile_select = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroLabel_singer
            // 
            this.metroLabel_singer.BackColor = System.Drawing.SystemColors.Control;
            this.metroLabel_singer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_singer.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_singer.ForeColor = System.Drawing.Color.White;
            this.metroLabel_singer.Location = new System.Drawing.Point(8, 30);
            this.metroLabel_singer.Name = "metroLabel_singer";
            this.metroLabel_singer.Size = new System.Drawing.Size(150, 15);
            this.metroLabel_singer.TabIndex = 1;
            this.metroLabel_singer.Text = "Singer";
            this.metroLabel_singer.Click += new System.EventHandler(this.metroLabel_Click);
            // 
            // metroLabel_title
            // 
            this.metroLabel_title.BackColor = System.Drawing.SystemColors.Control;
            this.metroLabel_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_title.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_title.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_title.ForeColor = System.Drawing.Color.White;
            this.metroLabel_title.Location = new System.Drawing.Point(8, 15);
            this.metroLabel_title.Name = "metroLabel_title";
            this.metroLabel_title.Size = new System.Drawing.Size(150, 15);
            this.metroLabel_title.TabIndex = 2;
            this.metroLabel_title.Text = "Title";
            this.metroLabel_title.Click += new System.EventHandler(this.metroLabel_Click);
            // 
            // metroLabel_id
            // 
            this.metroLabel_id.BackColor = System.Drawing.SystemColors.Control;
            this.metroLabel_id.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_id.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_id.ForeColor = System.Drawing.Color.White;
            this.metroLabel_id.Location = new System.Drawing.Point(8, 0);
            this.metroLabel_id.Name = "metroLabel_id";
            this.metroLabel_id.Size = new System.Drawing.Size(150, 15);
            this.metroLabel_id.TabIndex = 1;
            this.metroLabel_id.Text = "ID";
            this.metroLabel_id.Click += new System.EventHandler(this.metroLabel_Click);
            // 
            // metroTile_select
            // 
            this.metroTile_select.ActiveControl = null;
            this.metroTile_select.Enabled = false;
            this.metroTile_select.Location = new System.Drawing.Point(0, 0);
            this.metroTile_select.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.metroTile_select.Name = "metroTile_select";
            this.metroTile_select.PaintTileCount = false;
            this.metroTile_select.Size = new System.Drawing.Size(5, 45);
            this.metroTile_select.TabIndex = 3;
            this.metroTile_select.UseSelectable = true;
            this.metroTile_select.UseStyleColors = true;
            this.metroTile_select.Visible = false;
            // 
            // ALSongLyricHeaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTile_select);
            this.Controls.Add(this.metroLabel_id);
            this.Controls.Add(this.metroLabel_singer);
            this.Controls.Add(this.metroLabel_title);
            this.Name = "ALSongLyricHeaderControl";
            this.Size = new System.Drawing.Size(158, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel_singer;
        private MetroFramework.Controls.MetroLabel metroLabel_title;
        private MetroFramework.Controls.MetroLabel metroLabel_id;
        private MetroFramework.Controls.MetroTile metroTile_select;
    }
}
