using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Library_Socket_Server
{
    class KlientForbindelse
    {
        public KlientForbindelse(Socket minSocket)
        {
            this.minSocket = minSocket;
        }

        Socket minSocket;
        public void SendString(string input)
        {
            byte[] msg = Encoding.UTF8.GetBytes(input);
            int bytesSent = minSocket.Send(msg);
        }

        /// <summary>
        /// Hvis der skal bruges Json - NuGet Newtonsoft.Json
        /// </summary>
        /// <param name="input"></param>
        public void SendJsonData(object input)
        {
            string jsonString = JsonConvert.SerializeObject(input);
            byte[] msg = Encoding.UTF8.GetBytes(jsonString);
            int bytesSent = minSocket.Send(msg);
        }

        public string LytEfterString()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = minSocket.Receive(bytes);
            String data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

            return data;
        }

        public object LytEfterJson()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = minSocket.Receive(bytes);
            String data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            object o = JsonConvert.DeserializeObject<object>(data);
            return o;
        }
    }
}