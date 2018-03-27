
    public class StreetExtraordinaire:Cat
    {
        public StreetExtraordinaire(string name,int decibelsOfMeows) : base(name)
        {
            this.Breed = "StreetExtraordinaire";
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public int DecibelsOfMeows { get; set; }

        public override string ToString()
        {
            return base.ToString()+$" {this.DecibelsOfMeows}";
        }
    }
