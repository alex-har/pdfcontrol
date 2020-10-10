using System;
using System.Drawing;
using System.Windows.Forms;

namespace South.Hosse.Controls
{
    public partial class PdfPageControl : UserControl
    {
        public delegate void RenderEvent(Graphics graphics, int pageIndex);

        public RenderEvent OnRender;

        public int PageIndex { get; set; }

        public double PdfWidth { get; private set; }

        public double PdfHeight { get; private set; }

        public bool NeedRender { get; set; }

        public PdfPageControl()
        {
            InitializeComponent();
        }
        
        public void SetPageSize(double width, double height)
        {
            if (width < 1)
            {
                return;
            }

            this.PdfWidth = width;

            this.PdfHeight = height;

            this.Size = new Size((int)this.PdfWidth, (int)this.PdfHeight);
        }

        public void SetScale(double scale)
        {
            double xyScale = this.PdfHeight / this.PdfWidth;
            double width = this.PdfWidth * scale;
            this.Size = new Size((int)width, (int)(width * xyScale));
        }

        void Render(Graphics graphics)
        {
            if (!NeedRender)
            {
                return;
            }

            graphics.Clear(Color.White);

            if (OnRender != null)
            {
                OnRender.Invoke(graphics, this.PageIndex);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Render(e.Graphics);

            base.OnPaint(e);
        }
    }
}
