
    using System.Collections.Generic;
    using System.Text;

public class LeutenantGeneral:Private,ILeutenantGeneral
    {
        public LeutenantGeneral(int id, string firstName, string lastName, double salary,List<IPrivate>privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public List<IPrivate> Privates { get;private set; }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            this.Privates.ForEach(p=>sb.AppendLine(p.ToString()));
            
            return sb.ToString().TrimEnd();
        }
    }
