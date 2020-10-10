using System;
using System.IO;
using System.Windows.Forms;

namespace South.Hosse.Controls
{
    public partial class PdfControl : UserControl
    {
        public PdfControl()
        {
            InitializeComponent();

            ShowOpen = false;
            ShowSave = false;
            ShowPrint = false;
        }

        private void PdfControl_Load(object sender, EventArgs e)
        {
            this.pdfViewControl1.MovePageHandler += new MovePageHandler((o, n)=>{ ShowPageNum(); });
        }

        void ShowPageNum()
        {
            this.pageCountToolStripLabe.Text = " / " + this.pdfViewControl1.PageCount.ToString();
            this.pageNumToolStripTextBox.Text = (this.pdfViewControl1.CurrentPage + 1).ToString();
        }

        public bool ShowToolbar
        {
            get
            {
                return this.toolStrip1.Visible;
            }
            set
            {
                this.toolStrip1.Visible = value;
            }
        }

        public bool ShowOpen
        {
            get
            {
                return this.toolStrip1.Visible && this.打开ToolStripButton.Visible;
            }
            set
            {
                this.打开ToolStripButton.Visible = value;
                this.关闭ToolStripButton.Visible = value;
            }
        }

        public bool ShowSave
        {
            get
            {
                return this.toolStrip1.Visible && this.保存ToolStripButton.Visible;
            }
            set
            {
                this.保存ToolStripButton.Visible = value;
            }
        }

        public bool ShowPrint
        {
            get
            {
                return this.toolStrip1.Visible && this.打印ToolStripButton.Visible;
            }
            set
            {
                this.打印ToolStripButton.Visible = value;
            }
        }

        public bool OpenPdfFile(string fileName)
        {
            if (!this.pdfViewControl1.OpenPdfFile(fileName))
            {
                this.ShowWarning("打开文件失败！");
                return false;
            }

            return true;
        }

        public bool OpenPdfFile(Stream stream)
        {
            if (!this.pdfViewControl1.OpenPdfFile(stream))
            {
                this.ShowWarning("打开文件流失败！");
                return false;
            }

            return true;
        }

        private void 打开ToolStripButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Title = "打开 PDF 文件",
                DefaultExt = ".pdf",
                Filter = "PDF文件(*.pdf)|*.pdf",
                AddExtension = true,
                CheckFileExists = true,
                ShowReadOnly = false })
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    OpenPdfFile(openFileDialog.FileName);
                }
            }
        }

        private void 保存ToolStripButton_Click(object sender, EventArgs e)
        {

        }
        
        private void 适应宽ToolStripButton_Click(object sender, EventArgs e)
        {
            this.pdfViewControl1.FitWidth();
        }

        private void 适应高ToolStripButton_Click(object sender, EventArgs e)
        {
            this.pdfViewControl1.FitHeight();
        }

        private void 首页ToolStripButton_Click(object sender, EventArgs e)
        {
            this.pdfViewControl1.MoveToFirstPage();
        }

        private void 上一页ToolStripButton_Click(object sender, EventArgs e)
        {
            this.pdfViewControl1.MoveToPreviousPage();
        }

        private void 下一页ToolStripButton_Click(object sender, EventArgs e)
        {
            this.pdfViewControl1.MoveToNextPage();
        }

        private void 末页ToolStripButton_Click(object sender, EventArgs e)
        {
            this.pdfViewControl1.MoveToLastPage();
        }

        private void 关闭ToolStripButton_Click(object sender, EventArgs e)
        {
            this.pdfViewControl1.CloseFile();
        }

        private void 打印ToolStripButton_Click(object sender, EventArgs e)
        {
            this.pdfViewControl1.Print();
        }
    }
}
