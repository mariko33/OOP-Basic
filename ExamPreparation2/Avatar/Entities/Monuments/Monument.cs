public abstract class Monument
{
    private string name;

    protected Monument(string name)
    {
        this.name = name;
    }

    public abstract int GetAffinity();
    
    public override string ToString()
    {
        int index = this.GetType().Name.IndexOf("Monument");
        string currentName = this.GetType().Name.Insert(index, " ");
        return $"{currentName}: {this.name},";
    }
}
