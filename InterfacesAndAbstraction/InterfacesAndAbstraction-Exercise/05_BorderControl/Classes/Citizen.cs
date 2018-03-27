 using System;

public class Citizen:ISociety,INameable,IBirthdate,IBuyer
    {
        public Citizen(string nameOrModel, int age, string id, string birthdate)
        {
            this.NameOrModel = nameOrModel;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }
        
        public string NameOrModel { get; private set; }
        public int Age { get;private set; }
        public string Id { get; private set; }
        public string Birthdate { get;private set; }
        public int Food { get; private set; }
        
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
