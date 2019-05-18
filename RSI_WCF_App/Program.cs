using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace RSI_WCF_App
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(PhoneContract));

            Uri baseAddress = new Uri("http://localhost:10001/RSI_WCF_App_Stream");
            ServiceHost streamHost = new ServiceHost(typeof(StreamContract), baseAddress);

            try
            {
                host.Open();

                BasicHttpBinding binding = new BasicHttpBinding();
                binding.TransferMode = TransferMode.Streamed;
                binding.MaxReceivedMessageSize = 1000000000;
                binding.MaxBufferSize = 8192;

                ServiceEndpoint enpoint = streamHost.AddServiceEndpoint(typeof(IStreamContract), binding, "StreamContract");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();

                smb.HttpGetEnabled = true;

                streamHost.Description.Behaviors.Add(smb);

                streamHost.Open();

                Console.WriteLine("---> Host is running.");
                Console.WriteLine("---> Press <ENTER> to end.\n");
                Console.ReadLine();
                host.Close();
                streamHost.Close();

            }
            catch (CommunicationException ce)
            {
                Console.WriteLine(ce.Message);
                host.Abort();
                streamHost.Abort();
            }
        }
    }
}
