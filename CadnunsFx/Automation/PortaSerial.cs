using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace CadnunsFx.Automation.Portas
{
    public class COM_Port
    {
        SerialPort portaSerial;

        public COM_Port(String porta, int baudRate)
        {
            this.portaSerial.PortName = porta;
            this.portaSerial.BaudRate = baudRate;
        }

        public void AbrirConexao()
        {
            if (!portaSerial.IsOpen)
                portaSerial.Open();
            else
            MessageBox.Show("A porta "+portaSerial.PortName+" já está aberta");
        }

        public void FecharConexao()
        {
            if (portaSerial.IsOpen)
            {
                portaSerial.Close();
            }
        }

        public static string[] RetornaPortasDisponiveis()
        {
            return SerialPort.GetPortNames();
        }
    }
}
