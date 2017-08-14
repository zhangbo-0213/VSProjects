using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelFactory = new ChannelFactory<ICalculator>("CalculatorService");
            ICalculator channel = channelFactory.CreateChannel();
            Console.WriteLine("x+y={0},when x={1},y={2}",channel.Add(1,2),1,2);
            Console.ReadKey();
        }
    }
}
