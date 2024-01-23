using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Product
{
    public Product() { }
}

public class Manager
{
    Queue<Product> _products = new Queue<Product>();
    Random random = new Random();

    public void Consume()
    {
        while (true)
        {
            while (_products.Count == 0)
            {
                Console.WriteLine("Kan ikke consume mere - mangler produkter.");
            }
            _products.Dequeue();
            Console.WriteLine("Consumer removed one product - Total items: {0}", _products.Count);
            Thread.Sleep(1000);
        }

    }

    public void Produce()
    {
        while (true)
        {
            if (_products.Count < 3)
            {
                _products.Enqueue(new Product());
                Console.WriteLine("Producer produced one more product - Total items: {0}", _products.Count);
            } else
            {
                Console.WriteLine("Kan ikke producere mere - maks. 3");
            }
            Thread.Sleep(1000);
        }

    }

}
public class Program
{
    static void Main()
    {
        Manager manager = new Manager();

        Thread consumer = new Thread(manager.Consume);
        consumer.Name = "Consumer";
        consumer.Start();

        Thread produce = new Thread(manager.Produce);
        produce.Name = "Producer";
        produce.Start();

    }
}