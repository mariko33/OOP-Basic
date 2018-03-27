
    public class Cargo
    {
        private string type;
        private int weight;

        public Cargo(string type, int weight)
        {
            this.type = type;
            this.weight = weight;
        }
         
        public string Type { get=>this.type; private set=>this.type=value; }
        public int Weight { get=>this.weight; set=>this.weight=value; }
    }
