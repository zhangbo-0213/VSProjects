using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CustomChannel;

namespace Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri listenUri=new Uri("http://localhost:9999/listener");
            Binding binding=new BasicHttpBinding();
            IChannelListener<SimpleReplyChannel> channelListener = binding.BuildChannelListener<SimpleReplyChannel>(listenUri);

            channelListener.Open();

           SimpleReplyChannel channel =  channelListener.AcceptChannel(TimeSpan.MaxValue);
            channel.Open();

            Console.WriteLine("开始监听");

        }
    }
}
