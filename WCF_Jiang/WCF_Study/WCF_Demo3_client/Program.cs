using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using WCF_Demo3_Service;

namespace WCF_Demo3_client
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义Binding与服务地址
            Binding httpBinding=new BasicHttpBinding();
            EndpointAddress httpAddress=new EndpointAddress("http://localhost:8080/wcf");
            //使用ChannelFactory创建一个IData的代理对象,指定Binding和Address
            var client=new ChannelFactory<ICommunicationContract>(httpBinding,httpAddress).CreateChannel();
            Console.WriteLine("httpBinding: "+client.SayHello());
            ((IChannel) client).Close();

            //换成Tcp的Binding和服务地址
            Binding tcpBinding=new NetTcpBinding();
            EndpointAddress tcpAddress=new EndpointAddress("net.tcp://localhost:8081/wcf");
            //使用ChannelFactory创建一个IData的代理对象,指定Binding和Address
            var client2 = new ChannelFactory<ICommunicationContract>(tcpBinding, tcpAddress).CreateChannel();
            Console.WriteLine("tcpBinding: "+client2.SayHello());
            ((IChannel)client2).Close();

            Console.ReadKey();
        }
    }
}
