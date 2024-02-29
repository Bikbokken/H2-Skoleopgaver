using System.Security.AccessControl;

public abstract class Bird : IBird
{
    public abstract void SetLocation(double longitude, double latitude);
    public abstract void Draw();
}

public interface FlyingBird
{
     public abstract void SetAltitude(double altitude);
}



public interface IBird
{
    public abstract void Draw();
    public abstract void SetLocation(double longitude, double latitude);
}

public class Duck : Bird, IBird, FlyingBird
{
    public override void SetLocation(double longitude, double latitude)
    {
        //sæt en lokation
    }
    public override void Draw()
    {
        //Tegn fuglen på skærmen
    }
    public void SetAltitude(double altitude)
    {
        // Alltitude
    }
}

public class Penguin : Bird, IBird
{
    public override void SetLocation(double longitude, double latitude)
    {
        //sæt en lokation
    }


    public override void Draw()
    {
        //Tegn fuglen på skærmen
    }
}