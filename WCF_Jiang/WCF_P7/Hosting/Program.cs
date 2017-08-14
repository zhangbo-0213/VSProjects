using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Services;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof (CalculatorService)))
            {
                //通过代码的方式添加终结点，指定ABC（Address,Binding,Contract）
                host.AddServiceEndpoint(typeof (ICalculator), new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice");
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    //WCF服务的描述通过元数据（Metadata）形式发布；
                    //WCF中元数据的发布通过特殊的服务行为ServiceMetadataBehavior来实现；
                    //为创建的host添加ServiceMetadataBehavior，采用基于HTTP-GET的元数据获取方式，发布地址由ServiceMetadataBehavior的HttpGetUri指定；
                    //服务开启后，通过http://127.0.0.1:9999/calculatorservice/metadata 得到以WSDL形式体现的服务元数据
                    ServiceMetadataBehavior behavior =new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl=new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
                    host.Description.Behaviors.Add(behavior);
                }
                host.Opened += delegate { Console.WriteLine("CalculatorService 已经启动，请按任意键终止"); };
                host.Open();

                int i = 0;
                foreach (ChannelDispatcher channelDispatcher in host.ChannelDispatchers)
                {
                    Console.WriteLine("ChannelDispatcher{0}: ListenUri:{1}",++i,channelDispatcher.Listener.Uri);
                    int j = 0;
                    foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        Console.WriteLine("EndpointDispatcher{0}: EndpointAddress :{1}", ++j, endpointDispatcher.EndpointAddress.Uri);
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
