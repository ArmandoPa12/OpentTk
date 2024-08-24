namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game(800, 600, "Game");
            g.Run(60.0);

            //Pruebas p = new Pruebas(800, 600, "pruebas");
            //p.Run(60.0);

        }
    }
}



//Console.WriteLine("Hello, World!");
