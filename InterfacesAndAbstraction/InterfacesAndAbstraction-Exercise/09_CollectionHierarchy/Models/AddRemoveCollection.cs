
    using System.Collections.Generic;

public class AddRemoveCollection:IAdd,IRemove
    {

        public AddRemoveCollection()
        {
            this.Collection=new List<string>();
        }
        
        public List<string> Collection { get; set; }
        
        public int Add(string str)
        {
            this.Collection.Insert(0,str);
            return 0;
        }

        public string Remove()
        {
            int lastIndex = this.Collection.Count - 1;
            string lastItem = this.Collection[lastIndex];
            this.Collection.RemoveAt(lastIndex);
            return lastItem;
        }
    }
