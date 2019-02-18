using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SerialTransport;

namespace Z2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Device z2 = new Device(new SerialTransp(args[0]));
                z2.InitDevice();
            }
        }
    }
}
