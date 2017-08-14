using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host=new ServiceHost(typeof(WCF_Service.CommunicationService));
            host.Open();
            Console.WriteLine("服务启动！");
            Console.ReadLine();
        }
    }
}
