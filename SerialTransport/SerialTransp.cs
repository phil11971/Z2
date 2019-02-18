using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

namespace SerialTransport
{
    public class SerialTransp : ISerialTransp
    {
        private SerialPort _sp;
        public event EventHandler<DataPortEventArgs> OnDataRecieved;

        public SerialPort Sp { get => _sp; }

        public SerialTransp(string comPort)
        {
            _sp = new SerialPort(comPort);
        }

        public void OpenPort()
        {
            Sp.DataReceived += onRec;
            Sp.Open();
        }

        public void ClosePort()
        {
            Sp.DataReceived -= onRec;
            Sp.Close();
        }

        private void onRec(object sender, SerialDataReceivedEventArgs e)
        {
            var port = sender as SerialPort;
            string dataPort = port.ReadLine();

            var onrec = OnDataRecieved;
            if (onrec != null)
            {
                var d = new DataPortEventArgs(dataPort);
                onrec(this, d);
            }
        }

    }

    public class DataPortEventArgs : EventArgs
    {
        public string ReceivedData { get; set; }

        public DataPortEventArgs(string dataPort)
        {
            ReceivedData = dataPort;
        }
    }
}
