using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Demo2_service
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host =new ServiceHost(typeof(CommunicationContract));
            host.Open();
            Console.WriteLine("服务已启动！");
            Console.ReadLine();
        }
    }
}
