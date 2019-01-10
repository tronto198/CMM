namespace sample
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.bt_createmap = new System.Windows.Forms.Button();
            this.mapname = new System.Windows.Forms.TextBox();
            this.maplistbox = new System.Windows.Forms.ListBox();
            this.bt_modify = new System.Windows.Forms.Button();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_createmap
            // 
            this.bt_createmap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_createmap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_createmap.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_createmap.Location = new System.Drawing.Point(418, 524);
            this.bt_createmap.Name = "bt_createmap";
            this.bt_createmap.Size = new System.Drawing.Size(190, 65);
            this.bt_createmap.TabIndex = 2;
            this.bt_createmap.Text = "맵 제작";
            this.bt_createmap.UseVisualStyleBackColor = false;
            this.bt_createmap.Click += new System.EventHandler(this.bt_createmap_Click);
            // 
            // mapname
            // 
            this.mapname.Font = new System.Drawing.Font("바탕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mapname.Location = new System.Drawing.Point(71, 524);
            this.mapname.Multiline = true;
            this.mapname.Name = "mapname";
            this.mapname.Size = new System.Drawing.Size(278, 65);
            this.mapname.TabIndex = 3;
            this.mapname.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapname_MouseClick);
            this.mapname.TextChanged += new System.EventHandler(this.mapname_TextChanged);
            // 
            // maplistbox
            // 
            this.maplistbox.ColumnWidth = 5;
            this.maplistbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maplistbox.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.maplistbox.FormattingEnabled = true;
            this.maplistbox.ItemHeight = 27;
            this.maplistbox.Location = new System.Drawing.Point(62, 56);
            this.maplistbox.Name = "maplistbox";
            this.maplistbox.Size = new System.Drawing.Size(278, 247);
            this.maplistbox.TabIndex = 4;
            this.maplistbox.Click += new System.EventHandler(this.maplistbox_Click);
            this.maplistbox.SelectedIndexChanged += new System.EventHandler(this.maplistbox_SelectedIndexChanged);
            // 
            // bt_modify
            // 
            this.bt_modify.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_modify.Enabled = false;
            this.bt_modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_modify.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_modify.Location = new System.Drawing.Point(418, 338);
            this.bt_modify.Name = "bt_modify";
            this.bt_modify.Size = new System.Drawing.Size(190, 65);
            this.bt_modify.TabIndex = 5;
            this.bt_modify.Text = "맵 수정";
            this.bt_modify.UseVisualStyleBackColor = false;
            // 
            // bt_start
            // 
            this.bt_start.BackColor = System.Drawing.Color.Goldenrod;
            this.bt_start.Enabled = false;
            this.bt_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_start.Font = new System.Drawing.Font("서울한강체 M", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_start.Location = new System.Drawing.Point(418, 56);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(190, 162);
            this.bt_start.TabIndex = 6;
            this.bt_start.Text = "게임 시작";
            this.bt_start.UseVisualStyleBackColor = false;
            // 
            // bt_delete
            // 
            this.bt_delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_delete.Enabled = false;
            this.bt_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_delete.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_delete.Location = new System.Drawing.Point(418, 430);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(190, 65);
            this.bt_delete.TabIndex = 7;
            this.bt_delete.Text = "맵 삭제";
            this.bt_delete.UseVisualStyleBackColor = false;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(360, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "고양이 마리오 메이커";
            // 
            // Form2
            // 
            this.AcceptButton = this.bt_createmap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(686, 640);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.bt_modify);
            this.Controls.Add(this.maplistbox);
            this.Controls.Add(this.mapname);
            this.Controls.Add(this.bt_createmap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "고양이 마리오 메이커";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button bt_createmap;
        public System.Windows.Forms.TextBox mapname;
        public System.Windows.Forms.ListBox maplistbox;
        public System.Windows.Forms.Button bt_modify;
        public System.Windows.Forms.Button bt_start;
        public System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Label label1;
    }
}