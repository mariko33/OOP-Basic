public abstract class Machine
{
    private string id;

    protected Machine(string id)
    {
        this.id = id;
    }

    public string Id { get { return this.id; } set { this.id = value; } }
}
