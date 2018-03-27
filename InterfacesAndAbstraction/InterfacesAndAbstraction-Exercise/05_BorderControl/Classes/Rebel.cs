
    public class Rebel:INameable,IBuyer
    {
        public Rebel(string nameOrModel, int age, string group)
        {
            this.NameOrModel = nameOrModel;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        
        public string NameOrModel { get; private set; }
        public int Age  { get;private set; }
        public string Group { get; private set; }
        public int Food { get; private set; }
        
        
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
