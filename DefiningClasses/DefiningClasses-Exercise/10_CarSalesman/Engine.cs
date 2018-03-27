
public class Engine
{
    private string model;
    private int power;
    private int displacement;
    private string efficienty;

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        this.displacement = 0;
        this.efficienty = "";
    }

    public string Model { get => this.model; private set => this.model = value; }
    public int Power { get => this.power; private set => this.power = value; }
    public int Displacement { get => this.displacement; set => this.displacement = value; }
    public string Efficienty { get => this.efficienty;  set => this.efficienty = value; }

}
