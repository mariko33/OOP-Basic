
using System.Collections.Generic;

public class MyList : IAdd, IRemove, ILength
{
    
    
    public MyList()
    {
        this.Collection = new List<string>();
    }

    public List<string> Collection { get; set; }

    public int Length { get=>this.Collection.Count; }

    public int Add(string str)
    {
        this.Collection.Insert(0, str);
        return 0;
    }

    public string Remove()
    {
        string startIndex = this.Collection[0];
        this.Collection.RemoveAt(0);
        return startIndex;
    }

    
}
