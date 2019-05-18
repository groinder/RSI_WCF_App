using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Contract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IPhoneCallbackHandler))]
    public interface IPhoneContract
    {
        [OperationContract(IsOneWay = true)]
        void AddPhone(Phone phone);

        [OperationContract]
        Phone GetPhone(int index);

        [OperationContract]
        List<Phone> GetPhoneList();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Contract.ContractType".
    [DataContract]
    public class Phone
    {
        [DataMember]
        public string Producer { get; set; }
        [DataMember]
        public int ReleaseYear { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Weight { get; set; }
        [DataMember]
        public double Thickness { get; set; }
        [DataMember]
        public string OperatingSystem { get; set; }
        [DataMember]
        public bool DualSim { get; set; }
        [DataMember]
        public bool MicroSDCardSlot { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
    }
}
