
    using System.Collections.Generic;

public class AddCollection:IAdd
    {

        public AddCollection()
        {
            this.Collection=new List<string>();
        }
        
        public List<string> Collection { get; set; }
        
        public int Add(string str)
        {
           this.Collection.Add(str);
            return this.Collection.Count-1;
        }
    }
