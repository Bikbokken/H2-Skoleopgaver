using Bagsystem;

public class Baggage
{
    public int Id { get; set; }
    public int TerminalID { get; set; }
    public DateTime BagDropped { get; set; }
    public DateTime SortedTime { get; set; }
    public DateTime ArrivedAtGate { get; set; } 
    

    public void UpdateSortedTiem(DateTime dateTime) { SortedTime = dateTime; }
    public void UpdateArrivedAtGate(DateTime dateTime) {  ArrivedAtGate = dateTime; }

    public Baggage(int id, int terminalID)
    {
        Id = id;
        TerminalID = terminalID;
        BagDropped = DateTime.Now;
    }
}

public class Program
{
    static void Main()
    {
        BaggageManager baggageManager = new BaggageManager();
        baggageManager.Start();

        baggageManager.StartCounter(1);
        baggageManager.StartCounter(2);
        baggageManager.StartCounter(3);

        baggageManager.StartGate(1);
        baggageManager.StartGate(2);
        baggageManager.StartGate(3);
    }
}