  public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            
        }
        
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract void ProduceSound();

        public abstract void Feed(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
