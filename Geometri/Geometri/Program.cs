// See https://aka.ms/new-console-template for more information
using Geometri;


List<Figure> figures = new List<Figure>();


Rectangle rec = new Rectangle(5, 10);
Paralellogram par = new Paralellogram(5, 10, 20);
Trapetz trapetz = new Trapetz(10, 9, 8, 9);
Triangle triangle = new Triangle(10, 5, 11);
Square sq = new Square(10);

figures.Add(rec);
figures.Add(par);
figures.Add(trapetz);
figures.Add(triangle);
figures.Add(sq);


figures.ForEach(x => Console.WriteLine(x.ToString()));