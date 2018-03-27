
public class Mammal : Animal
{


    public Mammal(string name, double weight,string livingRegion) : 
        base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; set; }

    public override void ProduceSound()
    {
       
    }

    public override void Feed(Food food)
    {
        
    }

    public override string ToString()
    {
        return base.ToString()+$" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
