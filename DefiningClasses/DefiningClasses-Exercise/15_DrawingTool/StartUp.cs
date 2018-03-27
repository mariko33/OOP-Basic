using System;


class StartUp
{

    public static void Main()
    {
        var figureType = Console.ReadLine();
        if (figureType.Equals("Square"))
            DrawingTool.DrawFigure(new Square(int.Parse(Console.ReadLine())));
        else
            DrawingTool.DrawFigure(new Rectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
    }

}

