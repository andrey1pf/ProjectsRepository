using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GameForm : Form
    {
        bool CheckFirstStep = false;
        int moveX, moveY, CursorX, CursorY;
        string cheat;
        bool superimposition = false;
        public GameForm()
        {
            InitializeComponent();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Попробуй еще раз подумать", "Ты же не дурак");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cheat = textBox1.Text;
        }



        private void buttonNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("У тебя получилось, но зачем было тратить свое время?", "Ошибка!");
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (cheat == "AIWPRTON")
            {
                buttonNo.Enabled = true;
                return;
            }
            if (CheckFirstStep == false)
            {
                moveX = (buttonNo.Width / 3);
                moveY = (buttonNo.Height / 3);
                CursorX = e.X;
                CursorY = e.Y;
            }
            superimposition = false;
            buttonNo.Enabled = false;
            // правый нижний угол
            if (CursorX >= buttonNo.Location.X - 20 && CursorX <= buttonNo.Location.X + (buttonNo.Width / 3) - 20)
            {
                if (CursorY >= buttonNo.Location.Y - 20 && CursorY <= buttonNo.Location.Y + (buttonNo.Height / 3) - 20)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X + moveX, buttonNo.Location.Y + moveY);
                    superimposition = true;
                }
            }
            // вниз
            if (CursorX >= buttonNo.Location.X + (buttonNo.Width / 3) - 20 && CursorX <= buttonNo.Location.X + 2 * (buttonNo.Width / 3) - 20)
            {
                if (CursorY >= buttonNo.Location.Y - 20 && CursorY <= buttonNo.Location.Y + (buttonNo.Height / 3) - 20)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X, buttonNo.Location.Y + moveY);
                    superimposition = true;
                }
            }
            // в левый нижний угол
            if (CursorX >= buttonNo.Location.X + 2 * (buttonNo.Width / 3) + 20 && CursorX <= buttonNo.Location.X + buttonNo.Width + 20)
            {
                if (CursorY >= buttonNo.Location.Y - 20 && CursorY <= buttonNo.Location.Y + (buttonNo.Height / 3) - 20)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X - moveX, buttonNo.Location.Y + moveY);
                    superimposition = true;
                }
            }
            // влево
            if (CursorX >= buttonNo.Location.X + 2 * (buttonNo.Width / 3) + 20 && CursorX <= buttonNo.Location.X + buttonNo.Width + 20)
            {
                if (CursorY >= buttonNo.Location.Y + (buttonNo.Height / 3) - 20 && CursorY <= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) + 20)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X - moveX, buttonNo.Location.Y);
                    superimposition = true;
                }
            }
            // в левый верхний угол
            if (CursorX >= buttonNo.Location.X + 2 * (buttonNo.Width / 3) + 20 && CursorX <= buttonNo.Location.X + buttonNo.Width + 20)
            {
                if (CursorY >= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) - 20 && CursorY <= buttonNo.Location.Y + buttonNo.Height + 20)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X - moveX, buttonNo.Location.Y - moveY);
                    superimposition = true;
                }
            }
            // вверх
            if (CursorX >= buttonNo.Location.X + (buttonNo.Width / 3) - 20 && CursorX <= buttonNo.Location.X + 2 * (buttonNo.Width / 3) - 20)
            {
                if (CursorY >= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) - 20 && CursorY <= buttonNo.Location.Y + buttonNo.Height + 20)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X, buttonNo.Location.Y - moveY);
                    superimposition = true;
                }
            }
            // в правый верхний угол
            if (CursorX >= buttonNo.Location.X - 20 && CursorX <= buttonNo.Location.X + (buttonNo.Width / 3) - 20)
            {
                if (CursorY >= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) - 20 && CursorY <= buttonNo.Location.Y + buttonNo.Height + 20)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X + moveX, buttonNo.Location.Y - moveY);
                    superimposition = true;
                }
            }
            // вправо
            if (CursorX >= buttonNo.Location.X - 20 && CursorX <= buttonNo.Location.X + (buttonNo.Width / 3) - 20)
            {
                if (CursorY >= buttonNo.Location.Y + (buttonNo.Height / 3) - 20 && CursorY <= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) - 20)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X + moveX, buttonNo.Location.Y);
                    superimposition = true;
                }
            }



            Random random = new Random();

            if (CursorX >= buttonNo.Location.X - 1 && CursorX <= buttonNo.Location.X + buttonNo.Width + 1)
            {
                if (CursorY >= buttonNo.Location.Y - 1 && CursorY <= buttonNo.Location.Y + buttonNo.Height + 1)
                {
                    int x = random.Next(0, this.ClientSize.Width);
                    int y = random.Next(0, this.ClientSize.Height);
                    buttonNo.Location = new Point(x, y);
                }
            }

            if (superimposition = false)
            {
                int x = buttonNo.Location.X + 150;
                int y = buttonNo.Location.Y + 150;
                buttonNo.Location = new Point(x, y);
            }

            // верхняя граница
            if (buttonNo.Location.X >= 0 && buttonNo.Location.X <= .Location.Y >= 0 && buttonNo.Location.Y <= moveY)
            {
                buttonNo.Location = new Point(buttonNo.Location.X, buttonNo.Location.Y + 200);
            }
            // левая граница
            if (buttonNo.Location.X >= 0 && buttonNo.Location.X <= moveX && buttonNo.Location.Y >= 0 && buttonNo.Location.Y <= this.ClientSize.Height)
            {
                buttonNo.Location = new Point(buttonNo.Location.X + 200, buttonNo.Location.Y);
            }
            // правая граница
            if (buttonNo.Location.X >= this.ClientSize.Width - 5 * moveX && buttonNo.Location.X <= this.ClientSize.Width && buttonNo.Location.Y >= 0 && buttonNo.Location.Y <= this.Height)
            {
                buttonNo.Location = new Point(buttonNo.Location.X - 200, buttonNo.Location.Y);
            }
            // нижняя граница

            if (buttonNo.Location.X >= 0 && buttonNo.Location.X <= this.ClientSize.Width && buttonNo.Location.Y >= this.ClientSize.Height - 5 * moveY && buttonNo.Location.Y + moveY <= this.ClientSize.Height)
            {
                buttonNo.Location = new Point(buttonNo.Location.X, buttonNo.Location.Y - 200);
            }
            // если кнопки совпадут, то buttonNo переместиться


        }
    }
}