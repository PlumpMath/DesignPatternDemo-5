using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
//            SushiStoreBase store = new XunYangSushiStore();
//            store.OrderSushi("tomato");
//            store = new XiAnSushiStore();
//            store.OrderSushi("ham");

            BuildingMaterialsStoreBase buildingMaterialsStore=new CementStore();
            buildingMaterialsStore.ShowPrice();
            buildingMaterialsStore=new TimberStore();
            buildingMaterialsStore.ShowPrice();
            Console.ReadLine();
        }
    }

    public abstract class SushiStoreBase
    {
        public void OrderSushi(string type)
        {
            var sushi = CreateSushi(type);
            sushi.Prepare();
            sushi.Packet();
            sushi.Cut();
            sushi.PutInBox();
        }

        protected abstract SushiBase CreateSushi(string type);
    }

    public class XunYangSushiStore : SushiStoreBase
    {
        protected override SushiBase CreateSushi(string type)
        {
            switch (type)
            {
                case "tomato":
                    return new XunYangTomatoSushi();
                    break;
                case "ham":
                    return new XunYangHamSushi();
                    break;
            }
            return null;
        }
    }

    public class XiAnSushiStore : SushiStoreBase
    {
        protected override SushiBase CreateSushi(string type)
        {
            switch (type)
            {
                case "tomato":
                    return new XiAnTomatoSushi();
                case "ham":
                    return new XiAnHamSushi();
            }
            return null;
        }
    }

    public abstract class SushiBase
    {
        protected abstract string Name { get; }

        public void Prepare()
        {
            Console.WriteLine(Name+" is being prepared");
        }

        public  void Packet()
        {
            Console.WriteLine(Name + " is being packeted");
        }

        public void Cut()
        {
            Console.WriteLine(Name + " is being cuted");
        }

        public void PutInBox()
        {
            Console.WriteLine("done");
        }
    }

    public class XunYangTomatoSushi : SushiBase
    {
        protected override string Name
        {
            get { return "XunYang And Tomato Sushi"; }
        }
    }
    public class XunYangHamSushi : SushiBase
    {
        protected override string Name
        {
            get { return "XunYang And Ham Sushi"; }
        }
    }

    public class XiAnTomatoSushi : SushiBase
    {
        protected override string Name
        {
            get { return "XiAn And Tomato Sushi"; }
        }
    }
    public class XiAnHamSushi : SushiBase
    {
        protected override string Name
        {
            get { return "XiAn And Ham Sushi"; }
        }
    }
}
