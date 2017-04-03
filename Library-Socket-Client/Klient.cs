using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library_Socket_Client
{
    class Klient
    {
        Socket serverSocket;
        string IP = "127.0.0.1";
        public void OpretForbindelse()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(IP), 11000);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(remoteEP);
        }

        public void SendString(string input)
        {
            byte[] msg = Encoding.UTF8.GetBytes(input);
            int bytesSent = serverSocket.Send(msg);
        }

        /// <summary>
        /// Hvis der skal bruges Json - NuGet Newtonsoft.Json
        /// </summary>
        /// <param name="input"></param>
        public void SendJsonData(object input)
        {
            string jsonString = JsonConvert.SerializeObject(input);
            byte[] msg = Encoding.UTF8.GetBytes(jsonString);
            int bytesSent = serverSocket.Send(msg);
        }

        public string LytEfterString()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = serverSocket.Receive(bytes);
            String data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

            return data;
        }

        public object LytEfterJson()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = serverSocket.Receive(bytes);
            String data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            object o = JsonConvert.DeserializeObject<object>(data);
            return o;
        }

        public void AfslutForbindelse()
        {
            //Console.WriteLine("Server: lukker tråd og socket");
            serverSocket.Shutdown(SocketShutdown.Both);
            serverSocket.Close();
            Thread.CurrentThread.Abort();
        }
    }
}
