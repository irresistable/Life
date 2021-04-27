using System;

namespace Life
{
    public class SwapFields
    {
        public void Replace(ref Gamefield gamefield, ref Gamefield gamefield_new)
        {
            for (int y_pos = 0; y_pos < gamefield.GetHeight; y_pos++)
            {
                for (int x_pos = 0; x_pos < gamefield.GetLength; x_pos++)
                {
                    gamefield[x_pos, y_pos] = gamefield_new[x_pos, y_pos]; //вторым полем затираем первое поле
                    gamefield_new[x_pos, y_pos] = false; //стираем второе поле
                }
            }
        }

        public void Copy(ref Gamefield gamefield, ref Gamefield loopcheck) // должен быть метод проще позвращать копию
        {
            for (int y_pos = 0; y_pos < gamefield.GetHeight; y_pos++)
            {
                for (int x_pos = 0; x_pos < gamefield.GetLength; x_pos++)
                {
                    loopcheck[x_pos, y_pos] = gamefield[x_pos, y_pos]; 
                }
            }
        }
    }
}
