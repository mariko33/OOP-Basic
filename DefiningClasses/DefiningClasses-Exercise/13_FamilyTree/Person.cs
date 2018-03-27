
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

public class Person
{
    public Person()
    {
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

   
    public string FullName { get; set; }
    
    public string Birthday { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public override string ToString()
    {
        return $"{this.FullName} {this.Birthday}";
    }
}
