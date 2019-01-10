namespace sample
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tm_left = new System.Windows.Forms.Timer(this.components);
            this.tm_right = new System.Windows.Forms.Timer(this.components);
            this.tm_jump = new System.Windows.Forms.Timer(this.components);
            this.currentmapinfor = new System.Windows.Forms.Label();
            this.countdead = new System.Windows.Forms.Label();
            this.dead = new System.Windows.Forms.Timer(this.components);
            this.visualx = new System.Windows.Forms.Label();
            this.lb_win = new System.Windows.Forms.Label();
            this.tm_win = new System.Windows.Forms.Timer(this.components);
            this.tm_move = new System.Windows.Forms.Timer(this.components);
            this.tm_death = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tm_left
            // 
            this.tm_left.Interval = 15;
            // 
            // tm_right
            // 
            this.tm_right.Interval = 15;
            // 
            // tm_jump
            // 
            this.tm_jump.Interval = 15;
            this.tm_jump.Tick += new System.EventHandler(this.tm_jump_Tick);
            // 
            // currentmapinfor
            // 
            this.currentmapinfor.AutoSize = true;
            this.currentmapinfor.BackColor = System.Drawing.Color.LightBlue;
            this.currentmapinfor.ForeColor = System.Drawing.Color.Black;
            this.currentmapinfor.Location = new System.Drawing.Point(629, 9);
            this.currentmapinfor.Name = "currentmapinfor";
            this.currentmapinfor.Size = new System.Drawing.Size(0, 15);
            this.currentmapinfor.TabIndex = 4;
            // 
            // countdead
            // 
            this.countdead.AutoSize = true;
            this.countdead.BackColor = System.Drawing.Color.Black;
            this.countdead.Enabled = false;
            this.countdead.Font = new System.Drawing.Font("휴먼매직체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.countdead.ForeColor = System.Drawing.Color.White;
            this.countdead.Location = new System.Drawing.Point(367, 319);
            this.countdead.Name = "countdead";
            this.countdead.Size = new System.Drawing.Size(39, 40);
            this.countdead.TabIndex = 5;
            this.countdead.Text = "4";
            this.countdead.Visible = false;
            // 
            // dead
            // 
            this.dead.Interval = 3300;
            this.dead.Tick += new System.EventHandler(this.dead_Tick);
            // 
            // visualx
            // 
            this.visualx.AutoSize = true;
            this.visualx.BackColor = System.Drawing.Color.Black;
            this.visualx.Enabled = false;
            this.visualx.Font = new System.Drawing.Font("휴먼매직체", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.visualx.ForeColor = System.Drawing.Color.White;
            this.visualx.Location = new System.Drawing.Point(311, 319);
            this.visualx.Name = "visualx";
            this.visualx.Size = new System.Drawing.Size(38, 38);
            this.visualx.TabIndex = 6;
            this.visualx.Text = "X";
            this.visualx.Visible = false;
            // 
            // lb_win
            // 
            this.lb_win.AutoSize = true;
            this.lb_win.BackColor = System.Drawing.Color.Black;
            this.lb_win.Enabled = false;
            this.lb_win.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_win.ForeColor = System.Drawing.Color.White;
            this.lb_win.Location = new System.Drawing.Point(44, 216);
            this.lb_win.Name = "lb_win";
            this.lb_win.Size = new System.Drawing.Size(622, 160);
            this.lb_win.TabIndex = 7;
            this.lb_win.Text = "남은 목숨 : 몇개\r\n클리어!";
            this.lb_win.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_win.Visible = false;
            // 
            // tm_win
            // 
            this.tm_win.Interval = 6500;
            this.tm_win.Tick += new System.EventHandler(this.tm_win_Tick);
            // 
            // tm_move
            // 
            this.tm_move.Interval = 15;
            this.tm_move.Tick += new System.EventHandler(this.tm_move_Tick);
            // 
            // tm_death
            // 
            this.tm_death.Interval = 500;
            this.tm_death.Tick += new System.EventHandler(this.tm_death_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(686, 640);
            this.Controls.Add(this.visualx);
            this.Controls.Add(this.countdead);
            this.Controls.Add(this.currentmapinfor);
            this.Controls.Add(this.lb_win);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.Text = "고양이 마리오 메이커";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tm_left;
        private System.Windows.Forms.Timer tm_right;
        private System.Windows.Forms.Timer tm_jump;
        private System.Windows.Forms.Label currentmapinfor;
        private System.Windows.Forms.Label countdead;
        private System.Windows.Forms.Timer dead;
        private System.Windows.Forms.Label visualx;
        private System.Windows.Forms.Label lb_win;
        private System.Windows.Forms.Timer tm_win;
        private System.Windows.Forms.Timer tm_move;
        private System.Windows.Forms.Timer tm_death;
    }
}

