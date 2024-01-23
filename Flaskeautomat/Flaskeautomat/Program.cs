
using Flaskeautomat;
using System.Security.Cryptography.X509Certificates;

public abstract class Container
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Container(string name, int id)
    {
        Name = name;
        Id = id;
    }
 
}
public sealed class Can : Container
{
    public Can(string name, int id) : base(name, id)
    {
    }
}
public sealed class Bottle : Container
{
    public Bottle(string name, int id) : base(name, id)
    {
    }
}


public class Program
{
    static void Main()
    {
        MachineController machineController = new MachineController();
        machineController.Start();
    }
}