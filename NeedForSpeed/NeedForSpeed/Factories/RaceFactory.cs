using System;

public class RaceFactory
{
    public static Race GetRace(string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length,route,prizePool);
                break;
            case "Drag":
                return new DragRace(length,route,prizePool);
                break;
            case "Drift":
                return new DriftRace(length,route,prizePool);
                break;
                default:throw new ArgumentException();
        }
    }
}
