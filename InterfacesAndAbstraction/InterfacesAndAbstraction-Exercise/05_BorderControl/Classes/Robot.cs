  public class Robot:ISociety,INameable
    {
        public Robot(string nameOrModel, string id)
        {
            this.NameOrModel = nameOrModel;
            this.Id = id;
        }
        
        public string NameOrModel { get; private set; }
        public string Id { get;private set; }
    }
