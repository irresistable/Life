using System;

namespace Life
{
    public class RandomGenerator
    {

        private int height;
        private int length;
        private int amount;
        private Random Random = new Random();
        public RandomGenerator(int length, int height, int amount)
        {
            this.length = length;
            this.height = height;
            this.amount = amount;
        }


        
    }
}
