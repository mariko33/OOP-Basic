
    using System;

public class Pet:INameable,IBirthdate
    {
        public Pet(string nameOrModel, string birthdate)
        {
            this.NameOrModel = nameOrModel;
            this.Birthdate = birthdate;
        }
        
        public string NameOrModel { get; set; }
        public string Birthdate { get; set; }
    }
