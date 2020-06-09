namespace Teaming
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Tview = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.UserID = new System.Windows.Forms.Label();
            this.LView = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.창닫기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.Window;
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Controls.Add(this.btnRegister);
            this.MenuPanel.Controls.Add(this.btnSign);
            this.MenuPanel.Controls.Add(this.pictureBox1);
            this.MenuPanel.Location = new System.Drawing.Point(52, 26);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(689, 546);
            this.MenuPanel.TabIndex = 0;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRegister.Location = new System.Drawing.Point(374, 328);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(118, 58);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnSign
            // 
            this.btnSign.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSign.Location = new System.Drawing.Point(169, 328);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(118, 58);
            this.btnSign.TabIndex = 2;
            this.btnSign.Text = "Sign in";
            this.btnSign.UseVisualStyleBackColor = false;
            this.btnSign.Click += new System.EventHandler(this.BtnSign_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.LView);
            this.MainPanel.Controls.Add(this.Tview);
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Controls.Add(this.menuStrip1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(876, 584);
            this.MainPanel.TabIndex = 4;
            this.MainPanel.Visible = false;
            // 
            // Tview
            // 
            this.Tview.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tview.ImageIndex = 0;
            this.Tview.ImageList = this.imageList1;
            this.Tview.Location = new System.Drawing.Point(0, 110);
            this.Tview.Name = "Tview";
            this.Tview.SelectedImageIndex = 0;
            this.Tview.Size = new System.Drawing.Size(135, 474);
            this.Tview.TabIndex = 2;
            this.Tview.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trv_BeforeSelect);
            this.Tview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tview_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.UserID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 82);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.Location = new System.Drawing.Point(180, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 53);
            this.button2.TabIndex = 2;
            this.button2.Text = "아이디어 보기";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Location = new System.Drawing.Point(366, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "더 많은 아이디어 검색";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserID
            // 
            this.UserID.AutoSize = true;
            this.UserID.ForeColor = System.Drawing.Color.Red;
            this.UserID.Location = new System.Drawing.Point(560, 31);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(107, 15);
            this.UserID.TabIndex = 0;
            this.UserID.Text = "님 환영합니다.";
            // 
            // LView
            // 
            this.LView.HideSelection = false;
            this.LView.Location = new System.Drawing.Point(136, 110);
            this.LView.Name = "LView";
            this.LView.Size = new System.Drawing.Size(747, 502);
            this.LView.TabIndex = 3;
            this.LView.UseCompatibleStateImageBehavior = false;
            this.LView.DoubleClick += new System.EventHandler(this.lvw_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Teaming.Properties.Resources.Teaming_logo;
            this.pictureBox1.Location = new System.Drawing.Point(169, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "2.JPG");
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.창닫기ToolStripMenuItem});
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.메뉴ToolStripMenuItem.Text = "메뉴(&M)";
            // 
            // 창닫기ToolStripMenuItem
            // 
            this.창닫기ToolStripMenuItem.Name = "창닫기ToolStripMenuItem";
            this.창닫기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.창닫기ToolStripMenuItem.Text = "창 닫기";
            this.창닫기ToolStripMenuItem.Click += new System.EventHandler(this.창닫기ToolStripMenuItem_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.Location = new System.Drawing.Point(17, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 53);
            this.button3.TabIndex = 3;
            this.button3.Text = "티밍 페이지";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 584);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MenuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Teaming";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MenuPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label UserID;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TreeView Tview;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView LView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 창닫기ToolStripMenuItem;
        private System.Windows.Forms.Button button3;
    }
}

