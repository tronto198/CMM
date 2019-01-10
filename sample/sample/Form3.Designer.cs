namespace sample
{
    partial class Form3
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
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_block_set = new System.Windows.Forms.Button();
            this.bt_bgm = new System.Windows.Forms.Button();
            this.bt_move = new System.Windows.Forms.Button();
            this.bt_startset = new System.Windows.Forms.Button();
            this.tip_startset = new System.Windows.Forms.ToolTip(this.components);
            this.bt_mob = new System.Windows.Forms.Button();
            this.bt_deco = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_item = new System.Windows.Forms.Button();
            this.bt_mapcolor = new System.Windows.Forms.Button();
            this.lb_bgm = new System.Windows.Forms.Label();
            this.lb_color = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_close
            // 
            this.bt_close.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_close.Font = new System.Drawing.Font("바탕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_close.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_close.Location = new System.Drawing.Point(464, 16);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(132, 108);
            this.bt_close.TabIndex = 3;
            this.bt_close.Text = "모든 맵 \r\n저장\r\n후 종료";
            this.bt_close.UseVisualStyleBackColor = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_block_set
            // 
            this.bt_block_set.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_block_set.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_block_set.Font = new System.Drawing.Font("바탕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_block_set.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_block_set.Location = new System.Drawing.Point(313, 16);
            this.bt_block_set.Name = "bt_block_set";
            this.bt_block_set.Size = new System.Drawing.Size(132, 108);
            this.bt_block_set.TabIndex = 4;
            this.bt_block_set.Text = "블럭 배치";
            this.bt_block_set.UseVisualStyleBackColor = false;
            // 
            // bt_bgm
            // 
            this.bt_bgm.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_bgm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_bgm.Font = new System.Drawing.Font("바탕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_bgm.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_bgm.Location = new System.Drawing.Point(162, 199);
            this.bt_bgm.Name = "bt_bgm";
            this.bt_bgm.Size = new System.Drawing.Size(132, 37);
            this.bt_bgm.TabIndex = 5;
            this.bt_bgm.Text = "브금 선택";
            this.bt_bgm.UseVisualStyleBackColor = false;
            // 
            // bt_move
            // 
            this.bt_move.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_move.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_move.Font = new System.Drawing.Font("바탕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_move.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_move.Location = new System.Drawing.Point(162, 16);
            this.bt_move.Name = "bt_move";
            this.bt_move.Size = new System.Drawing.Size(132, 108);
            this.bt_move.TabIndex = 7;
            this.bt_move.Text = "맵 이동\r\n(맵 추가)";
            this.bt_move.UseVisualStyleBackColor = false;
            this.bt_move.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_startset
            // 
            this.bt_startset.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_startset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_startset.Font = new System.Drawing.Font("바탕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_startset.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_startset.Location = new System.Drawing.Point(12, 16);
            this.bt_startset.Name = "bt_startset";
            this.bt_startset.Size = new System.Drawing.Size(132, 108);
            this.bt_startset.TabIndex = 8;
            this.bt_startset.Text = "시작 맵으로\r\n설정 및\r\n시작 좌표 설정";
            this.bt_startset.UseVisualStyleBackColor = false;
            this.bt_startset.Click += new System.EventHandler(this.bt_startset_Click);
            // 
            // tip_startset
            // 
            this.tip_startset.AutoPopDelay = 5000;
            this.tip_startset.InitialDelay = 200;
            this.tip_startset.ReshowDelay = 100;
            this.tip_startset.Popup += new System.Windows.Forms.PopupEventHandler(this.tip_startset_Popup);
            // 
            // bt_mob
            // 
            this.bt_mob.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_mob.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_mob.Font = new System.Drawing.Font("바탕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_mob.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_mob.Location = new System.Drawing.Point(12, 146);
            this.bt_mob.Name = "bt_mob";
            this.bt_mob.Size = new System.Drawing.Size(132, 37);
            this.bt_mob.TabIndex = 9;
            this.bt_mob.Text = "몬스터 배치";
            this.bt_mob.UseVisualStyleBackColor = false;
            // 
            // bt_deco
            // 
            this.bt_deco.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_deco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_deco.Font = new System.Drawing.Font("바탕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_deco.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_deco.Location = new System.Drawing.Point(162, 146);
            this.bt_deco.Name = "bt_deco";
            this.bt_deco.Size = new System.Drawing.Size(132, 37);
            this.bt_deco.TabIndex = 11;
            this.bt_deco.Text = "장식 배치";
            this.bt_deco.UseVisualStyleBackColor = false;
            // 
            // bt_clear
            // 
            this.bt_clear.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_clear.Font = new System.Drawing.Font("바탕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_clear.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_clear.Location = new System.Drawing.Point(313, 146);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(132, 37);
            this.bt_clear.TabIndex = 12;
            this.bt_clear.Text = "맵 초기화";
            this.bt_clear.UseVisualStyleBackColor = false;
            // 
            // bt_item
            // 
            this.bt_item.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_item.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_item.Font = new System.Drawing.Font("바탕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_item.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_item.Location = new System.Drawing.Point(464, 146);
            this.bt_item.Name = "bt_item";
            this.bt_item.Size = new System.Drawing.Size(132, 37);
            this.bt_item.TabIndex = 13;
            this.bt_item.Text = "아이템 배치";
            this.bt_item.UseVisualStyleBackColor = false;
            // 
            // bt_mapcolor
            // 
            this.bt_mapcolor.BackColor = System.Drawing.Color.PeachPuff;
            this.bt_mapcolor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_mapcolor.Font = new System.Drawing.Font("바탕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_mapcolor.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_mapcolor.Location = new System.Drawing.Point(464, 200);
            this.bt_mapcolor.Name = "bt_mapcolor";
            this.bt_mapcolor.Size = new System.Drawing.Size(132, 37);
            this.bt_mapcolor.TabIndex = 14;
            this.bt_mapcolor.Text = "맵 컬러 선택";
            this.bt_mapcolor.UseVisualStyleBackColor = false;
            // 
            // lb_bgm
            // 
            this.lb_bgm.Font = new System.Drawing.Font("바탕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_bgm.Location = new System.Drawing.Point(16, 200);
            this.lb_bgm.Name = "lb_bgm";
            this.lb_bgm.Size = new System.Drawing.Size(128, 33);
            this.lb_bgm.TabIndex = 15;
            this.lb_bgm.Text = "BGM : field";
            this.lb_bgm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_color
            // 
            this.lb_color.Font = new System.Drawing.Font("바탕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_color.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_color.Location = new System.Drawing.Point(317, 194);
            this.lb_color.Name = "lb_color";
            this.lb_color.Size = new System.Drawing.Size(128, 46);
            this.lb_color.TabIndex = 16;
            this.lb_color.Text = "MapColor\r\nLightBlue";
            this.lb_color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(612, 254);
            this.ControlBox = false;
            this.Controls.Add(this.lb_color);
            this.Controls.Add(this.lb_bgm);
            this.Controls.Add(this.bt_mapcolor);
            this.Controls.Add(this.bt_item);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_deco);
            this.Controls.Add(this.bt_mob);
            this.Controls.Add(this.bt_startset);
            this.Controls.Add(this.bt_move);
            this.Controls.Add(this.bt_bgm);
            this.Controls.Add(this.bt_block_set);
            this.Controls.Add(this.bt_close);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("궁서", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.Text = "tool";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button bt_close;
        public System.Windows.Forms.Button bt_block_set;
        public System.Windows.Forms.Button bt_bgm;
        public System.Windows.Forms.Button bt_move;
        public System.Windows.Forms.Button bt_startset;
        private System.Windows.Forms.ToolTip tip_startset;
        public System.Windows.Forms.Button bt_mob;
        public System.Windows.Forms.Button bt_deco;
        public System.Windows.Forms.Button bt_clear;
        public System.Windows.Forms.Button bt_item;
        public System.Windows.Forms.Button bt_mapcolor;
        public System.Windows.Forms.Label lb_bgm;
        public System.Windows.Forms.Label lb_color;
    }
}