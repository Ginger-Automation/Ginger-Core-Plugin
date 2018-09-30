using Amdocs.Ginger.CoreNET.Drivers.CommunicationProtocol;
using GingerCoreNET.DriversLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amdocs.Ginger.Plugin.Core
{
    public class GingerNodeStarter
    {
        //public static void StartNode(string[] args)
        //{
        //    // GingerNodeStarter.StartNode("MathService", SocketHelper.GetLocalHostIP(), 15001);
        //    // GingerNodeStarter.StartNode("MathService", SocketHelper.GetLocalHostIP(), 15001);
        //}

        public static void StartNode(IGingerService gingerService, string name)
        {
            GingerNode gingerNode = new GingerNode(gingerService);
            gingerNode.StartGingerNode(name, SocketHelper.GetLocalHostIP(), 15001);
        }
    }
}
