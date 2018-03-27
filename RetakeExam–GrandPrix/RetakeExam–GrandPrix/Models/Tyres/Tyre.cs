
using System;

public abstract class Tyre
{
    private double degradation;
    
    protected Tyre(double hardness)
    {
        
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name { get; protected set; }
    public double Hardness { get; private set; }
    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {

            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public abstract void ReduceDegradation();

}
