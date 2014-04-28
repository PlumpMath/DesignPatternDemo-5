using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator
{
    public abstract class FoodBase
    {
        public FoodBase Food { get; set; }
        public virtual string Name { get;protected set; }
        public virtual string FoodFullName {
            get { return (Food!=null?Food.FoodFullName:string.Empty)+Name; }
        }

        public virtual double Money { get; protected set; }
        public virtual double FoodFullMoney
        {
            get { return (Food != null ? Food.FoodFullMoney : 0)+Money; }
        }

        protected FoodBase()
        {
        }

        protected FoodBase(FoodBase food)
        {
            Food = food;
        }
    }

    public sealed class Rice : FoodBase
    {
        public Rice()
        {
            Name = "Rice";
            Money = 2.00;
        }

    }


    public sealed class Cabbage : FoodBase
    {
        public Cabbage(FoodBase food):base(food)
        {
            Name = "Cabbage";
            Money = 3.00;
        }
    }

    public sealed class GreenPepper : FoodBase
    {
        public GreenPepper(FoodBase food):base(food)
        {
            Name = "GreenPepper";
            Money = 5.00;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rice = new Rice();
            var greenPepperRice = new GreenPepper(rice);
            var cabbageGreenPepperRice = new Cabbage(greenPepperRice);
            Console.WriteLine(cabbageGreenPepperRice.FoodFullName+":"+cabbageGreenPepperRice.FoodFullMoney);
            Console.ReadLine();
        }
    }
}
