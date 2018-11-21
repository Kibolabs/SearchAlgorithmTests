using System;
using System.Collections.Generic;

namespace SearchAlgorithmTests.KnapSackAlgorithm
{
    public class KnapSack
    {
        public List<Food> foods;
        public int value;

        public KnapSack(List<Food> food, int val)
        {
            this.foods = food;
            this.value = val;
        }

        public void display()
        {
            if (foods != null)
            {
                Console.WriteLine("\nKnapsack solution");
                Console.WriteLine("Value = " + value);
                Console.WriteLine("Items to pick :");

                foreach (Food food in foods)
                {
                    Console.WriteLine("- " + food.str());
                }
            }
        }
    }
}
