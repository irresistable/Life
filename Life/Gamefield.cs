using System;

namespace Life
{
    public class Gamefield 
    {
        private bool[,] _gamefield;

        public Gamefield(int length, int height)
        {
            _gamefield = new bool[length+1, height+1]; //без добавления единицы в размерность не хочет работать.
        }
        public bool this[int x_pos, int y_pos]
        {
            get { return _gamefield[x_pos, y_pos]; }
            set { _gamefield[x_pos, y_pos] = value; }
        }
        public int GetLength
        {
            get { return _gamefield.GetLength(0)-1; }
        }
        public int GetHeight
        {
            get { return _gamefield.GetLength(1)-1; }
        }
        public int GetPopulation
        {
            get
            {
                int amount = 0;
                for (int y_pos = 0; y_pos < _gamefield.GetLength(1) - 1; y_pos++)
                {
                    for (int x_pos = 0; x_pos < _gamefield.GetLength(0) - 1; x_pos++)
                    {
                        if (_gamefield[x_pos, y_pos])
                        {
                            amount++;
                        }
                    }
                }
                return amount;
            }
        }
        public string Flatten 
        {
            get
            {
                string flatten=null;
                for (int y_pos = 0; y_pos < _gamefield.GetLength(1) - 1; y_pos++)
                {
                    for (int x_pos = 0; x_pos < _gamefield.GetLength(0) - 1; x_pos++)
                    {
                        flatten = flatten + _gamefield[x_pos, y_pos].ToString();
                    }
                }
                return flatten;
            }
        }

    }
}
