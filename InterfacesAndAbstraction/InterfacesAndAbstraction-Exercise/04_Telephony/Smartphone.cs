using System;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    public string Call(string phoneNumber)
    {
        if (phoneNumber.Any(c => !char.IsDigit(c))) return "Invalid number!";
          return $"Calling... {phoneNumber}";

    }

    public string Browse(string site)
    {
        if (site.Any(s => char.IsDigit(s))) return "Invalid URL!";
        return $"Browsing: {site}!";
    }
}
