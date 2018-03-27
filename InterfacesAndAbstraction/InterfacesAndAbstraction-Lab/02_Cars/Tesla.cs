
using System.Text;

public class Tesla : Car, IElectricCar
{

    public int Battery { get; private set; }

    public Tesla(string model, string color,int battery) : base(model, color)
    {
        this.Battery = battery;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {this.GetType().Name} {Model} with {this.Battery} Batteries");
        sb.AppendLine($"{this.Start()}");
        sb.Append($"{this.Stop()}");
        return sb.ToString();
    }
}
