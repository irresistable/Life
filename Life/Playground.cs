using System;
using System.Collections.Generic;

namespace Life
{
    public class Playground
    {
        private Random Random = new Random();
        private int height; //размер поля по горизонтали
        private int length; //размер поля по вертикали
        private int number; //количество точек при инициации поля
        private int timer = 0; //количество выводов поля на экран
        private int RandomPlacer(int limit)
        {
            return Random.Next(limit);
        }
        
        private void PlaygroundFirstFill(int number, ref Gamefield gamefield)
        {
            for (int i = 0; i <number; i++) // тут рандомайзим
            {
                gamefield[RandomPlacer(gamefield.GetLength), RandomPlacer(gamefield.GetHeight)] = true;
            }
        }
        public void GameStart(int length, int height, int number)
        {
            this.length = length;
            this.height = height;
            this.number = number;

            SwapFields swapFields = new SwapFields(); //тут второе поле копируем в первое и потом затираем второе поле 0

            Gamefield gamefield = new Gamefield(length, height); //тут первое поле
            Gamefield gamefield_new = new Gamefield(length, height); //тут второе поле
            Gamefield loopcheck = new Gamefield(length, height); //тут второе поле

            PlaygroundFirstFill(number, ref gamefield); //заполнили рандомом первое поле

            for (; ; )
            {
                swapFields.Copy(ref gamefield, ref loopcheck); //скопировали первое поле в массив для циклопроверки

                CheckField(ref gamefield, ref gamefield_new); //проверили первое поле и положили результат во второе

                if (gamefield.Flatten == gamefield_new.Flatten) //сравнили первое поле и второе
                {
                    break;
                }

                else
                {
                    Console.Clear();
                    //Console.SetCursorPosition(0, 0);
                    FieldToConsole(ref gamefield); //вывели первое поле на экран
                  
                    swapFields.Replace(ref gamefield, ref gamefield_new); // второе поле скопировали в первое и потом затерли второе

                    CheckField(ref gamefield, ref gamefield_new); //проверили первое поле и положили результат во второе
                    
                    if (gamefield_new.Flatten == loopcheck.Flatten) //проверили, нет ли цикличной перерисовки
                    {
                        break;
                    }
                }
                //System.Threading.Thread.Sleep(100);
            }
            Console.SetCursorPosition(0, 0);
            FieldToConsole(ref gamefield);
            Console.WriteLine($"\nGame over at step {timer} with population left: {gamefield.GetPopulation}\n");
        }

        private void CheckField(ref Gamefield gamefield, ref Gamefield gamefield_new) //проверяем первое поле, результат кладем во второе
        {
            for (int y_pos = 0; y_pos < height; y_pos++) 
            {
                for (int x_pos = 0; x_pos < length; x_pos++)
                {
                   int neighboursCount = NeighboursCount(x_pos, y_pos, ref gamefield);
                    if (CellCheck(x_pos, y_pos, neighboursCount, ref gamefield))
                    {
                        gamefield_new[x_pos, y_pos] = true;
                    }
                }
            }
        }

        private bool CellCheck(int x_position, int y_position, int neighbourCount, ref Gamefield gamefield)
        {
            if (gamefield[x_position, y_position] && (neighbourCount == 2 || neighbourCount == 3))
            {
                {
                    return true;
                }
            }
            if (!(gamefield[x_position, y_position]) && neighbourCount == 3)
                {
                    return true;
                }

            else
                {
                    return false;
                }
        }

        public int NeighboursCount(int x_position, int y_position, ref Gamefield gamefield)
        {
            bool[] genome = new bool [9]; //считать клетки-соседи буду через массив, иначе не получается
            int genomesum = 0;
            int left = x_position - 1; //границы клеток
            int right = x_position + 1;
            int top = y_position - 1;
            int bottom = y_position + 1;
            
            if (x_position == 0) //если клетка у края, подставляем с противоположенной границы
            {
                left = length - 1;
            }
            if (x_position == length)
            {
                right = 0;
            }

            if (y_position == 0)
            {
                top = height - 1;
            }

            if (y_position == height)
            {
                bottom = 0;
            }
            //осматриваем всех соседей вокруг
            genome[1] = gamefield[left, top];
            genome[2] = gamefield[x_position, top];
            genome[3] = gamefield[right, top];
            genome[4] = gamefield[right, y_position];
            genome[5] = gamefield[right, bottom];
            genome[6] = gamefield[x_position, bottom];
            genome[7] = gamefield[left, bottom];
            genome[8] = gamefield[left, y_position];
            //пересчитываем живых
            for (int genomeCircle = 1; genomeCircle < 9; genomeCircle++)
            {
                if (genome[genomeCircle])
                {
                    genomesum++; //возвращаем количество клеток-соседей
                }
            }
           return genomesum;
        }
        
        public void FieldToConsole(ref Gamefield gamefield)
        {
            for (int y_pos = 0; y_pos < height; y_pos++)
            {
                for (int x_pos = 0; x_pos < length; x_pos++)
                {
                    if (gamefield[x_pos, y_pos])
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
            }
            timer++;
            Console.Write($"\ntimer: {timer}   Population: {gamefield.GetPopulation}\n");
        }
    }
}