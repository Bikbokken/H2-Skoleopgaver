public interface ICharacter
{
    void Heal();
    void Die();
    void Fight();
}


public interface CanThrow
{
    void ThrowFrostNova();
    void ThrowMagicMisile();

}

public interface CanStrike
{
    void Bash();
    void Cleave();
}

public interface CanSlash
{
    void Slash();
}

public interface HasShield
{
    void ShieldGlare();
    void RaiseShield();
}




public interface CanTeleport
{
    void Teleport(int x, int y);
}


public class Wizard : ICharacter, CanTeleport, CanThrow
{
    public void Die()
    {
        Console.WriteLine("I'm dying");
    }

    public void Fight()
    {
        Console.WriteLine("I'm fighting");
    }

    public void Heal()
    {
        Console.WriteLine("I'm healing");
    }
    public void Teleport(int x, int y)
    {
        Console.WriteLine("I'm teleporting to " + x + " " + y);
    }

    public void ThrowFrostNova()
    {
        Console.WriteLine("I'm throwing my frost nova");
    }

    public void ThrowMagicMisile()
    {
        Console.WriteLine("I'm throwing a magic misile");
    }
}




public class Babarian : ICharacter, CanSlash, CanStrike
{
    public void Bash()
    {
        Console.WriteLine("I'm bashing someone");
    }

    public void Cleave()
    {
        Console.WriteLine("I'm cleaving someone");
    }

    public void Die()
    {
        Console.WriteLine("I'm dying");
    }

    public void Fight()
    {
        Console.WriteLine("I'm fighting");
    }

    public void Heal()
    {
        Console.WriteLine("I'm healing");
    }


    public void Slash()
    {
        Console.WriteLine("I'm slashing someone");
    }
}




public class Knight : ICharacter, HasShield, CanSlash, CanStrike
{
    public void Bash()
    {
        Console.WriteLine("I'm bashing someone");
    }

    public void Cleave()
    {
        Console.WriteLine("I'm cleaving someone");
    }

    public void Die()
    {
        Console.WriteLine("I'm dying");
    }

    public void Fight()
    {
        Console.WriteLine("I'm fighting");
    }

    public void Heal()
    {
        Console.WriteLine("I'm healing");
    }

    public void RaiseShield()
    {
        Console.WriteLine("I'm raising my shield");
    }

    public void ShieldGlare()
    {
        Console.WriteLine("I'm throwing shield glare");
    }

    public void Slash()
    {
        Console.WriteLine("I'm slashing someone");
    }
}



public class Witch : ICharacter, CanTeleport
{
    public void Die()
    {
        Console.WriteLine("I'm dying");
    }

    public void Fight()
    {
        Console.WriteLine("I'm fighting");
    }

    public void Heal()
    {
        Console.WriteLine("I'm healing");
    }

    public void RaiseShield()
    {
        Console.WriteLine("I'm raising my shield");
    }

    public void ShieldGlare()
    {
        Console.WriteLine("I'm throwing shield glare");
    }

    public void Teleport(int x, int y)
    {
        Console.WriteLine("I'm teleporting to " + x + " " + y);
    }
}