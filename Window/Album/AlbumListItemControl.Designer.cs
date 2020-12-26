namespace GTMusicPlayer
{
    partial class AlbumListItemControl
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
            this.metroTile_select = new MetroFramework.Controls.MetroTile();
            this.metroLabel_delete = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_description = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_name = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_createdOn = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_edit = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
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
            this.metroTile_select.TabIndex = 2;
            this.metroTile_select.UseSelectable = true;
            this.metroTile_select.UseStyleColors = true;
            this.metroTile_select.Visible = false;
            // 
            // metroLabel_delete
            // 
            this.metroLabel_delete.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_delete.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_delete.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_delete.ForeColor = System.Drawing.Color.White;
            this.metroLabel_delete.Location = new System.Drawing.Point(178, 0);
            this.metroLabel_delete.Name = "metroLabel_delete";
            this.metroLabel_delete.Size = new System.Drawing.Size(20, 15);
            this.metroLabel_delete.TabIndex = 3;
            this.metroLabel_delete.Text = "x";
            this.metroLabel_delete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel_delete.Click += new System.EventHandler(this.metroLabel_delete_Click);
            // 
            // metroLabel_description
            // 
            this.metroLabel_description.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_description.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_description.ForeColor = System.Drawing.Color.White;
            this.metroLabel_description.Location = new System.Drawing.Point(8, 15);
            this.metroLabel_description.Name = "metroLabel_description";
            this.metroLabel_description.Size = new System.Drawing.Size(190, 15);
            this.metroLabel_description.TabIndex = 4;
            this.metroLabel_description.Text = "Description";
            this.metroLabel_description.Click += new System.EventHandler(this.metroLabel_Click);
            this.metroLabel_description.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.metroLabel_MouseDoubleClick);
            // 
            // metroLabel_name
            // 
            this.metroLabel_name.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_name.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_name.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_name.ForeColor = System.Drawing.Color.White;
            this.metroLabel_name.Location = new System.Drawing.Point(8, 0);
            this.metroLabel_name.Name = "metroLabel_name";
            this.metroLabel_name.Size = new System.Drawing.Size(164, 15);
            this.metroLabel_name.TabIndex = 5;
            this.metroLabel_name.Text = "Name";
            this.metroLabel_name.Click += new System.EventHandler(this.metroLabel_Click);
            this.metroLabel_name.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.metroLabel_MouseDoubleClick);
            // 
            // metroLabel_createdOn
            // 
            this.metroLabel_createdOn.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_createdOn.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_createdOn.ForeColor = System.Drawing.Color.White;
            this.metroLabel_createdOn.Location = new System.Drawing.Point(8, 30);
            this.metroLabel_createdOn.Name = "metroLabel_createdOn";
            this.metroLabel_createdOn.Size = new System.Drawing.Size(115, 15);
            this.metroLabel_createdOn.TabIndex = 5;
            this.metroLabel_createdOn.Text = "0000-00-00 00:00:00";
            this.metroLabel_createdOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel_createdOn.Click += new System.EventHandler(this.metroLabel_Click);
            this.metroLabel_createdOn.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.metroLabel_MouseDoubleClick);
            // 
            // metroLabel_edit
            // 
            this.metroLabel_edit.BackColor = System.Drawing.Color.Firebrick;
            this.metroLabel_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLabel_edit.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel_edit.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_edit.ForeColor = System.Drawing.Color.White;
            this.metroLabel_edit.Location = new System.Drawing.Point(165, 30);
            this.metroLabel_edit.Name = "metroLabel_edit";
            this.metroLabel_edit.Size = new System.Drawing.Size(33, 15);
            this.metroLabel_edit.TabIndex = 5;
            this.metroLabel_edit.Text = "Edit";
            this.metroLabel_edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel_edit.Click += new System.EventHandler(this.metroLabel_edit_Click);
            // 
            // AlbumListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel_delete);
            this.Controls.Add(this.metroLabel_description);
            this.Controls.Add(this.metroLabel_edit);
            this.Controls.Add(this.metroLabel_createdOn);
            this.Controls.Add(this.metroLabel_name);
            this.Controls.Add(this.metroTile_select);
            this.Name = "AlbumListItemControl";
            this.Size = new System.Drawing.Size(198, 45);
            this.UseStyleColors = true;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile_select;
        private MetroFramework.Controls.MetroLabel metroLabel_delete;
        private MetroFramework.Controls.MetroLabel metroLabel_description;
        private MetroFramework.Controls.MetroLabel metroLabel_name;
        private MetroFramework.Controls.MetroLabel metroLabel_createdOn;
        private MetroFramework.Controls.MetroLabel metroLabel_edit;
    }
}
