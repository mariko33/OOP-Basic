

    using System;
    using System.Text;

public class Rectangle
    {
    private int height;

        private int width;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Height
        {
            get => this.height;
            set => this.height = value;
        }

        public int Width
        {
            get => this.width;
            set => this.width = value;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"|" + new String('-', this.Width) + $"|\n");

            for (var i = 0; i < this.Height - 2; i++) result.Append($"|" + new String(' ', this.Width) + $"|\n");

            result.Append($"|" + new String('-', this.Width) + $"|");

            return result.ToString();
        }
}
