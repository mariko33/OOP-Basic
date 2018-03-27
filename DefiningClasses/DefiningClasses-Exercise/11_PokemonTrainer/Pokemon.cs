
public class Pokemon
{
    private string name;
    private string element;
    private int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.Element = element;
        this.Health = health;
    }

    

    public string Element { get=>this.element; set=>this.element=value; }

    public int Health { get=>this.health; set=>this.health=value; }

    public void LoseHealth()
    {
        this.health -= 10;
    }

}
