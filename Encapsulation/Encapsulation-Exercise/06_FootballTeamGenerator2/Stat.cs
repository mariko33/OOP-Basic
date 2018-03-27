  using System;

public class Stat
  {
      private string name;
      private int level;

      public Stat(string name, int level)
      {
          this.Name = name;
          this.Level = level;
       
      }

      public string Name { get; set; }

      public int Level
      {
          get => this.level;
          set
          {
              if (value<0||value>100)
              {
                  throw new ArgumentException($"{this.Name} should be between 0 and 100.");
              }
              this.level = value;
          }
      }
  }
