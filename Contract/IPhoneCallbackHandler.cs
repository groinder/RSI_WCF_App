using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    interface IPhoneCallbackHandler
    {
        [OperationContract(IsOneWay = true)]
        void AddPhoneCallback(List<Phone> phonesList); 
    }
}
