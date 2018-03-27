
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, double salary, string corps, List<IRepair> repairs)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public List<IRepair> Repairs { get; set; }

    public override string ToString()
    {
        StringBuilder sb=new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Repairs:");
        this.Repairs.ForEach(r=>sb.AppendLine(r.ToString()));
        
        return sb.ToString().TrimEnd();
    }
}
