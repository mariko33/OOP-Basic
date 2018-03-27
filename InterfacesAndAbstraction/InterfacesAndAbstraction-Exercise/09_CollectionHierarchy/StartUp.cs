using System;


class StartUp
{
    static void Main()
    {
        var strs = Console.ReadLine().Split();
        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemove = new AddRemoveCollection();
        MyList myList = new MyList();

        AddToAddCollection(strs, addCollection);
        Console.WriteLine();
        AddToAddCollection(strs, addRemove);
        Console.WriteLine();
        AddToAddCollection(strs, myList);
        Console.WriteLine();
        

        int numberOfRemove = int.Parse(Console.ReadLine());

        RemoveFromCollection(numberOfRemove,addRemove);
        Console.WriteLine();
        RemoveFromCollection(numberOfRemove,myList);
       


    }

    private static void RemoveFromCollection(int numberOfRemove, IRemove collection)
    {
        for (int i = 0; i < numberOfRemove; i++)
        {
            Console.Write(collection.Remove()+" ");
        }

    }

    private static void AddToAddCollection(string[] strs, IAdd collection)
    {
        foreach (var s in strs)
        {
            Console.Write(collection.Add(s) + " ");
        }
    }

   
}



