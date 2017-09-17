using System;
using System.Collections.Generic;

public class SturtUp
    {
       public static void Main()
        {
            var accounts=new Dictionary<int, BankAccount>();
            string input;
            while ((input=Console.ReadLine())!="End")
            {
                var cmdArgs = input.Split();
                var command = cmdArgs[0];
                switch (command)
                {
                    case "Create":
                        Create(cmdArgs, accounts);
                        break;
                        case  "Deposit":
                        Deposit(cmdArgs, accounts);
                        break;
                        case  "Withdraw":
                        Withdraw(cmdArgs, accounts);
                        break;
                        case  "Print":
                        Print(cmdArgs, accounts);
                        break;
                }
            }
        }

        private static void Print(string[] cmdArg, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(cmdArg[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id].ToString());
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] cmdArg, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(cmdArg[1]);
            double amount = double.Parse(cmdArg[2]);
            if (accounts.ContainsKey(id))
            {
                if (accounts[id].Balance<amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    accounts[id].Withdraw(amount);
                }
                
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] cmdArg, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(cmdArg[1]);
            double amount = double.Parse(cmdArg[2]);
            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }

        }

        private static void Create(string[] cmdArg, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(cmdArg[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                BankAccount acc=new BankAccount();
                acc.ID = id;
                accounts.Add(id,acc);
            }
        }
    }

