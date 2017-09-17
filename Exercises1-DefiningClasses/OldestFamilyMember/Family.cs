using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
   public class Family
   {
       private List<Person> people;

       public Family()
       {
           this.people=new List<Person>();
       }
       public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

       public void AddMember(Person person)
       {
           this.People.Add(person);
       }

       public Person GetOldestMember()
       {
           var personSort = this.People.OrderByDescending(p => p.Age);
           return personSort.FirstOrDefault();
       }


   }
}
