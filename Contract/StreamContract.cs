using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class StreamContract : IStreamContract
    {
        public ResponseFileMessage getMStream(RequestFileMessage request)
        {
            FileStream file;
            string filePath = Path.Combine(System.Environment.CurrentDirectory, request.name1);
            try
            {
                file = File.OpenRead(filePath);

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }

            ResponseFileMessage response = new ResponseFileMessage();

            response.name2 = request.name1;
            response.size = file.Length;
            response.data = file;

            return response;
        }

        public RequestFileMessage setMStream(ResponseFileMessage request)
        {
            string filePath = Path.Combine(System.Environment.CurrentDirectory, request.name2);

            filePath = Path.Combine(System.Environment.CurrentDirectory, request.name2);
            SaveFile(request.data, filePath);

            RequestFileMessage response = new RequestFileMessage();
            response.name1 = request.name2;

            return response;
        }

        private void SaveFile(Stream fs, string filePath)
        {
            const int bufferLength = 8192;
            int bytecount = 0;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];


            FileStream outstream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write);

            while ((counter = fs.Read(buffer, 0, bufferLength)) > 0)
            {
                outstream.Write(buffer, 0, counter);
                bytecount += counter;
            }

            outstream.Close();
            fs.Close();
        }
    }
}
