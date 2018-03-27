  public class HardTyre:Tyre
    {
        public HardTyre( double hardness) : base(hardness)
        {
            this.Name = "Hard";
        }

        public override void ReduceDegradation()
        {
            this.Degradation -= this.Hardness;
        }
    }
