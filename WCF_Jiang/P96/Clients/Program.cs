using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;
using CustomChannel;

namespace Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress address=new EndpointAddress("http://localhost:9999/service");
            using (
                ChannelFactory<IService> channelFactory = new ChannelFactory<IService>(new SimpleDatagramBinding(),
                    address))
            {
                IService proxy = channelFactory.CreateChannel();
                proxy.Dosomething();
                proxy.Dosomething();
                (proxy as ICommunicationObject).Close();

                proxy = channelFactory.CreateChannel();
                proxy.Dosomething();
                proxy.Dosomething();
                (proxy as ICommunicationObject).Close();
            }
            Console.Read();
        }
    }
}
