
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, double salary, string corps,IList<IMission>missions) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions =  missions;
    }

    public IList<IMission> Missions { get;private set; }

    public void AddMission(Mission mission)
    {
        this.Missions.Add(mission);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");
        this.Missions.ToList().ForEach(m => sb.AppendLine(m.ToString()));

        return sb.ToString().TrimEnd();
    }
}