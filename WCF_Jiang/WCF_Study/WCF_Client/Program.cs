using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_Interface;

namespace WCF_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel=new ChannelFactory<ICommunicationContract>("clientEndpoint");
            var client = channel.CreateChannel();
            Console.WriteLine(client.Add(23,20));
            Console.ReadLine();
        }
    }
}
