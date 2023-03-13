using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SensorDataNetwork : MonoBehaviour
{
    public ParseFromArduino parse_script;

    public struct ArduinoSensorData : NetworkMessage
    {
        public string arduinodata;
    }

    public void SendData(string arduinodata)
    {
        ArduinoSensorData msg = new ArduinoSensorData()
        {
            arduinodata = arduinodata
    };
    NetworkServer.SendToAll(msg);
    }

public void SetupClient()
{
    NetworkClient.RegisterHandler<ArduinoSensorData>(OnDataRead, false);
    NetworkClient.Connect("81.230.106.34");
}

public void OnDataRead(ArduinoSensorData msg)
{
        parse_script.ParseReceivedMessage(msg.arduinodata);
}

}
