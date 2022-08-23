using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BirdBrainmofo.HVNC.Controls
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        private Color primaryColor;

        private Color textColor;

        private int arrowThickness;

        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor)
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            this.primaryColor = primaryColor;
            if (isMainMenu)
            {
                this.arrowThickness = 3;
                if (textColor == Color.Empty)
                {
                    this.textColor = Color.Gainsboro;
                }
                else
                {
                    this.textColor = textColor;
                }
            }
            else
            {
                this.arrowThickness = 2;
                if (textColor == Color.Empty)
                {
                    this.textColor = Color.DimGray;
                }
                else
                {
                    this.textColor = textColor;
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs toolStripItemTextRenderEventArgs_0)
        {
            base.OnRenderItemText(toolStripItemTextRenderEventArgs_0);
            toolStripItemTextRenderEventArgs_0.Item.ForeColor = (toolStripItemTextRenderEventArgs_0.Item.Selected ? Color.White : this.textColor);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs toolStripArrowRenderEventArgs_0)
        {
            Graphics graphics = toolStripArrowRenderEventArgs_0.Graphics;
            Size size = new Size(5, 12);
            Color color = (toolStripArrowRenderEventArgs_0.Item.Selected ? Color.White : this.primaryColor);
            Rectangle rectangle = new Rectangle(toolStripArrowRenderEventArgs_0.ArrowRectangle.Location.X, (toolStripArrowRenderEventArgs_0.ArrowRectangle.Height - size.Height) / 2, size.Width, size.Height);
            using GraphicsPath graphicsPath = new GraphicsPath();
            using Pen pen = new Pen(color, this.arrowThickness);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top + rectangle.Height / 2);
            graphicsPath.AddLine(rectangle.Right, rectangle.Top + rectangle.Height / 2, rectangle.Left, rectangle.Top + rectangle.Height);
            graphics.DrawPath(pen, graphicsPath);
        }
    }
}
