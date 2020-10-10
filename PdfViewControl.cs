using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using O2S.Components.PDFRender4NET;
using O2S.Components.PDFRender4NET.Printing;

namespace South.Hosse.Controls
{
    public partial class PdfViewControl : UserControl
    {
        //public string FileName { get; private set; }

        public int CurrentPage { get; set; }

        public int PageCount { get { return this.Pages.Count; } }

        public double PageScale { get; private set; }

        public MovePageHandler MovePageHandler;

        PDFFile pdfFile = null;

        int pageInterval = 5;

        public PdfViewControl()
        {
            InitializeComponent();

            this.AutoScroll = false;
            this.VScroll = false;

            //this.FileName = string.Empty;
            this.CurrentPage = 0;
            this.PageScale = 1;

            this.vScrollBar1.LargeChange = this.panelContent.Height;
            this.vScrollBar1.Maximum = this.panelContent.Height;

            this.panelContent.MouseWheel += new MouseEventHandler(panelContent_MouseWheel);
            this.MouseWheel += new MouseEventHandler(panelContent_MouseWheel);
        }

        /// <summary>
        /// 虚拟页，需要显示的时候才创建实际控件
        /// </summary>
        class PdfPageInfo : IDisposable
        {
            public PdfPageInfo(int page, double width, double height)
            {
                this.PageIndex = page;
                this.PdfWidth = width;
                this.PdfHeight = height;
                this.size = new Size((int)PdfWidth, (int)PdfHeight); ;
                this.PageControl = null;
            }

            public int PageIndex { get; private set; }

            public double PdfWidth { get; private set; }

            public double PdfHeight { get; private set; }

            private Point location;

            public Point Location
            {
                get
                {
                    return location;
                }
                set
                {
                    location = value;
                    if (this.PageControl != null)
                    {
                        this.PageControl.Location = this.location;
                    }
                }
            }

            public int Left
            {
                get
                {
                    return this.location.X;
                }
            }

            public int Top
            {
                get
                {
                    return this.location.Y;
                }
            }

            private Size size;

            public Size Size
            {
                get
                {
                    return this.size;
                }
                set
                {
                    this.size = value;
                    if (this.PageControl != null)
                    {
                        this.PageControl.Size = this.size;
                    }
                }
            }

            public int Width
            {
                get
                {
                    return this.size.Width;
                }
            }

            public int Height
            {
                get
                {
                    return this.size.Height;
                }
            }

            public int Bottom
            {
                get
                {
                    return Top + Height;
                }
            }

            public Bitmap CachedMap { get; set; }

            public PdfPageControl PageControl { get; private set; }

            public void CreateControl(int top)
            {
                if (this.PageControl == null)
                {
                    this.PageControl = new PdfPageControl();
                    this.PageControl.PageIndex = this.PageIndex;
                    this.PageControl.SetPageSize(this.PdfWidth, this.PdfHeight);
                    this.PageControl.Name = "page" + this.PageIndex.ToString();

                    this.PageControl.Location = new Point(this.Location.X, top);
                    this.PageControl.Size = this.Size;
                    this.PageControl.Visible = this.Visible;
                }
            }

            public void Dispose()
            {
                if (CachedMap != null)
                {
                    CachedMap.Dispose();
                    CachedMap = null;
                }
            }

            bool visible = false;

            public bool Visible
            {
                get
                {
                    if (this.PageControl != null)
                    {
                        return this.PageControl.Visible;
                    }
                    return visible;
                }
                set
                {
                    visible = value;
                    if (this.PageControl != null)
                    {
                        this.PageControl.Visible = visible;
                        this.PageControl.NeedRender = visible;
                        if (value)
                        {
                            this.PageControl.Invalidate();
                        }
                    }
                }
            }

            public void SetScale(double scale)
            {
                if (scale < 0.01)
                {
                    scale = 0.01;
                }
                else if (scale > 100.0)
                {
                    scale = 100.0;
                }

                if (this.PageControl == null)
                {
                    this.size = new Size((int)(this.PdfWidth * scale), (int)(this.PdfHeight * scale));
                }
                else
                { 
                    this.PageControl.SetScale(scale);
                    this.size = this.PageControl.Size;
                }
            }
        }

        void CreateControl(PdfPageInfo page, int scroll)
        {
            int top = page.Top - scroll;
            if (page.PageControl == null)
            {
                page.CreateControl(top);
                page.SetScale(this.PageScale);
                this.panelContent.Controls.Add(page.PageControl);
                page.PageControl.OnRender = this.RenderPage;
            }
            else
            {
                page.PageControl.Top = top;
                page.PageControl.Size = page.Size;
            }
        }

