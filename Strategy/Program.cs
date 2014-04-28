using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    public interface IRun
    {
        void Run();
    }

    public interface IOpenTrunk
    {
        void OpenTrunk();
    }

    public class AutoOpenTrunk : IOpenTrunk
    {
        public void OpenTrunk()
        {
            Console.WriteLine("Auto Open Trunk");
        }
    }

    public class ManualOpenTrunk : IOpenTrunk
    {
        public void OpenTrunk()
        {
            Console.WriteLine("Manual open Trunk");
        }
    }

    public class BiYaDi : Car
    {
        public BiYaDi()
        {
            OpenTrunkBehavior=new ManualOpenTrunk();    
        }

    }

    public abstract class Car
    {
        protected IRun RunBehavior;
        protected IOpenTrunk OpenTrunkBehavior;
        public string Color { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }


        public void SetRunBehavior(IRun run)
        {
            RunBehavior = run;
        }

        public void SetOpenTrunkBehavior(IOpenTrunk openTrunk)
        {
            OpenTrunkBehavior = openTrunk;
        } 

        public void Run()
        {
            RunBehavior.Run();
        }

        public void OpenTrunk()
        {
            OpenTrunkBehavior.OpenTrunk();   
        }
    }

    public  class Program
    {
        static void Main(string[] args)
        {
            var car = new BiYaDi();
            car.OpenTrunk();
            car.SetOpenTrunkBehavior(new AutoOpenTrunk());
            car.OpenTrunk();
            Console.ReadLine();
        }
    }
}
