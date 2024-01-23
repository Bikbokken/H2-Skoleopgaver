
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
        while(true)
        {
            lock (_products)
            {
                while (_products.Count == 0)
                {
                    Monitor.Wait(_products);
                }
                _products.Dequeue();
                Console.WriteLine("Consumer removed one product - Total items: {0}", _products.Count);

            }
            Thread.Sleep(random.Next(10,100));
        }

    }

    public void Produce()
    {
        while(true)
        {
            lock(_products)
            {
                if (_products.Count < 10)
                {
                    _products.Enqueue(new Product());
                    Console.WriteLine("Producer produced one more product - Total items: {0}", _products.Count);
                    Monitor.PulseAll(_products);
                }
                
            }
            Thread.Sleep(random.Next(10, 100));
        }

    }

}


public class Program
{
    static void Main(string[] args)
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