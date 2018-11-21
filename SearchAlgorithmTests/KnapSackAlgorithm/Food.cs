using System;
namespace SearchAlgorithmTests
{
    public class Food
    {
        private string v1;
        private int v2;
        private int v3;

        public int Calolie { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Food(int cal, string name, int price){
            this.Calolie = cal;
            this.Name = name;
            this.Price = price;
        }

        public String str()
        {
            return Name + " [value = " + Calolie + ", weight = " + Price + "]";
        }

    }
}
