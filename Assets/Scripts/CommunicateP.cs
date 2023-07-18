using System.IO.Ports;
using System.Threading;
using TMPro;
using UnityEngine;


public class CommunicateP : MonoBehaviour
{
    public TMP_InputField comInput;

    private SerialPort sp;
    public string SerialPort;
    public int SerialPortBitrate = 115200;

    // Connect with SerialPort
    public void Connect()
    {
        if (GameObject.Find("sp") != null && sp.IsOpen)
        {
            sp.Close();
        }

        int.TryParse(comInput.text, out var com);
        SerialPort = "COM" + com;

        sp = new SerialPort(SerialPort, SerialPortBitrate, Parity.None, 8, StopBits.None);
        sp.Open();
        print("connect with -- " + SerialPort);
    }

    // Send Data
    public void SendData(string message)
    {
        sp.WriteLine(message);
    }
}
