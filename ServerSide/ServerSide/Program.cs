using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace ServerSide
{
    class Program
    {
        static void Main(string[] args) 
        { 
            TcpListener server = new TcpListener(8888);
        
            server.Start();
            Console.WriteLine("Server Started & waiting for Clients.");

            // Creating Sockets for clients
            Socket socketForClients = server.AcceptSocket();
            
            if(socketForClients.Connected)
            {
                // Send message to client 
                NetworkStream ns = new NetworkStream(socketForClients);
                StreamWriter sw = new StreamWriter(ns);
                Console.WriteLine("Server>> Welcome Client.");
                sw.WriteLine("Welcome Client");
                sw.Flush();

                //Get message from client
                StreamReader sr = new StreamReader(ns);
                Console.WriteLine("Client >> " + sr.ReadLine());
                sw.Close();
                ns.Close();
            }

            socketForClients.Close();

        }
    }
}
