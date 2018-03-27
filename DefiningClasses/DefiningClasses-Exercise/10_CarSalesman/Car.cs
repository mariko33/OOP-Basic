using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private int weight;
    private string color;
    private const string Def = "n/a";

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = 0;
        this.Color = "";
    }
    public string Model { get=>this.model; private set=>this.model=value; }
    public Engine Engine { get=>this.engine; set=>this.engine=value; }
    public int Weight { get=>this.weight;  set=>this.weight=value; }
    public string Color { get=>this.color;  set=>this.color=value; }

    public override string ToString()
    {
        StringBuilder builder=new StringBuilder();
        builder.AppendLine(this.Model+":");
        builder.AppendLine($"  {this.Engine.Model}:");
        builder.AppendLine($"    Power: {this.Engine.Power}");
        builder.AppendLine($"    Displacement: {(this.Engine.Displacement==0?Def:this.Engine.Displacement.ToString())}");
        builder.AppendLine($"    Efficiency: {(this.Engine.Efficienty==""?Def:this.Engine.Efficienty)}");
        builder.AppendLine("  Weight: "+ (this.Weight == 0 ? Def : this.Weight.ToString()));
        builder.Append("  Color: "+(this.Color==""?Def:this.Color));

        return builder.ToString();
    }
}
