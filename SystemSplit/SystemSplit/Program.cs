using System;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        //string input = "RegisterPowerHardware(HDD, 200, 200)";
        //var args = input.Split(new[] {"(", ")", ", "}, StringSplitOptions.RemoveEmptyEntries);
        //Console.WriteLine(String.Join(Environment.NewLine, args));
        //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

        Engine engine=new Engine();
        engine.Run();


    }

}  

