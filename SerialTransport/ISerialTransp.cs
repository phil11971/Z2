using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialTransport
{
    public interface ISerialTransp
    {
        void OpenPort();
        void ClosePort();

        event EventHandler<DataPortEventArgs> OnDataRecieved;
    }
}
