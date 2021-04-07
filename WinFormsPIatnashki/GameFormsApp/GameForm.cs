using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFormsApp
{
    public partial class GameForm : Form
    {
        Game game;
        int count = 0;
        int[] FirstPosition = new int[16];
        bool check = false;
        int position;
        int Counter = 0;
        public GameForm()
        {
            InitializeComponent();
            game = new Game(4);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try {
                position = Convert.ToInt16(((Button)sender).Tag); 
            }
            catch { }
            game.PressedButton(position);
            ++count;
            Refresh();
            if (game.CheckEnd())
            {
                Stopwatch.Stop();
                MessageBox.Show("Congratulations, you did it... \nAmount of steps " + count.ToString(), "Notification");
                MessageBox.Show("If you want to start a new game, press 'Menu -> Start new game'\nIf you want to repeat the game,press 'Menu->Repeat the game'", "Notification");
                Stopwatch.Stop();
                TimeBox.Text = "00:00";
                count = 0;
            }
        }

        private Button button(int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            GameStart();
            Stopwatch.Start();
            TimeBox.Text = "00:00";
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart();
            RestartTimer();
        }

        private void RestartTimer()
        {
            TimeBox.Text = "00:00";
            date1 = new DateTime(0, 0);
            Stopwatch.Enabled = true;
        }

        private void repeatTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check = true;
            RepeatThisGame();
            RestartTimer();
        }

        private void RepeatThisGame()
        {
            for (int i = 0; i < 16; ++i)
            {
                int ResultTag = FirstPosition[i];
                game.GameRepeat(ResultTag, Counter);
                ++Counter;
            }
            Counter = 0;
            Refresh();
        }

        private void GameStart()
        {
            game.StartGame();
            for (int i = 0; i < 500; ++i)
            {
                game.ShiftRandom();
            }
            Refresh();
        }

        private void Refresh()
        {
            for (int position = 0; position < 16; ++position)
            {
                int number = game.GetNumber(position);
                button(position).Text = number.ToString();
                bool visiblePosition = number > 0;
                button(position).Visible = visiblePosition;

            }
            if (count == 0 && check == false)
            {
                for (int position = 0; position < 16; ++position)
                {
                    int number = game.GetNumber(position);
                    FirstPosition[position] = number;
                }
                check = true;
            }
        }

        private void TimeBox_TextChanged(object sender, EventArgs e) { }
        DateTime date1 = new DateTime(0, 0);
        private void Stopwatch_Tick(object sender, EventArgs e)
        {
            date1 = date1.AddSeconds(0.1);
            TimeBox.Text = date1.ToString("mm:ss");
        }
    }
}
