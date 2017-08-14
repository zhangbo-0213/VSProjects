using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCF_Demo3_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义两个基地址，一个用于http,一个用于tcp
            Uri httpAddress=new Uri("http://localhost:8080/wcf");
            Uri tcpAddress=new Uri("net.tcp://localhost:8081/wcf");
            //服务类型，实现接口的类
            Type serviceType = typeof (CommunicationContract);

            //定义一个ServiceHost
            using (ServiceHost host = new ServiceHost(serviceType, new Uri[] { httpAddress, tcpAddress }))
            {
                //定义一个basicHttpBinding 
                Binding basicHttpBinding=new BasicHttpBinding();
                string address = "";
                //创建endPoint，使用Binding和address作为参数
                host.AddServiceEndpoint(typeof (WCF_Demo3_Service.ICommunicationContract), basicHttpBinding, address);

                //定义一个netTcpBinding
                Binding tcpBinding=new NetTcpBinding();
                address = "";
                host.AddServiceEndpoint(typeof (WCF_Demo3_Service.ICommunicationContract), tcpBinding, address);

                //启动服务
                host.Open();
                Console.WriteLine("WCF_Demo3 服务已开启");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
