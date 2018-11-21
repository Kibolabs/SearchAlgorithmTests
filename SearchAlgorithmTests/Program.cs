using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using SearchAlgorithmTests.KnapSackAlgorithm;

namespace SearchAlgorithmTests
{
    class MainClass
    {
        public List<Food> foods;
        public int capacity;

        public MainClass(List<Food> food, int val)
        {
            this.foods = food;
            this.capacity = val;
        }
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            List<Food> naps = new List<Food>();

            naps.Add(new Food(100, "Burger", 200));
            naps.Add(new Food(180, "Coke", 90));
            naps.Add(new Food(400, "Cookie", 30));
            naps.Add(new Food(237, "Wine", 300));
            naps.Add(new Food(38, "Apple", 210));
            naps.Add(new Food(487, "Chocolate", 190));
            naps.Add(new Food(20, "Water", 47));
            naps.Add(new Food(90, "Diet Coke", 80));
            naps.Add(new Food(237, "Pineaple Juice", 200));
            naps.Add(new Food(78, "Cranberry Juice", 320));


            MainClass main = new MainClass(naps, 15);
            main.display();
            KnapSack knap= MainClass.solve();
            knap.display();


        }
        public void display()
        {
            if (foods != null && foods.Count > 0)
            {
                Console.WriteLine("Knapsack problem");
                Console.WriteLine("Capacity : " + capacity);
                Console.WriteLine("Items :");

                foreach (Food food in foods)
                {
                    Console.WriteLine("- " + food.str());
                }
            }
        }


        public KnapSack solve()
        {
            int NB_ITEMS = foods.Count;
            // we use a matrix to store the max value at each n-th item
            int[,] matrix = new int[NB_ITEMS + 1, capacity + 1];

            // first line is initialized to 0
            for (int i = 0; i <= capacity; i++)
                matrix[0, i] = 0;

            // we iterate on items
            for (int i = 1; i <= NB_ITEMS; i++)
            {
                // we iterate on each capacity
                for (int j = 0; j <= capacity; j++)
                {
                    if (foods[i - 1].Price > j)
                        matrix[i, j] = matrix[i - 1, j];
                    else
                        // we maximize value at this rank in the matrix
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i - 1, j - foods[i - 1].Price]
                                                + foods[i - 1].Calolie);
                }
            }

            int res = matrix[NB_ITEMS, capacity];
            int w = capacity;
            List<Food> itemsSolution = new List<Food>();

            for (int i = NB_ITEMS; i > 0 && res > 0; i--)
            {
                if (res != matrix[i - 1, w])
                {
                    itemsSolution.Add(foods[i - 1]);
                    // we remove items value and weight
                    res -= foods[i - 1].Calolie;
                    w -= foods[i - 1].Price;
                }
            }
            return new KnapSack(itemsSolution, matrix[NB_ITEMS, capacity]);
        }

    }
}
