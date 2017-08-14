using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建请求的目的地址和绑定
            Uri listenUri=new Uri("http://localhost:9999/listener");
            Binding binding=new BasicHttpBinding();
            //通过绑定创建信道工厂
            IChannelFactory<IRequestChannel> channelFactory = binding.BuildChannelFactory<IRequestChannel>();
            //开启信道工厂
            channelFactory.Open();

            //通过信道工厂创建请求信道
            IRequestChannel channel = channelFactory.CreateChannel(new EndpointAddress(listenUri));
            //开启请求信道
            channel.Open();

            //通过请求信道发送请求，并接受请求回复信息
            Message replyMessage = channel.Request(CreateRequestMessage(binding));
            //输出请求回复信息
            Console.WriteLine("接收到回复消息\n{0}",replyMessage);
            Console.Read();
            }

        static Message CreateRequestMessage(Binding binding)
        {
            string action = "urn:zhangbo/request";
            string body = "这是一个简单的请求消息！";

            return Message.CreateMessage(binding.MessageVersion,action,body);
        }
    }
}
