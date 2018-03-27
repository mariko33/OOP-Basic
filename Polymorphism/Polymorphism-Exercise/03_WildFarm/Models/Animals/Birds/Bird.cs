
public class Bird : Animal
{

    public Bird(string name, double weight,double wingSize) 
        : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public double WingSize { get; set; }

    public override void ProduceSound()
    {
        throw new System.NotImplementedException();
    }

    public override void Feed(Food food)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() + $" {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}
