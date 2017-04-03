using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Socket_Server
{
    /// <summary>
    /// Hvis den skal bruges i Forms: brug Invoke
    /// Hack-løsning: CheckForIllegalCrossThreadCalls = false; i Forms-constructor
    /// </summary>
    class Server
    {
        private static Server _instance;
        private Server() { }

        public static Server Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Server();
                }
                return _instance;
            }
        }

        Socket lytteEfterKlienter;
        Socket klientSocket;
        public Socket OpretForbindelse()
        {
            if (lytteEfterKlienter==null)
            {
                lytteEfterKlienter = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
                lytteEfterKlienter.Bind(localEndPoint);
                lytteEfterKlienter.Listen(10);
            }

            //Console.WriteLine("Server: Venter på forbindelse.");
            klientSocket = lytteEfterKlienter.Accept();
            //Console.WriteLine("Server: Forbindelse accepteret.");
            return klientSocket;
        }

        public void AfslutForbindelse()
        {
            //Console.WriteLine("Server: lukker tråd og socket");
            klientSocket.Shutdown(SocketShutdown.Both);
            klientSocket.Close();
            Thread.CurrentThread.Abort();
        }
    }
}