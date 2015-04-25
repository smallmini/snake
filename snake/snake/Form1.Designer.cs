namespace snake
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.请输入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.确定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.使用自定义迷宫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置自定义迷宫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无迷宫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.口字迷宫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.道路迷宫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.风车迷宫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.春字迷宫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 237);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem1.Text = "操作";
            // 
            // 新游戏ToolStripMenuItem
            // 
            this.新游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.地图ToolStripMenuItem,
            this.重新开始ToolStripMenuItem});
            this.新游戏ToolStripMenuItem.Name = "新游戏ToolStripMenuItem";
            this.新游戏ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.新游戏ToolStripMenuItem.Text = "新游戏";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.请输入ToolStripMenuItem,
            this.toolStripTextBox2,
            this.确定ToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem2.Text = "等级（0~9）";
            // 
            // 请输入ToolStripMenuItem
            // 
            this.请输入ToolStripMenuItem.Enabled = false;
            this.请输入ToolStripMenuItem.Name = "请输入ToolStripMenuItem";
            this.请输入ToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.请输入ToolStripMenuItem.Text = "请输入";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.MaxLength = 1;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(192, 23);
            this.toolStripTextBox2.Text = "5";
            // 
            // 确定ToolStripMenuItem
            // 
            this.确定ToolStripMenuItem.Name = "确定ToolStripMenuItem";
            this.确定ToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.确定ToolStripMenuItem.Text = "确定";
            this.确定ToolStripMenuItem.Click += new System.EventHandler(this.确定ToolStripMenuItem_Click);
            // 
            // 地图ToolStripMenuItem
            // 
            this.地图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.无迷宫ToolStripMenuItem,
            this.口字迷宫ToolStripMenuItem,
            this.道路迷宫ToolStripMenuItem,
            this.风车迷宫ToolStripMenuItem,
            this.春字迷宫ToolStripMenuItem});
            this.地图ToolStripMenuItem.Name = "地图ToolStripMenuItem";
            this.地图ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.地图ToolStripMenuItem.Text = "地图";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用自定义迷宫ToolStripMenuItem,
            this.设置自定义迷宫ToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem3.Text = "自定义迷宫";
            // 
            // 使用自定义迷宫ToolStripMenuItem
            // 
            this.使用自定义迷宫ToolStripMenuItem.Name = "使用自定义迷宫ToolStripMenuItem";
            this.使用自定义迷宫ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.使用自定义迷宫ToolStripMenuItem.Text = "使用自定义迷宫";
            this.使用自定义迷宫ToolStripMenuItem.Click += new System.EventHandler(this.使用自定义迷宫ToolStripMenuItem_Click);
            // 
            // 设置自定义迷宫ToolStripMenuItem
            // 
            this.设置自定义迷宫ToolStripMenuItem.Name = "设置自定义迷宫ToolStripMenuItem";
            this.设置自定义迷宫ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.设置自定义迷宫ToolStripMenuItem.Text = "设置自定义迷宫";
            this.设置自定义迷宫ToolStripMenuItem.Click += new System.EventHandler(this.设置自定义迷宫ToolStripMenuItem_Click);
            // 
            // 无迷宫ToolStripMenuItem
            // 
            this.无迷宫ToolStripMenuItem.Name = "无迷宫ToolStripMenuItem";
            this.无迷宫ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.无迷宫ToolStripMenuItem.Text = "无迷宫";
            this.无迷宫ToolStripMenuItem.Click += new System.EventHandler(this.无迷宫ToolStripMenuItem_Click);
            // 
            // 口字迷宫ToolStripMenuItem
            // 
            this.口字迷宫ToolStripMenuItem.Name = "口字迷宫ToolStripMenuItem";
            this.口字迷宫ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.口字迷宫ToolStripMenuItem.Text = "口字迷宫";
            this.口字迷宫ToolStripMenuItem.Click += new System.EventHandler(this.口字迷宫ToolStripMenuItem_Click);
            // 
            // 道路迷宫ToolStripMenuItem
            // 
            this.道路迷宫ToolStripMenuItem.Name = "道路迷宫ToolStripMenuItem";
            this.道路迷宫ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.道路迷宫ToolStripMenuItem.Text = "道路迷宫";
            this.道路迷宫ToolStripMenuItem.Click += new System.EventHandler(this.道路迷宫ToolStripMenuItem_Click);
            // 
            // 风车迷宫ToolStripMenuItem
            // 
            this.风车迷宫ToolStripMenuItem.Name = "风车迷宫ToolStripMenuItem";
            this.风车迷宫ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.风车迷宫ToolStripMenuItem.Text = "风车迷宫";
            this.风车迷宫ToolStripMenuItem.Click += new System.EventHandler(this.风车迷宫ToolStripMenuItem_Click);
            // 
            // 春字迷宫ToolStripMenuItem
            // 
            this.春字迷宫ToolStripMenuItem.Name = "春字迷宫ToolStripMenuItem";
            this.春字迷宫ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.春字迷宫ToolStripMenuItem.Text = "春字迷宫";
            this.春字迷宫ToolStripMenuItem.Click += new System.EventHandler(this.春字迷宫ToolStripMenuItem_Click);
            // 
            // 重新开始ToolStripMenuItem
            // 
            this.重新开始ToolStripMenuItem.Name = "重新开始ToolStripMenuItem";
            this.重新开始ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.重新开始ToolStripMenuItem.Text = "重新开始";
            this.重新开始ToolStripMenuItem.Click += new System.EventHandler(this.重新开始ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.帮助ToolStripMenuItem1});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            this.帮助ToolStripMenuItem1.Click += new System.EventHandler(this.帮助ToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(231, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Snake";
            this.TransparencyKey = System.Drawing.SystemColors.ControlDark;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 请输入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem 确定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无迷宫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 口字迷宫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 道路迷宫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 风车迷宫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重新开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 使用自定义迷宫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置自定义迷宫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 春字迷宫ToolStripMenuItem;
    }
}

