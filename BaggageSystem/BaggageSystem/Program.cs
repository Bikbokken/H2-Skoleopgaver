using BaggageSystem;

public class Baggage
{
    public int Id { get; set; }
    public int TerminalID { get; set; }

    public Baggage(int id, int terminalID)
    {
        Id = id;
        TerminalID = terminalID;
    }
}

public class Program
{
    static void Main()
    {
        BaggageManager baggageManager = new BaggageManager();
        baggageManager.Start();
    }
}