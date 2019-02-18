using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SerialTransport;

namespace Z2
{
    public class Device
    {
        private ISerialTransp _transport;

        public Device(ISerialTransp serialTransp)
        {
            _transport = serialTransp;
        }

        public void InitDevice()
        {
            _transport.OnDataRecieved += onrec;
            _transport.OpenPort();

            Console.ReadKey();

            _transport.ClosePort();
        }

        private void onrec(object sender, DataPortEventArgs e)
        {
            var dataPortObj = e;

            string pattern = @"^([\w-]+)(\[[0-9A-F]{4}\]) (\d{3}),(\d{5})";
            Regex regex = new Regex(pattern);

            Match match = regex.Match(dataPortObj.ReceivedData);

            var card = new Card(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value);
            Console.WriteLine(card);

        }

    }
}
