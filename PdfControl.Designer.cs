namespace South.Hosse.Controls
{
    partial class PdfControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.打开ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.保存ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.关闭ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打印ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.适应宽ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.适应高ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.首页ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.上一页ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pageNumToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.pageCountToolStripLabe = new System.Windows.Forms.ToolStripLabel();
            this.下一页ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.末页ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pdfViewControl1 = new South.Hosse.Controls.PdfViewControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripButton,
            this.保存ToolStripButton,
            this.关闭ToolStripButton,
            this.打印ToolStripButton,
            this.适应宽ToolStripButton,
            this.适应高ToolStripButton,
            this.toolStripSeparator1,
            this.首页ToolStripButton,
            this.上一页ToolStripButton,
            this.pageNumToolStripTextBox,
            this.pageCountToolStripLabe,
            this.下一页ToolStripButton,
            this.末页ToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(514, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 打开ToolStripButton
            // 
            this.打开ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打开ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打开ToolStripButton.Image")));
            this.打开ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开ToolStripButton.Name = "打开ToolStripButton";
            this.打开ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.打开ToolStripButton.Text = "打开";
            this.打开ToolStripButton.Visible = false;
            this.打开ToolStripButton.Click += new System.EventHandler(this.打开ToolStripButton_Click);
            // 
            // 保存ToolStripButton
            // 
            this.保存ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.保存ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存ToolStripButton.Image")));
            this.保存ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存ToolStripButton.Name = "保存ToolStripButton";
            this.保存ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.保存ToolStripButton.Text = "保存";
            this.保存ToolStripButton.Visible = false;
            this.保存ToolStripButton.Click += new System.EventHandler(this.保存ToolStripButton_Click);
            // 
            // 关闭ToolStripButton
            // 
            this.关闭ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.关闭ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("关闭ToolStripButton.Image")));
            this.关闭ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.关闭ToolStripButton.Name = "关闭ToolStripButton";
            this.关闭ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.关闭ToolStripButton.Text = "关闭";
            this.关闭ToolStripButton.Visible = false;
            this.关闭ToolStripButton.Click += new System.EventHandler(this.关闭ToolStripButton_Click);
            // 
            // 打印ToolStripButton
            // 
            this.打印ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打印ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打印ToolStripButton.Image")));
            this.打印ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印ToolStripButton.Name = "打印ToolStripButton";
            this.打印ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.打印ToolStripButton.Text = "打印";
            this.打印ToolStripButton.Visible = false;
            this.打印ToolStripButton.Click += new System.EventHandler(this.打印ToolStripButton_Click);
            // 
            // 适应宽ToolStripButton
            // 
            this.适应宽ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.适应宽ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("适应宽ToolStripButton.Image")));
            this.适应宽ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.适应宽ToolStripButton.Name = "适应宽ToolStripButton";
            this.适应宽ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.适应宽ToolStripButton.Text = "适应宽";
            this.适应宽ToolStripButton.ToolTipText = "适和宽度";
            this.适应宽ToolStripButton.Visible = false;
            this.适应宽ToolStripButton.Click += new System.EventHandler(this.适应宽ToolStripButton_Click);
            // 
            // 适应高ToolStripButton
            // 
            this.适应高ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.适应高ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("适应高ToolStripButton.Image")));
            this.适应高ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.适应高ToolStripButton.Name = "适应高ToolStripButton";
            this.适应高ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.适应高ToolStripButton.Text = "适应高";
            this.适应高ToolStripButton.ToolTipText = "适合高度";
            this.适应高ToolStripButton.Visible = false;
            this.适应高ToolStripButton.Click += new System.EventHandler(this.适应高ToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // 首页ToolStripButton
            // 
            this.首页ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.首页ToolStripButton.Image = global::South.Hosse.Controls.Properties.Resources.第一页;
            this.首页ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.首页ToolStripButton.Name = "首页ToolStripButton";
            this.首页ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.首页ToolStripButton.Text = "|<";
            this.首页ToolStripButton.ToolTipText = "转到首页";
            this.首页ToolStripButton.Click += new System.EventHandler(this.首页ToolStripButton_Click);
            // 
            // 上一页ToolStripButton
            // 
            this.上一页ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.上一页ToolStripButton.Image = global::South.Hosse.Controls.Properties.Resources.上一页;
            this.上一页ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.上一页ToolStripButton.Name = "上一页ToolStripButton";
            this.上一页ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.上一页ToolStripButton.Text = "<";
            this.上一页ToolStripButton.ToolTipText = "上一页";
            this.上一页ToolStripButton.Click += new System.EventHandler(this.上一页ToolStripButton_Click);
            // 
            // pageNumToolStripTextBox
            // 
            this.pageNumToolStripTextBox.Name = "pageNumToolStripTextBox";
            this.pageNumToolStripTextBox.Size = new System.Drawing.Size(40, 25);
            // 
            // pageCountToolStripLabe
            // 
            this.pageCountToolStripLabe.Name = "pageCountToolStripLabe";
            this.pageCountToolStripLabe.Size = new System.Drawing.Size(24, 22);
            this.pageCountToolStripLabe.Text = "/ 1";
            // 
            // 下一页ToolStripButton
            // 
            this.下一页ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.下一页ToolStripButton.Image = global::South.Hosse.Controls.Properties.Resources.下一页;
            this.下一页ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.下一页ToolStripButton.Name = "下一页ToolStripButton";
            this.下一页ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.下一页ToolStripButton.Text = ">";
            this.下一页ToolStripButton.ToolTipText = "下一页";
            this.下一页ToolStripButton.Click += new System.EventHandler(this.下一页ToolStripButton_Click);
            // 
            // 末页ToolStripButton
            // 
            this.末页ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.末页ToolStripButton.Image = global::South.Hosse.Controls.Properties.Resources.最后一页;
            this.末页ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.末页ToolStripButton.Name = "末页ToolStripButton";
            this.末页ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.末页ToolStripButton.Text = ">|";
            this.末页ToolStripButton.ToolTipText = "转到末尾";
            this.末页ToolStripButton.Click += new System.EventHandler(this.末页ToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(306, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // pdfViewControl1
            // 
            this.pdfViewControl1.AutoScroll = true;
            this.pdfViewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pdfViewControl1.CurrentPage = 0;
            this.pdfViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewControl1.Location = new System.Drawing.Point(0, 25);
            this.pdfViewControl1.Name = "pdfViewControl1";
            this.pdfViewControl1.Size = new System.Drawing.Size(514, 477);
            this.pdfViewControl1.TabIndex = 2;
            // 
            // PdfControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pdfViewControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PdfControl";
            this.Size = new System.Drawing.Size(514, 502);
            this.Load += new System.EventHandler(this.PdfControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private PdfViewControl pdfViewControl1;
        private System.Windows.Forms.ToolStripButton 打开ToolStripButton;
        private System.Windows.Forms.ToolStripButton 保存ToolStripButton;
        private System.Windows.Forms.ToolStripButton 适应宽ToolStripButton;
        private System.Windows.Forms.ToolStripButton 适应高ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 首页ToolStripButton;
        private System.Windows.Forms.ToolStripButton 上一页ToolStripButton;
        private System.Windows.Forms.ToolStripTextBox pageNumToolStripTextBox;
        private System.Windows.Forms.ToolStripButton 下一页ToolStripButton;
        private System.Windows.Forms.ToolStripButton 末页ToolStripButton;
        private System.Windows.Forms.ToolStripLabel pageCountToolStripLabe;
        private System.Windows.Forms.ToolStripButton 关闭ToolStripButton;
        private System.Windows.Forms.ToolStripButton 打印ToolStripButton;
    }
}
