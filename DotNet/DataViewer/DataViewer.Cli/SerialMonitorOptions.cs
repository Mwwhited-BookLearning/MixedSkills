using System.IO.Ports;

namespace DataViewer.Cli
{
    public class SerialMonitorOptions
    {
        public const string Section = "SerialMonitor";
        public string PortName { get; set; }
        public int BaudRate { get; set; } = 9600;
        public Parity Parity { get; set; } = Parity.None;
        public int DataBits { get; set; } = 8;
    }
}
