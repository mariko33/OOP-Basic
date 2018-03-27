
    using System.Collections.Generic;

public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reseveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam=new List<Person>();
            this.reseveTeam=new List<Person>();
        }

        public IReadOnlyList<Person> FirstTeam { get; }
        public IReadOnlyList<Person> ReaserveTeam { get;}

        public void AddPlayer(Person person)
        {
        if (person.Age <= 40)firstTeam.Add(person);
        else reseveTeam.Add(person);
        
        }
    }
