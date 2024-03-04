using System.Reflection.PortableExecutable;

public class Bubblegum
{
    public string Flavour { get; private set; }
    public Bubblegum(string flavour)
    {
        Flavour = flavour;
    } 
}

public class BubblegumController
{

    public BubblegumMachine Producer()
    {
        BubblegumMachine machine = new BubblegumMachine(55);
        return machine;
    }

    private List<Bubblegum> GenerateBubblegums(int max)
    {
        List <Bubblegum> bubblegums = new List <Bubblegum>();

        bubblegums.AddRange(GenerateBubbleGumsByType("Blåbær", 25, max));
        bubblegums.AddRange(GenerateBubbleGumsByType("Brombær", 12, max));
        bubblegums.AddRange(GenerateBubbleGumsByType("Tutti Frutti", 20, max));
        bubblegums.AddRange(GenerateBubbleGumsByType("Appelsin", 19, max));
        bubblegums.AddRange(GenerateBubbleGumsByType("Jordbær", 14, max));
        bubblegums.AddRange(GenerateBubbleGumsByType("Æble", 10, max));


        return bubblegums;
    }

    private List<Bubblegum> GenerateBubbleGumsByType(string name, int percentage, int max)
    {
        List<Bubblegum> bubblegums = new List<Bubblegum>();
        int numberOfGums = (int)Math.Round((percentage * max) / 100.0);

        for (int i = 0;  i < numberOfGums; i++)
        {
            bubblegums.Add(new Bubblegum(name));
        }

        return bubblegums;
    }
}

public class BubblegumMachine
{
    private int MaxBubblegum;
    private List<Bubblegum> bubblegums;

    private static BubblegumMachine instance;

    public static BubblegumMachine Instance { get {
        if (instance == null)
        {
            instance = new BubblegumController().Producer();
        }
        return instance;
        
        }
    }


    public IReadOnlyList<Bubblegum> GetBubblegums()
    {
        return bubblegums.AsReadOnly();
    }

    public void AddBubbleGum(List<Bubblegum> newBubblegums)
    {

        if (bubblegums.Count + newBubblegums.Count > MaxBubblegum)
        {
             throw new InvalidOperationException("Adding more bubblegums exceeds the maximum limit.");
        }

        newBubblegums.ForEach(gum => bubblegums.Add(gum));
    }

    public Bubblegum RemoveFirstBubblegum()
    {
        Bubblegum removedBubblegum = bubblegums.FirstOrDefault();

        if (removedBubblegum != null)
        {
            bubblegums = bubblegums.Skip(1).ToList();
        }

        return removedBubblegum;
    }

    public void Dispense()
    {
        if(bubblegums.Count >= 0) {
            throw new InvalidOperationException("Machine is empty!");
        }

        Bubblegum gum = RemoveFirstBubblegum();
        Console.WriteLine($"Dispensed one gum: {gum.Flavour} - Count: {bubblegums.Count}");

    }


    public BubblegumMachine(int maxBubblegum)
    {
        MaxBubblegum = maxBubblegum;
    }
}