using System.Security.AccessControl;

public abstract class Bird : IBird
{
    public abstract void SetLocation(double longitude, double latitude);
    public abstract void Draw();
}

public interface IFlyingBird
{
     void SetAltitude(double altitude);
}



public interface IBird
{
    void Draw();
    void SetLocation(double longitude, double latitude);
}

public abstract class FlyingBird : Bird
{
    public abstract void SetAltitude(double altitude);

}

public class Duck : FlyingBird, IBird, IFlyingBird
{
    public override void SetLocation(double longitude, double latitude)
    {
        //sæt en lokation
    }
    public override void Draw()
    {
        //Tegn fuglen på skærmen
    }
    public override void SetAltitude(double altitude)
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