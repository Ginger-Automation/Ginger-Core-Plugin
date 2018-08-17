﻿using Amdocs.Ginger.CoreNET.Drivers.CommunicationProtocol;
using Amdocs.Ginger.Plugin.Core;
using GingerCoreNET.DriversLib;
using System;

namespace PluginExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //TODO: connect to grid


            // test on differnt OS
            //MyService myService = new MyService();
            //GingerAction GA = new GingerAction();
            //myService.Sum(GA, 5, 4);

            GingerNode gingerNode = new GingerNode(new MyService());
            gingerNode.StartGingerNode("My Service 1", SocketHelper.GetLocalHostIP(), 15001);

        }


    }
}
