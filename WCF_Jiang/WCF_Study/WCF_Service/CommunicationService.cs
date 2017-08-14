using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using WCF_Interface;

namespace WCF_Service
{
    [ServiceBehavior]
   public class CommunicationService:ICommunicationContract
    {
        [OperationBehavior]
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
