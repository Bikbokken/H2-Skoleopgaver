public class Liquid : ILiquid
{
    public string Name { get; private set; }
    public int MillilitersOfLiquid { get; private set; }

    public void AddLiquid(int milliliters)
    {
        MillilitersOfLiquid += milliliters; 
    }

    public void RemoveLiquid(int milliliters)
    {
        MillilitersOfLiquid -= milliliters;
    }

    public int GetLiquidMillilitersOfLiquid()
    {
        return MillilitersOfLiquid;
    }

    public Liquid(string name)
    {
        Name = name;
    }
}

public interface ILiquid
{
    void AddLiquid(int milliliters);
    void RemoveLiquid(int milliliters);
    int GetLiquidMillilitersOfLiquid();
}


public class Ingredient : IIngredient
{
    public string Name { get; private set; }
    public int GramsOfIngredient { get; private set; }

    public void AddIngredient(int grams)
    {
        GramsOfIngredient += grams;
    }
    
    public int GetGramsOfIngredients()
    {
        return GramsOfIngredient;
    }

    public void RemoveIngredient(int grams)
    {
        GramsOfIngredient -= grams;
    }

    public Ingredient(string name)
    {
        Name = name;
    }
}

public interface IIngredient
{
    void AddIngredient(int grams);
    void RemoveIngredient(int grams);
    int GetGramsOfIngredients();
}





public abstract class Machine
{
    protected ILiquid liquid;
    protected IIngredient ingredient;
    protected bool hasFilter;
    protected int liquidPerCup;
    protected int cupsPerBrew;

    public abstract void Brew();
    public virtual void ChangeFilter()
    {
        hasFilter = true;
    }

    public virtual void AddLiquid(int milliliters)
    {
        liquid.AddLiquid(milliliters);
    }

    public virtual void RemoveLiquid(int milliliters)
    {
        liquid.RemoveLiquid(milliliters);
    }

    public virtual void AddIngredient(int grams)
    {
        ingredient.AddIngredient(grams);
    }

    public virtual void RemoveIngredient(int grams)
    {
        ingredient.AddIngredient(grams);
    }

    public Machine(ILiquid liquid, IIngredient ingredient, int liquidPerCup, int cupsPerBrew)
    {
        this.liquid = liquid;
        this.ingredient = ingredient;
        hasFilter = true;
        this.liquidPerCup = liquidPerCup;
        this.cupsPerBrew = cupsPerBrew;
    }
}


public class CoffeeMachine : Machine
{
    
    
    public CoffeeMachine() : base(new Liquid("Water"), new Ingredient("Coffee"), 100, 1)
    {
    }

    public override void Brew()
    {
    }
}


public class TeaMachine : Machine
{

    public TeaMachine() : base(new Liquid("Water"), new Ingredient("Coffee"), 100, 10)
    {

    }

    public override void Brew()
    {
        // Brewing logic for tea.
    }
}


