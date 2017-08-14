using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Demo2_service
{
    [ServiceContract]
    public interface ICommunicationContract
    {
        [OperationContract]
         string SayHello();
    }
}
