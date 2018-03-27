
    public class Cymric:Cat
    {
        public Cymric(string name,double furLength) : base(name)
        {
            this.Breed = "Cymric";
            this.FurLength = furLength;
        }

        public double FurLength { get; set; }

        public override string ToString()
        {
            return base.ToString()+$" {this.FurLength:f2}";
        }
    }
