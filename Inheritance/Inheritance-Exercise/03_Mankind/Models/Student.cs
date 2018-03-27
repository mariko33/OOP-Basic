
    using System;
    using System.Linq;
    using System.Text;

public class Student:Human
    {
        private string facultyNumber;
        
        public Student(string firstName, string lastName,string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            set
            {

                if (value.Length>10||value.Length<5||!value.All(v=>char.IsLetterOrDigit(v)))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.Append(base.ToString())
                .AppendLine($"Faculty number: {this.FacultyNumber}");
            return sb.ToString();
        }
    }