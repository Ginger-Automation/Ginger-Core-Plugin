using Amdocs.Ginger.CoreNET.Drivers.CommunicationProtocol;
using Amdocs.Ginger.Plugin.Core;
using GingerCoreNET.DriversLib;
using System;
using System.Reflection;

namespace PluginExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting MyService");


                GingerNode gingerNode = new GingerNode(new MyService());
                gingerNode.StartGingerNode("My Service 1", SocketHelper.GetLocalHostIP(), 15001);

                //GingerNode gingerNode2 = new GingerNode(new MyService());
                //gingerNode2.StartGingerNode("My Service 2", SocketHelper.GetLocalHostIP(), 15001);

                //GingerNode gingerNode3 = new GingerNode(new MyService());
                //gingerNode3.StartGingerNode("My Service 3", SocketHelper.GetLocalHostIP(), 15001);

                //GingerNode gingerNode4 = new GingerNode(new MyDriver());
                //gingerNode4.StartGingerNode("My Driver 1", SocketHelper.GetLocalHostIP(), 15001);


                //TODO: run seveal on threads
                // Run several on different process

                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception!!! " + ex.Message);
            }
            
        }

    }
}
