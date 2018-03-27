
public class Engine
{
    private int speed;
    private int power;

    public Engine(int speed, int power)
    {
        this.speed = speed;
        this.power = power;
    }

    public int Speed { get => this.speed; private set => this.speed = value; }
    public int Power { get => this.power; private set => this.power = value; }
}
