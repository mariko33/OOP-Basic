
	using System;

public class StartUp
	{
		public static void Main(string[] args)
		{
		Animal cat=new Cat("Pesho", "Wiskas");
		Animal dog=new Dog("Gosho", "Meat");
			Console.WriteLine(cat.ExplainMyself());
			Console.WriteLine(dog.ExplainMyself());

		}
	}

