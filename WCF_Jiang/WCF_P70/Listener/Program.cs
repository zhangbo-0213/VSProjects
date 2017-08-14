using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建监听地址和绑定
            Uri listenUri=new Uri("http://localhost:9999/listener");
            Binding binding=new BasicHttpBinding();
            //通过监听地址创建信道监听器
            IChannelListener<IReplyChannel> channelListener = binding.BuildChannelListener<IReplyChannel>(listenUri);
            //开启信道监听器
            channelListener.Open();

            //通过信道监听器对象创建回复信道对象
            IReplyChannel channel = channelListener.AcceptChannel(TimeSpan.MaxValue);
            //开启回复信道
            channel.Open();

            Console.WriteLine("开始监听...");

            while (true)
            {
                //通过回复信道创建请求文本对象
                RequestContext requestContext = channel.ReceiveRequest(TimeSpan.MaxValue);
                //输出请求文本对象里存储的从请求端发送的请求信息
                Console.WriteLine("接收到请求消息：\n{0}",requestContext.RequestMessage);
                //通过请求文本对象的Reply()方法向请求端发送回复信息
                requestContext.Reply(CreateReplyMessage(binding));
            }
        }

        static Message CreateReplyMessage(Binding binding)
        {
            string action = "urn:zhangbo/reply";
            string body = "这是一个简单的回复消息";

            return Message.CreateMessage(binding.MessageVersion, action, body);
        }
    }
}
