 public class Square:Rectangle
    {
    public Square(int side)
        : base(side, side)
    {
        this.Height = side;
        this.Width = side;
    }
}
