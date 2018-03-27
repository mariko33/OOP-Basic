using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;


public class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

       
        
        public Person(string name, int age, List<BankAccount> accounts)
        {
            this.name = name;
            this.age = age;
            this.accounts = accounts;
        }

        public Person(string name, int age)
            : this(name, age, new List<BankAccount>())
        { }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public List<BankAccount> Accounts
        {
            get => this.accounts;
            set => this.accounts = value;
        }

        public decimal GetBalance()
        {
            return this.accounts.Sum(a => a.Balance);
        }
    }
