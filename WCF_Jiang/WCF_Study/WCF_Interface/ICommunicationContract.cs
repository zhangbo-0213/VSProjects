using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Interface
{
    [ServiceContract]
    public interface ICommunicationContract
    {

        [OperationContract]
        int Add(int a, int b);
    }
}
