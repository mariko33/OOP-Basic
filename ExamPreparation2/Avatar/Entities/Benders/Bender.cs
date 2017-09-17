public abstract class Bender
{
    private string name;
    private int power;

    protected Bender(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    public virtual double TotalPower()
    {
        return this.power;
    }
    
    public override string ToString()
    {
        int index = this.GetType().Name.IndexOf("Bender");
        string currentName = this.GetType().Name.Insert(index, " ");
        return $"{currentName}: {this.name}, Power: {this.power},";
    }
}
