using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Demo3_Service
{
    [ServiceContract]
    public interface ICommunicationContract
    {
        [OperationContract]
        string SayHello();
    }
}
