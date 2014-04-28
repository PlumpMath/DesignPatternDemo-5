using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    public interface Subject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NoticeObservers(SubjectEventArgs eventArgs);
    }

    public class ATMSubject:Subject
    {
        public IList<IObserver> Observers { get; set; }

        public ATMSubject()
        {
            Observers=new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NoticeObservers(SubjectEventArgs eventArgs)
        {
            if (Observers == null) return;
            foreach (var observer in Observers)
            {
                if (observer != null)
                {
                    observer.Update(eventArgs);
                }
            }
        }

        public void BankTransfer(string rollIn,string rollOut,double money)
        {
            var args = new BankTransferSubjectEventArgs()
                {
                    RollInCardNumber = rollIn,
                    RollOutCardNumber = rollOut,
                    Money = money
                };
            NoticeObservers(args);
        }
    }

    public abstract class SubjectEventArgs
    {
        public string Message { get; set; }
    }

    public class BankTransferSubjectEventArgs : SubjectEventArgs
    {
        public BankTransferSubjectEventArgs()
        {
            Message = "This is a Bank Transfer";
        }

        public string RollInCardNumber { get; set; }
        public string RollOutCardNumber { get; set; }
        public double Money { get; set; }
    }

    public interface IObserver
    {
        void Update(SubjectEventArgs eventArgs);
    }

    public class Bank : IObserver
    {
        public void Update(SubjectEventArgs eventArgs)
        {
            var args = eventArgs as BankTransferSubjectEventArgs; 
            Console.WriteLine(args.RollOutCardNumber+" To "+args.RollInCardNumber+args.Money);
        }
    }

    public class Display : IObserver
    {
        public void Update(SubjectEventArgs eventArgs)
        {
            Console.WriteLine("Display:"+eventArgs.Message);
        }
    }












    class Program
    {
        static void Main(string[] args)
        {
            var atm = new ATMSubject();
            var display = new Display();
            var bank = new Bank();
            atm.RegisterObserver(bank);
            atm.RegisterObserver(display);
            atm.BankTransfer("aaa","bbb",50);
            Console.ReadLine();
        }
    }
}
