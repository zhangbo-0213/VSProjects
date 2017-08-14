using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Demo2_service
{
    [ServiceBehavior]
    public class CommunicationContract:ICommunicationContract
    {
        [OperationBehavior]
        public string SayHello()
        {
            return "Hello 这里是WCF服务端提供的服务";
        }
    }
}
