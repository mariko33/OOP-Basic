
using System;
using System.Globalization;

public class Box
{
    private double height;

    private double length;

    private double width;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Height
    {
        get => this.height;
        set
        {
            if (value <= 0) throw new ArgumentException("Height cannot be zero or negative.");
            this.height = value;
        }
    }

    public double Length
    {
        get => this.length;
        set
        {
            if (value <= 0) throw new ArgumentException("Length cannot be zero or negative.");
            this.length = value;
        }
    }

    public double Width
    {
        get => this.width;
        set
        {
            if (value <= 0) throw new ArgumentException("Width cannot be zero or negative.");
            this.width = value;
        }
    }

    public double LiteralSurfaceArea()
    {
        return 2 * this.width * this.height + 2 * this.length * this.height;
    }

    public double SurfaceArea()
    {
        return 2 * this.width * this.height + 2 * this.length * this.height + 2 * this.width * this.length;
    }

    public double Volume()
    {
        return this.height * this.width * this.length;
    }



}
