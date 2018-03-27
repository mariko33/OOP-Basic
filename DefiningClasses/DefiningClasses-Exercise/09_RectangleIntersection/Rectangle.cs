
    using System;
    using System.Security;

public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double xCoordinate;
        private double yCoordinate;

        public Rectangle(string id, double weidth, double height, double xCoordinate, double yCoordinate)
        {
            this.Id = id;
            this.Width = weidth;
            this.Height = height;
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public double Height { get=>this.height; private set=>this.height=value; }

        public string Id { get=>this.id; private set=>this.id=value; }

        public double Width { get=>this.width; private set=>this.width=value; }
        public double XCoordinate { get=>this.xCoordinate; set=>this.xCoordinate=value; }
        public double YCoordinate { get=>this.yCoordinate; set=>this.yCoordinate=value; }

        public bool IsHaveIntersetion(Rectangle rectangle)
        {
        

        if (this.XCoordinate + this.Width < rectangle.XCoordinate
            || rectangle.XCoordinate + rectangle.Width < this.XCoordinate
            || this.YCoordinate + this.Height < rectangle.YCoordinate
            || rectangle.YCoordinate + rectangle.Height < this.YCoordinate) return false;

            return true;

    }
    }
