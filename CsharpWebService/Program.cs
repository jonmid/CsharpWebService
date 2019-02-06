using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CsharpWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            WebService ws = new WebService();

            do
            {
                ws.Menu();
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        option = 0;
                        Console.WriteLine("Fin del programa ....");
                        break;
                    case 1:
                        ws.ListAll();
                        break;
                    case 2:
                        ws.Create();
                        break;
                    case 3:
                        ws.Update();
                        break;
                    case 4:
                        ws.Delete();
                        break;
                    default:
                        Console.WriteLine("La opción seleccionada no existe ....");
                        break;
                }
            }
            while (option != 0);
        }
    }
}
