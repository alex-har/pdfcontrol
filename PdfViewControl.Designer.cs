namespace South.Hosse.Controls
{
    partial class PdfViewControl
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
            this.panelContent = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(224, 268);
            this.panelContent.TabIndex = 3;
            this.panelContent.SizeChanged += new System.EventHandler(this.panelContent_SizeChanged);
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(224, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 268);
            this.vScrollBar1.TabIndex = 4;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // PdfViewControl
            // 
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "PdfViewControl";
            this.Size = new System.Drawing.Size(241, 268);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}
