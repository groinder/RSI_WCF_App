using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IStreamContract
    {
        [OperationContract]
        ResponseFileMessage getMStream(RequestFileMessage request);

        [OperationContract]
        RequestFileMessage setMStream(ResponseFileMessage request);
    }

    [MessageContract]
    public class RequestFileMessage
    {
        [MessageBodyMember]
        public string name1;
    }

    [MessageContract]
    public class ResponseFileMessage
    {
        [MessageHeader]
        public string name2;
        [MessageHeader]
        public long size;

        [MessageBodyMember]
        public Stream data;
    }
}
