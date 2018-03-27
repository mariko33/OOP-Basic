
using System;

public abstract class Stat
{
    private int statNumber;

    public Stat(int statNumber)
    {
        this.StatNumber = statNumber;
    }
    public int StatNumber
    {
        get => this.statNumber;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{this.GetType().Name} should be between 0 and 100.");
            }
            this.statNumber = value;
        }
    }

  
    
}
