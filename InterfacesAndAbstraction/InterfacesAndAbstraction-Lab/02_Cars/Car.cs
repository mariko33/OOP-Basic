
    using System.Text;

public abstract class Car:ICar
    {
    public string Model { get; private set; }
        public string Color { get; private set; }

        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {Model}");
            sb.AppendLine($"{this.Start()}");
            sb.Append($"{this.Stop()}");
            return sb.ToString();
        }
    }
