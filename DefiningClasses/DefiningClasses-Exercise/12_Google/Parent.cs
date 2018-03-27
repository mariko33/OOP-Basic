
    public class Parent
    {
        private string name;
        private string birthDay;

        public Parent(string name, string birthDay)
        {
            this.name = name;
            this.birthDay = birthDay;
        }

        public override string ToString()
        {
            return $"{this.name} {this.birthDay}";
        }
    }
