
    public class Child
    {
        private string name;
        private string birthDay;

        public Child(string name, string birthDay)
        {
            this.name = name;
            this.birthDay = birthDay;
        }

        public override string ToString()
        {
            return $"{this.name} {this.birthDay}";
        }
    }
