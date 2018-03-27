
    using System.Collections.Generic;
    using System.Linq;

public class Family
{
    private const int GivenAge=30;
    private List<Person> people;

    public Family()
    {
        this.people=new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.people.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.people.OrderByDescending(p => p.Age).First();
    }

    public List<Person> GetPersonByAge()
    {
        return this.people.Where(p => p.Age > GivenAge).OrderBy(p=>p.Name).ToList();

    }
}
