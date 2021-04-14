using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shootingsMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        bool start = false;
        int radius, numberShootings;
        int hit, totalShootings;
        Pen line = new Pen(Color.Black, 2);
        SolidBrush fillColor = new SolidBrush(Color.DeepPink);
        SolidBrush fillHole = new SolidBrush(Color.Green);

        private Bitmap bit;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (start == true) {
                bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(bit);
                DrawingTarget(g);
                pictureBox1.Image = bit;
                pictureBox1.DrawToBitmap(bit, pictureBox1.ClientRectangle);
                base.OnPaint(e);
            }
        }

        private void DrawingTarget(Graphics g) {
            int targetWidth = pictureBox1.Width;
            int targetHeight = pictureBox1.Height;
            g.FillEllipse(fillColor, targetWidth / 2 - 2 * radius, targetHeight / 2 - 2 * radius, 2 * radius, 2 * radius);
            g.FillRectangle(fillColor, targetWidth / 2, targetHeight / 2, 2 * radius, radius);
            
            Point p1 = new Point(targetWidth / 2, 0);
            Point p2 = new Point(targetWidth / 2, targetHeight);
            g.DrawLine(line, p1, p2);
            
            Point p3 = new Point(0, targetHeight / 2);
            Point p4 = new Point(targetWidth, targetHeight / 2);
            g.DrawLine(line, p3, p4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBoxRadius_TextChanged(object sender, EventArgs e)
        {
            try
            {
                radius = Convert.ToInt32(textBoxRadius.Text);
                if (radius > 90)
                {
                    MessageBox.Show("Введен не корректный радиус");
                }
            }
            catch {
                MessageBox.Show("Введен не корректный радиус");
            }
        }

        private void textBoxShootings_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numberShootings = Convert.ToInt32(textBoxShootings.Text);
                if (numberShootings <= 0)
                {
                    MessageBox.Show("Введен не корректное кол-во выстрелов");
                }
            }
            catch {
                MessageBox.Show("Введен не корректное кол-во выстрелов");
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            start = true;
            hit = 0;
            totalShootings = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var cursorPosition = pictureBox1.PointToClient(Cursor.Position);
            g.FillEllipse(fillHole, cursorPosition.X, cursorPosition.Y, 5, 5);
            Color shootColor = bit.GetPixel(cursorPosition.X, cursorPosition.Y);
            pictureBox1.Refresh();
            ++totalShootings;

            if (shootColor.A == 255 && shootColor.B == 147 && shootColor.R == 255 && shootColor.G == 20)
            {
                ++hit;
            }

            if (totalShootings == numberShootings)
            {
                MessageBox.Show("Выстрелы закончились" + "\nКол-во попаданй в мешень " + hit + "\nКол-во промахов " + (totalShootings-hit));
                hit = 0;
                totalShootings = 0;
                return;
            }
        }
    }
}
