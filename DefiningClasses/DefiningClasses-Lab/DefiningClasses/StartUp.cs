

public class StartUp
{
    public static void Main()
    {
        //    Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        //    string input;
        //    while ((input = Console.ReadLine()) != "End")
        //    {
        //        var commands = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //        switch (commands[0])
        //        {
        //            case "Create":
        //                CreateBankAccount(int.Parse(commands[1]), accounts);
        //                break;
        //            case "Deposit":
        //                Deposit(int.Parse(commands[1]), decimal.Parse(commands[2]), accounts);
        //                break;
        //            case "Withdraw":
        //                Withdraw(int.Parse(commands[1]), decimal.Parse(commands[2]), accounts);
        //                break;
        //            case "Print":
        //                Print(int.Parse(commands[1]), accounts);
        //                break;

        //        }
        //    }
        //}

        //private static void Print(int id, Dictionary<int, BankAccount> accounts)
        //{
        //    if (accounts.ContainsKey(id))
        //    {
        //        var account = accounts[id];
        //        Console.WriteLine(account.ToString());
        //    }
        //    else
        //    {
        //        Console.WriteLine("Account does not exist");
        //    }

        //}

        //private static void Withdraw(int id, decimal amount, Dictionary<int, BankAccount> accounts)
        //{
        //    if (accounts.ContainsKey(id))
        //    {
        //        var account = accounts.FirstOrDefault(a=>a.Value.Id==id);
        //        if (account.Value.Balance>=amount)
        //        {
        //            account.Value.Withdraw(amount);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Insufficient balance");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Account does not exist");
        //    }
        //}

        //private static void Deposit(int id, decimal amount, Dictionary<int, BankAccount> accounts)
        //{
        //    if(accounts.ContainsKey(id))
        //    {
        //        var account = accounts.FirstOrDefault(a => a.Value.Id == id);
        //        account.Value.Deposit(amount);

        //    }
        //    else
        //    {
        //        Console.WriteLine("Account does not exist");
        //    }
        //}

        //private static void CreateBankAccount(int id, Dictionary<int, BankAccount> accounts)
        //{
        //    if (accounts.ContainsKey(id))
        //    {
        //        Console.WriteLine("Account already exists");
        //    }
        //    else
        //    {
        //        accounts.Add(id,new BankAccount(id));
        //    }
        //}
    }

}