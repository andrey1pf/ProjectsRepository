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
        public GameForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cheat = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Попробуй еще раз подумать", "Ты же не дурак");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("У тебя получилось, но зачем было тратить свое время?", "Ошибка!");
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (cheat == "AIWPRTON")
            {
                return;
            }
            if (CheckFirstStep == false)
            {
                moveX = (buttonNo.Width / 5);
                moveY = (buttonNo.Height / 5);
                CursorX = e.X;
                CursorY = e.Y;
            }
            // правый нижний угол
            if (CursorX >= buttonNo.Location.X - 2 && CursorX <= buttonNo.Location.X + (buttonNo.Width / 3) - 2)
            {
                if (CursorY >= buttonNo.Location.Y - 2 && CursorY <= buttonNo.Location.Y + (buttonNo.Height / 3) - 2)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X + moveX, buttonNo.Location.Y + moveY);
                }
            }
            // вниз
            if (CursorX >= buttonNo.Location.X + (buttonNo.Width / 3) - 2 && CursorX <= buttonNo.Location.X + 2 * (buttonNo.Width / 3) - 2)
            {
                if (CursorY >= buttonNo.Location.Y - 2 && CursorY <= buttonNo.Location.Y + (buttonNo.Height / 3) - 2)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X, buttonNo.Location.Y + moveY);
                }
            }
            // в левый нижний угол
            if (CursorX >= buttonNo.Location.X + 2 * (buttonNo.Width / 3) + 2 && CursorX <= buttonNo.Location.X + buttonNo.Width + 2)
            {
                if (CursorY >= buttonNo.Location.Y - 2 && CursorY <= buttonNo.Location.Y + (buttonNo.Height / 3) - 2)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X - moveX, buttonNo.Location.Y + moveY);
                }
            }
            // влево
            if (CursorX >= buttonNo.Location.X + 2 * (buttonNo.Width / 3) + 2 && CursorX <= buttonNo.Location.X + buttonNo.Width + 2)
            {
                if (CursorY >= buttonNo.Location.Y + (buttonNo.Height / 3) - 2 && CursorY <= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) + 2)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X - moveX, buttonNo.Location.Y);
                }
            }
            // в левый верхний угол
            if (CursorX >= buttonNo.Location.X + 2 * (buttonNo.Width / 3) + 2 && CursorX <= buttonNo.Location.X + buttonNo.Width + 2)
            {
                if (CursorY >= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) - 2 && CursorY <= buttonNo.Location.Y + buttonNo.Height + 2)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X - moveX, buttonNo.Location.Y - moveY);
                }
            }
            // вверх
            if (CursorX >= buttonNo.Location.X + (buttonNo.Width / 3) - 2 && CursorX <= buttonNo.Location.X + 2 * (buttonNo.Width / 3) - 2)
            {
                if (CursorY >= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) - 2 && CursorY <= buttonNo.Location.Y + buttonNo.Height + 2)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X, buttonNo.Location.Y - moveY);
                }
            }
            // в правый верхний угол
            if (CursorX >= buttonNo.Location.X - 2 && CursorX <= buttonNo.Location.X + (buttonNo.Width / 3) - 2)
            {
                if (CursorY >= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) - 2 && CursorY <= buttonNo.Location.Y + buttonNo.Height + 2)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X + moveX, buttonNo.Location.Y - moveY);
                }
            }
            // вправо
            if (CursorX >= buttonNo.Location.X - 2 && CursorX <= buttonNo.Location.X + (buttonNo.Width / 3) - 2)
            {
                if (CursorY >= buttonNo.Location.Y + (buttonNo.Height / 3) - 2 && CursorY <= buttonNo.Location.Y + 2 * (buttonNo.Height / 3) - 2)
                {
                    buttonNo.Location = new Point(buttonNo.Location.X + moveX, buttonNo.Location.Y);
                }
            }

            // верхняя граница
            if (buttonNo.Location.X >= 0 && buttonNo.Location.X <= this.ClientSize.Width && buttonNo.Location.Y >= 0 && buttonNo.Location.Y <= moveY)
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
            if (buttonYes.Location.X == buttonNo.Location.X && buttonYes.Location.Y == buttonNo.Location.Y) { 
                buttonNo.Location = new Point(buttonNo.Location.X + 150, buttonNo.Location.Y - 100); 
            }
        }
    }
}
