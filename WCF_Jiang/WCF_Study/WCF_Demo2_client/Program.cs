using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_Demo2_service;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCF_Demo2_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new ChannelFactory<ICommunicationContract>("wcfDemo");
            var client = channel.CreateChannel();

            var channel2 = new ChannelFactory<ICommunicationContract>("wcf");
            var client2 = channel2.CreateChannel();

            Console.WriteLine("net.tcp:  "+client.SayHello());
            Console.WriteLine("http:  " + client2.SayHello());
            Console.ReadLine();
        }
    }
}
