using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlagApp
{
    public partial class FlagForm : Form
    {
        public FlagForm()
        {
            InitializeComponent();
        }
        private bool ghanaFlag = true;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ghanaFlag)
                DrawingGhana(ClientRectangle, e.Graphics);
            else
            {
                DrawingUK(ClientRectangle, e.Graphics);
            }
        }
        private void DrawingGhana(Rectangle r, Graphics g)
        {
            const int staticX = 2, staticY = 3;

            int height = r.Height, width = r.Width;

            if (staticX * r.Width > staticY * r.Height) 
            {
                width = height * staticY / staticX;
            }
            if (staticX * r.Width < staticY * r.Height)
            {
                height = width * staticX / staticY;
            }

            Color newred = Color.FromArgb(219, 36, 41);
            Color newyellow = Color.FromArgb(249, 207, 0);
            Color newgreen = Color.FromArgb(0, 108, 72);

            SolidBrush firstBrush = new SolidBrush(newred);
            SolidBrush secondBrush = new SolidBrush(newyellow);
            SolidBrush thirdBrush = new SolidBrush(newgreen);
            SolidBrush fourthBrush = new SolidBrush(Color.Black);

            g.FillRectangle(firstBrush, (this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height) / 2, width, height / 3 + 2);
            g.FillRectangle(secondBrush, (this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height) / 2 + height / 3, width, height / 3 + 2);
            g.FillRectangle(thirdBrush, (this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height) / 2 + 2 * height / 3, width, height / 3 + 2);

            g.FillPolygon(fourthBrush, new Point[] {
            new Point(this.ClientSize.Width / 2 - width / 11, (this.ClientSize.Height - height) / 2 + 2 * height / 3 - 2), new Point(this.ClientSize.Width / 2 + 2, (this.ClientSize.Height - height) / 2 + height / 3),
            new Point(this.ClientSize.Width / 2 + width / 11, (this.ClientSize.Height - height) / 2 + 2 * height / 3 - 2), new Point(this.ClientSize.Width / 2 + 2, this.ClientSize.Height / 2 + height / 12),
            new Point(this.ClientSize.Width / 2 - width / 11, (this.ClientSize.Height - height) / 2 + 2 * height / 3 - 2)
            }
            );

            g.FillPolygon(fourthBrush, new Point[] {
            new Point(this.ClientSize.Width / 2 - width / 8, this.ClientSize.Height / 2 - width / 25), new Point(this.ClientSize.Width / 2 + width / 8, this.ClientSize.Height / 2 - width / 25),
            new Point(this.ClientSize.Width / 2 + 2, this.ClientSize.Height / 2 + height / 12), new Point(this.ClientSize.Width / 2 - width / 8, this.ClientSize.Height / 2 - width / 25),
            }
            );
        }

        private void DrawingUK(Rectangle r, Graphics g)
        {
            const int staticX = 2, staticY = 3;

            int height = r.Height, width = r.Width;

            if (staticX * r.Width > staticY * r.Height)
            {
                width = height * staticY / staticX;
            }
            if (staticX * r.Width < staticY * r.Height) 
            {
                height = width * staticX / staticY;
            }

            Color newred = Color.FromArgb(229, 17, 16);
            Color newwhite = Color.FromArgb(219, 228, 227);
            Color newblue = Color.FromArgb(7, 43, 129);

            SolidBrush firstBrush = new SolidBrush(newred);
            SolidBrush secondBrush = new SolidBrush(newwhite);
            SolidBrush thirdBrush = new SolidBrush(newblue);

            g.FillRectangle(thirdBrush, (this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height) / 2, width, height); // синий задник

            g.FillPolygon(secondBrush, new Point[] {
            new Point((this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height) / 2), new Point((this.ClientSize.Width - width) / 2 + height / 7, (this.ClientSize.Height - height) / 2),
            new Point(this.ClientSize.Width / 2 + width / 2, this.ClientSize.Height / 2 + height / 2 - height / 7), new Point(this.ClientSize.Width / 2 + width / 2, this.ClientSize.Height / 2 + height / 2),
            new Point(this.ClientSize.Width / 2 + width/2 - height / 7, this.ClientSize.Height / 2 + height / 2), new Point((this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height) / 2 + height / 7)
            }
            );

            g.FillPolygon(secondBrush, new Point[] {
            new Point((this.ClientSize.Width - width) / 2, this.ClientSize.Height / 2 + height / 2), new Point((this.ClientSize.Width - width) / 2, this.ClientSize.Height / 2 + height / 2 - height / 7),
            new Point(this.ClientSize.Width / 2 + width/2 - height / 7, (this.ClientSize.Height - height) / 2), new Point(this.ClientSize.Width / 2 + width / 2, (this.ClientSize.Height - height) / 2),
            new Point(this.ClientSize.Width / 2 + width / 2, (this.ClientSize.Height - height) / 2 + height / 7), new Point((this.ClientSize.Width - width) / 2 + height / 7, this.ClientSize.Height / 2 + height / 2)
            }
            );

            g.FillPolygon(firstBrush, new Point[] {
            new Point((this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height) / 2), new Point((this.ClientSize.Width - width) / 2 + height / 12, (this.ClientSize.Height - height) / 2),
            new Point(this.ClientSize.Width / 2 + width / 2, this.ClientSize.Height / 2 + height / 2 - height / 12), new Point(this.ClientSize.Width / 2 + width / 2, this.ClientSize.Height / 2 + height / 2),
            new Point(this.ClientSize.Width / 2 + width/2 - height / 12, this.ClientSize.Height / 2 + height / 2), new Point((this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height) / 2 + height / 12)
            }
            );

            g.FillPolygon(firstBrush, new Point[] {
            new Point((this.ClientSize.Width - width) / 2, this.ClientSize.Height / 2 + height / 2), new Point((this.ClientSize.Width - width) / 2, this.ClientSize.Height / 2 + height / 2 - height / 12),
            new Point(this.ClientSize.Width / 2 + width/2 - height / 12, (this.ClientSize.Height - height) / 2), new Point(this.ClientSize.Width / 2 + width / 2, (this.ClientSize.Height - height) / 2),
            new Point(this.ClientSize.Width / 2 + width / 2, (this.ClientSize.Height - height) / 2 + height / 12), new Point((this.ClientSize.Width - width) / 2 + height / 12, this.ClientSize.Height / 2 + height / 2)
            }
            );

            g.FillRectangle(secondBrush, this.ClientSize.Width / 2 - height / 14 - height / 42, (this.ClientSize.Height - height) / 2, 4 * height / 21, height); // вер бел лин
            g.FillRectangle(secondBrush, (this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height / 4) / 2, width, height / 4); // гор бел лин
            g.FillRectangle(firstBrush, this.ClientSize.Width / 2 - height / 14, (this.ClientSize.Height - height) / 2, height / 7, height); // вер линия кр
            g.FillRectangle(firstBrush, (this.ClientSize.Width - width) / 2, (this.ClientSize.Height - height / 6) / 2, width, height / 6); // гор линия кр
        }
        private void FlagForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ghanaFlag = false;
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ghanaFlag = true;
            Invalidate();
        }
    }
}
