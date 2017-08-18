using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;
using CustomChannel;

namespace Services
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof (Service)))
            {
                host.AddServiceEndpoint(typeof (IService), new SimpleDatagramBinding(), "http://localhost:9999/service");
                host.Open();

                Console.Read();
            }
        }
    }
}
