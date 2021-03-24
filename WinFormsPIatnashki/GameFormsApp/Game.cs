using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFormsApp
{
    class Game
    {
        int[,] map;
        int size;
        int nullX, nullY, nullX1, nullY1, cs = 0;
        int X = 0, Y = 0, Counter = 0;
        static Random RandomNumber = new Random();

        public Game(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            map = new int[size, size];
        }

        public void StartGame()
        {
            for (int x = 0; x < size; ++x)
            {
                for (int y = 0; y < size; ++y)
                {
                    map[x, y] = CoordinatesOfPosition(x, y) + 1;
                }
            }
            nullX = 3;
            nullY = 3;
            map[nullX, nullY] = 0;

        }

        public void GameRepeat(int ResultTag)
        {
            cs = 0;
            map[X + (Counter % 4), Y] = ResultTag;
            if (Counter % 4 == 3)
            {
                X = 0;
                ++Y;
            }
            ++Counter;
        }

        public void ShiftRandom()
        {
            int x, y;
            int value = RandomNumber.Next(0, 15);
            PositionOfCoordinates(RandomNumber.Next(value, size * size), out x, out y);
            map[nullX, nullY] = map[x, y];
            map[x, y] = 0;
            nullX1 = nullX = x;
            nullY1 = nullY = y;
        }

        public void PressedButton(int position)
        {
            int x, y;
            PositionOfCoordinates(position, out x, out y);
            if (cs == 0) {
                nullX = nullX1;
                nullY = nullY1;
                ++cs;
            }
            if (Math.Abs(nullX - x) + Math.Abs(nullY - y) != 1) return; // cheat for moving cells
            map[nullX, nullY] = map[x, y];
            map[x, y] = 0;
            nullX = x;
            nullY = y;
        }

        public int GetNumber(int position)
        {
            int x, y;
            PositionOfCoordinates(position, out x, out y); // передаем сюда значение position, а получаем значение x,y
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }

        private int CoordinatesOfPosition(int x, int y)
        {
            int result = x + y * size;
            return result;
        }

        private void PositionOfCoordinates(int position, out int x, out int y)
        {
            x = position % size;
            y = position / size;
        }

        public bool CheckEnd()
        {
            for (int x = 0; x < size; ++x)
            {
                for (int y = 0; y < size; ++y)
                {
                    if (x != size - 1 && y == size - 1)
                    {
                        if (map[x, y] != CoordinatesOfPosition(x, y) + 1) return false;
                    }
                }
            }
            return true;
        }
    }
}
