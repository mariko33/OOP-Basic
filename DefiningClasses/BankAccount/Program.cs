using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        public class BankAccount
        {
            private int id;
            private double balance;

            public BankAccount()
            {

            }

            public int Id { get; set; }
            public double Balance { get; set; }


        }
        public static void Main(string[] args)
        {
            BankAccount acc=new BankAccount();
            acc.Id = 1;
            acc.Balance = 15;
            Console.WriteLine($"Account {acc.Id}, balance {acc.Balance}");
        }
    }
}
