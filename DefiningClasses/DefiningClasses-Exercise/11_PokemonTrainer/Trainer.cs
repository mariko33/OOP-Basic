
using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    private string name;
    private int numberOfBadges;
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.name = name;
        this.numberOfBadges = 0;
        this.pokemons=new List<Pokemon>();
    }

    public string Name { get => this.name; }
    public int NumberOfBudges { get=>this.numberOfBadges; }

    public List<Pokemon> Pokemons { get=>this.pokemons;  }
    
    public void CheckAddingBadge(string element)
    {
        if (this.GetAlivePokemons().Any(p => p.Element == element)) numberOfBadges++;
        else this.GetAlivePokemons().ForEach(p=>p.LoseHealth());
    }

    public List<Pokemon> GetAlivePokemons()
    {
        return this.pokemons.Where(p => p.Health > 0).ToList();
    }
    
    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public override string ToString()
    {
        return $"{this.name} {this.numberOfBadges} {this.GetAlivePokemons().Count}";
    }
}
