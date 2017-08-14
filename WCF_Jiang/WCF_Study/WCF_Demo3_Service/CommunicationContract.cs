using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace WCF_Demo3_Service
{
    [ServiceBehavior]
    public class CommunicationContract:ICommunicationContract
    {
        [OperationBehavior]
        public string SayHello()
        {
            return "这里是服务器端提供的程序";
        }
    }
}
