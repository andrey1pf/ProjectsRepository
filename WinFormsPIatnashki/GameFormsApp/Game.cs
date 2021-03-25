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
        int X = 0, Y = 0;
        static Random RandomNumber = new Random();

        public Game(int size)
        {
            if (size < 2) {
                size = 2;
            }
            if (size > 5) {
                size = 5;
            }
            this.size = size;
            map = new int[size, size];
        }
        /// <summary>
        /// начало игры/сортированная расстановкка значений кнопок 
        /// </summary>
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
        /// <summary>
        /// Рестарт этой игры
        /// </summary>
        /// <param name="ResultTag">берется значение кнопок на определенном tag из массива FirstPosition</param>
        public void GameRepeat(int ResultTag, int Counter)
        {
            cs = 0;
            if (Counter == 0) {
                X = 0;
                Y = 0;
            }
            map[X + (Counter % 4), Y] = ResultTag;
            if (Counter % 4 == 3)
            {
                X = 0;
                ++Y;
            }
        }
        /// <summary>
        /// рандом расстановки кнопок, изначально получаем значение value - рандомное число от 0 до 15
        /// далее используем функцию PositionOfCoordinates, которая описывается далее
        /// меняем эту случайную кнопку с другой случайной кнопкой
        /// </summary>
        public void ShiftRandom()
        {
            int x, y;
            int x1, y1;
            int z;
            int value = RandomNumber.Next(0, 15);
            int value1 = RandomNumber.Next(0, 15);
            if (value == value1) {; }
            else {
                PositionOfCoordinates(value, out x, out y);
                PositionOfCoordinates(value1, out x1, out y1);
                z = map[x1, y1];
                map[x1, y1] = map[x, y];
                map[x, y] = z;
                if (x == nullX || x1 == nullX) {
                    nullX1 = nullX;
                    nullY1 = nullX;
                }
            }
        }
        /// <summary>
        /// при нажатии какой-либо кнопки мы получаем значение position этой кнопки
        /// далее производим проверку, которая показывает, является ли эта кнопка рядомстоящей 
        /// </summary>
        /// <param name="position">tag</param>
        public void PressedButton(int position)
        {
            int x, y;
            PositionOfCoordinates(position, out x, out y);
            if (cs == 0) {
                nullX = nullX1;
                nullY = nullY1;
                ++cs;
            }
            if (Math.Abs(nullX - x) + Math.Abs(nullY - y) != 1) {
                return;
            }// cheat for moving cells
            map[nullX, nullY] = map[x, y];
            map[x, y] = 0;
            nullX = x;
            nullY = y;
        }
        /// <summary>
        /// Получаем значение position, потом обращаемся к описанной далее функции PositionOfCoordinates
        /// из нее получаем значение x, y
        /// </summary>
        /// <param name="position">tag</param>
        /// <returns>выводим что написано на данной кнопке</returns>
        public int GetNumber(int position)
        {
            int x, y;
            PositionOfCoordinates(position, out x, out y);
            if (x < 0 || x >= size) {
                return 0;
            }
            if (y < 0 || y >= size) {
                return 0;
            }
            return map[x, y];
        }
        /// <summary>
        /// Получаем значение x и y и вычисляем tag - фиксированное значение кнопки [
        /// </summary>
        /// <param name="x">координата кнопки по x</param>
        /// <param name="y">координата кнопки по y</param>
        /// <returns>tag</returns>
        private int CoordinatesOfPosition(int x, int y)
        {
            int result = x + y * size;
            return result;
        }
        /// <summary>
        /// получаем значение x,y и выводим значение position
        /// </summary>
        /// <param name="position">tag</param>
        /// <param name="x">координата кнопки по x</param>
        /// <param name="y">координата кнопки по y</param>
        private void PositionOfCoordinates(int position, out int x, out int y)
        {
            x = position % size;
            y = position / size;
        }
        /// <summary>
        /// проверка окончания игры
        /// </summary>
        /// <returns>Закончилась игра или нет</returns>
        public bool CheckEnd()
        {
            for (int y = 0; y < 4; ++y) {
                for (int x = 0; x < 4; ++x) {
                    if (x == 3 && y == 3 && (CoordinatesOfPosition(3, 3) + 1) == 16)
                    {
                        return true;
                    }
                    else {
                        if (map[x, y] != CoordinatesOfPosition(x, y) + 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
