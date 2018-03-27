
    public class Siamese:Cat
    {
        public Siamese(string name,int earSize) : base(name)
        {
            this.Breed = "Siamese";
            this.EarSize = earSize;
        }

        public int EarSize { get; set; }

        public override string ToString()
        {
            return base.ToString()+$" {this.EarSize}";
        }
    }
