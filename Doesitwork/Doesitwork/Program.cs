Queue<int> Q1 = new Queue<int>(new[] { 1, 2, 3, 4,5,6,7,8,9,10 });


for(int i = 0; i < Q1.Count; i++)
{
    Console.WriteLine($"I: {i} - Queue Count: {Q1.Count}");
    Q1.Dequeue();
}


