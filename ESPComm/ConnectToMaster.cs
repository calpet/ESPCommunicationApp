using System;
using System.IO.Ports;

namespace ESPComm
{
    class ConnectToMaster
    {
        private int _baudRate;
        private string _portName;
        private SerialPort port;


        public ConnectToMaster()
        {

        }

        
        public ConnectToMaster(int baud, string portName)
        {
            this._portName = portName;
            this._baudRate = baud;
        }

        public bool OpenConnection(int baud, string portName)
        {
            this._baudRate = baud;
            this._portName = portName;

            try
            {
                port = new SerialPort {BaudRate = this._baudRate, PortName = this._portName};
                port.Open();
                return true;

            } catch (Exception e)
            {
                e = new Exception("Can't open the serial connection to Master.\n");
                Console.WriteLine(e.ToString());
                return false;
            }
            

        }

        public bool Write(string instruction)
        {
            try
            {
                port.Write(instruction);
                System.Threading.Thread.Sleep(500);
                return true;

            }
            catch (Exception e)
            {
                e = new Exception("Can't read serial connection.\n");
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public int BaudRate
        {
            get => _baudRate;
            set => _baudRate = value;
        }

        public string PortName
        {
            get => _portName; 
            set => _portName = value;
        }


    }
}
