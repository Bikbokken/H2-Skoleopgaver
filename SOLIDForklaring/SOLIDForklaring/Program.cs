namespace Interface
{

    // Et interface er en kontrkat

    interface ICar
    {
        string GetCarDescription();
    }

    public class Car : ICar 
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string GetCarDescription()
        {
            return Name;
        }

        public string GetCarName()
        {
            return Name;
        }

        
    }

    public class Test
    {
        private ICar MyCar { get; set; }
        public Test()
        {
            MyCar = new Car();
        }
        public void Hey()
        {
            MyCar.GetCarDescription();
        }


    }
}
