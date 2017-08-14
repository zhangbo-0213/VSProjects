using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.CalculatorService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatrServiceClient client=new CalculatrServiceClient("WSHttpBinding_CalculatrService");
            Console.WriteLine("x+y={2},when x={0},y={1}",1,2,client.Add(1,2));
            Console.WriteLine("x-y={2},when x={0},y={1}", 1, 2, client.Subtract(1, 2));
            Console.WriteLine("x*y={2},when x={0},y={1}", 1, 2, client.Multiply(1, 2));
            Console.WriteLine("x/y={2},when x={0},y={1}", 1, 2, client.Divide(1, 2));
            Console.ReadKey();
        }
    }
}