        void ScrollTo(int newValue)
        {

            if (newValue < this.vScrollBar1.Minimum)
            {
                newValue = this.vScrollBar1.Minimum;
            }
            else if (newValue >= this.vScrollBar1.Maximum - this.vScrollBar1.LargeChange)
            {
                newValue = this.vScrollBar1.Maximum - this.vScrollBar1.LargeChange + 1;
            }
            if (newValue == this.vScrollBar1.Value) // 
            {
                RenderPages();
            }
            else
            {
                this.vScrollBar1.Value = newValue;
            }
        }

        readonly List<PdfPageInfo> Pages = new List<PdfPageInfo>();

        void panelContent_MouseWheel(object sender, MouseEventArgs e)
        {
            // 按住Ctrl
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    Scale(1.1);
                }
                else
                {
                    Scale(0.9);
                }
            }
            else
            {
                ScrollTo(this.vScrollBar1.Value - e.Delta);
            }
        }

        void RenderPages()
        {
            if (this.PageCount == 0)
            {
                return;
            }

            int scroll = this.vScrollBar1.Value;

            int firstVisible = -1;
            foreach (PdfPageInfo page in this.Pages)
            {
                if (page.Top > scroll + this.vScrollBar1.LargeChange
                    || page.Bottom < scroll)
                {
                    page.Visible = false;
                }
                else
                {
                    CreateControl(page, scroll);
                    page.Visible = true;
                    if (firstVisible == -1)
                    {
                        firstVisible = page.PageIndex;
                    }
                }
            }

            if (firstVisible != -1)
            {
                this.CurrentPage = firstVisible;

                if (this.MovePageHandler != null)
                {
                    this.MovePageHandler.Invoke(this, this.CurrentPage);
                }
            }
        }
        
        void Relayout()
        {
            if (this.PageCount == 0)
            {
                return;
            }

            this.vScrollBar1.Value = 0;

            int maxWidth = this.Pages.Max(p => p.Width);

            this.HScroll = maxWidth > this.panelContent.Width;

            int totalHeight = this.Pages.Sum(p => p.Height) + pageInterval * (this.Pages.Count - 1);
            this.vScrollBar1.Maximum = totalHeight;

            int scrollPage = this.panelContent.Height + pageInterval;
            if (this.HScroll)
            {
                scrollPage -= 20;
            }
            this.vScrollBar1.LargeChange = scrollPage;

            int top = 0;
            foreach (PdfPageInfo page in this.Pages)
            {
                int left = (this.panelContent.Width - page.Width) / 2;
                page.Location = new Point(left, top);
                top += page.Height + pageInterval;
            }
        }

        public void SetScale(double scale)
        {
            this.PageScale = scale;
            if (this.PageScale < 0.05)
            {
                this.PageScale = 0.05;
            }
            else if (this.PageScale > 20)
            {
                this.PageScale = 20;
            }
            else if (Math.Abs(this.PageScale - 1.0) < 0.01)
            {
                this.PageScale = 1.0;
            }

            foreach (PdfPageInfo page in this.Pages)
            {
                page.SetScale(this.PageScale);
            }

            int curPage = this.CurrentPage;

            Relayout();

            MoveToPage(curPage);
        }

        public void Scale(double scale)
        {
            SetScale(this.PageScale * scale);
        }

        public bool OpenPdfFile(string fileName)
        {
            try
            {
                FileStream stream = File.OpenRead(fileName);

                return OpenPdfFile(stream);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool OpenPdfFile(Stream stream)
        {
            //if (this.FileName == fileName)
            //{
            //    return true;
            //}

            CloseFile();

            pdfFile = PDFFile.Open(stream);
            if (pdfFile == null)
            {
                return false;
            }

            if (pdfFile.PageCount == 0)
            {
                pdfFile.Dispose();
                pdfFile = null;
                return false;
            }

            //this.FileName = fileName;

            double s = 96.0 / 72.0;

            for (int i = 0; i < pdfFile.PageCount; i++)
            {
                PDFSize size = pdfFile.GetPageSize(i);
                PdfPageInfo page = new PdfPageInfo(i, (int)(size.Width * s), (int)(size.Height * s));
                this.Pages.Add(page);
            }

            double scale = (double)this.Height / (double)this.Width;
            double pdfScale = this.Pages[0].PdfHeight / this.Pages[0].PdfWidth;
            if (scale < pdfScale)
            {
                SetScale((double)this.Height / this.Pages[0].PdfHeight);
            }
            else
            {
                SetScale((double)this.Width / this.Pages[0].PdfWidth);
            }

            MoveToPage(0);

            return true;
        }

        Bitmap GetCachedBmp(int pageIndex)
        {
            if (this.Pages[pageIndex].CachedMap == null)
            {
                this.Pages[pageIndex].CachedMap = pdfFile.GetPageImage(pageIndex, 300);
            }
            return this.Pages[pageIndex].CachedMap;
        }

        void RenderPage(Graphics graphics, int pageIndex)
        {
            if (pdfFile != null && pageIndex >= 0  && pageIndex < pdfFile.PageCount)
            {
                System.Drawing.Drawing2D.GraphicsState state = graphics.Save();

                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                //graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                //graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
                //graphics.PageUnit = GraphicsUnit.Millimeter;
                //graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                double scale = this.Pages[pageIndex].Width / this.Pages[pageIndex].PdfWidth;
                graphics.ScaleTransform((float)scale, (float)scale);

                Bitmap bmp = GetCachedBmp(pageIndex);

                graphics.DrawImage(bmp, new Point(0, 0));
                //pdfFile.RenderPage(pageIndex, graphics);

                graphics.Restore(state);
            }
            else
            {
                graphics.Clear(Color.White);
            }
        }

        public void CloseFile()
        {
            //this.FileName = string.Empty;
            this.CurrentPage = 0;
            this.PageScale = 1;
            this.HScroll = false;
            this.vScrollBar1.Value = 0;
            this.vScrollBar1.Maximum = this.panelContent.Height;

            if (pdfFile != null)
            {
                pdfFile.Dispose();
                pdfFile = null;
            }

            foreach (var page in this.Pages)
            {
                if (page.PageControl != null)
                {
                    this.panelContent.Controls.Remove(page.PageControl);
                    page.PageControl.Dispose();
                    page.Dispose();
                }
            }
            this.Pages.Clear();            
        }
        
        public bool SaveAs(string fileName)
        {
            if (this.pdfFile == null)
            {
                return false;
            }

            return true;
        }

        public bool Print()
        {
            if (this.pdfFile == null)
            {
                return false;
            }

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog(this) == DialogResult.OK)
            {
                PDFPrintSettings settings = new PDFPrintSettings()
                {
                    BitmapPrintResolution = 300,
                    AutoRotate = true,
                    Columns = 1,
                    Rows = 1,
                    PageScaling = PageScaling.None,
                    DownscaleLargeImages = true,
                    PaperSize = printDialog.PrinterSettings.DefaultPageSettings.PaperSize
                };
                this.pdfFile.Print(settings);
            }

            return true;
        }

        public void MoveToPage(int page, int offset = 0)
        {
            if (page < 0 || page >= this.Pages.Count)
            {
                return;
            }

            ScrollTo(this.Pages[page].Top + offset);
        }

        public void MoveToFirstPage()
        {
            MoveToPage(0);
        }

        public void MoveToLastPage()
        {
            if (this.PageCount == 0)
            {
                return;
            }
            int offset = 0;
            if (this.PageCount > 1)
            {
                offset = this.Pages.Last().Height;
            }
            MoveToPage(this.PageCount - 1, offset);
        }

        public void MoveToPreviousPage()
        {
            if (this.PageCount == 0)
            {
                return;
            }
            else if (this.CurrentPage == 0)
            {
                MoveToFirstPage();
            }
            else
            {
                MoveToPage(this.CurrentPage - 1);
            } 
        }

        public void MoveToNextPage()
        {
            if (this.PageCount == 0)
            {
                return;
            }
            else if (this.CurrentPage >= this.Pages.Count - 1)
            {
                MoveToLastPage();
            }
            else
            {
                MoveToPage(this.CurrentPage + 1);
            }
        }

        public void FitHeight()
        {
            if (this.PageCount == 0)
            {
                return;
            }

            int page = this.CurrentPage;
            double scale = (double)this.Height / this.Pages[page].PdfHeight;
            SetScale(scale);

            MoveToPage(page);
        }

        public void FitWidth()
        {
            if (this.PageCount == 0)
            {
                return;
            }

            int page = this.CurrentPage;
            double scale = (double)this.Width / this.Pages[page].PdfWidth;
            SetScale(scale);

            MoveToPage(page);
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            RenderPages();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            RenderPages();
        }

        private void panelContent_SizeChanged(object sender, EventArgs e)
        {
            Relayout();
        }
    }
}
