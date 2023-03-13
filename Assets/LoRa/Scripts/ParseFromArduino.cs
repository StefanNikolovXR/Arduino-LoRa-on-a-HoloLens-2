using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;
using Lean.Transition;
using Lean.Transition.Method;

public class ParseFromArduino : MonoBehaviour
{
    private GameObject prevpoint, currpoint;

    public static string incomingMsg = "";

    public string data_string = "";

    public string teststring;

    public float temperature, humidity, pressure, illuminance, RSSI;

    public GameObject graph_point;

    private MeasureLine connectingline;

    public static int sensor_menu_opened;

    public GameObject temperature_parent, humidity_parent, pressure_parent, illuminance_parent, RSSI_parent;

    public List<GameObject> temperature_readings = new List<GameObject>();

    public List<GameObject> humidity_readings = new List<GameObject>();

    public List<GameObject> pressure_readings = new List<GameObject>();

    public List<GameObject> illuminance_readings = new List<GameObject>();

    public List<GameObject> RSSI_readings = new List<GameObject>();

    private GameObject graphpoint_instanced;

    private static string time;

    public TextMeshProUGUI start_stop_toggle;

    private int temperature_counter = 0, humidity_counter = 0, pressure_counter = 0, illuminance_counter = 0, RSSI_counter = 0;

    public GameObject Sensor_Menu, Sensor_Graph, Side_Panels;

    //public LeanTransitioo enlarge_sensor_graph;

    void Start()
    {
        {
            sensor_menu_opened = 1;
            temperature = 0;
            humidity = 0;
            pressure = 0;
            illuminance = 0;
            RSSI = 0;
        }
    }

    public void TemperatureMenu()
    {
        sensor_menu_opened = 1;
    }

    public void HumidityMenu()
    {
        sensor_menu_opened = 2;
    }

    public void PressureMenu()
    {
        sensor_menu_opened = 3;
    }

    public void IlluminanceMenu()
    {
        sensor_menu_opened = 4;
    }

    public void RSSIMenu()
    {
        sensor_menu_opened = 5;
    }

    public void ParseReceivedMessage(string incomingMsg)
    {
        if (incomingMsg != "")
        {
            string[] parsed_values = incomingMsg.Split(",");

            temperature = float.Parse(parsed_values[0]);
            humidity = float.Parse(parsed_values[1]);
            pressure = float.Parse(parsed_values[2]);
            illuminance = float.Parse(parsed_values[3]);
            RSSI = float.Parse(parsed_values[4]);

            time = System.DateTime.UtcNow.ToLocalTime().ToString();

            graphpoint_instanced = Instantiate(graph_point, new Vector3(0, 0, 0), Quaternion.identity);

            graphpoint_instanced.GetComponent<ReadingStorage>().storedtime = time;

            switch (sensor_menu_opened)
            {
                case 1:

                    temperature_readings.Add(graphpoint_instanced);

                    graphpoint_instanced.transform.parent = temperature_parent.transform;

                    graphpoint_instanced.transform.localPosition = new Vector3(-100 + (temperature_readings.Count - temperature_counter) * 10, temperature * 2, 0);

                    graphpoint_instanced.GetComponent<ReadingStorage>().storedvalue = temperature;

                    connectingline = graphpoint_instanced.GetComponent<MeasureLine>();

                    if (temperature_readings.Count >= 2)
                    {

                        MeasureLine.AddTarget(connectingline, temperature_parent.transform.GetChild(temperature_readings.Count - 2).transform);

                    }

                    if (temperature * 4 > 100)
                    {
                        graphpoint_instanced.transform.localPosition = new Vector3(graphpoint_instanced.transform.localPosition.x, temperature * 2.1f, 0);
                        graphpoint_instanced.transform.GetChild(0).gameObject.SetActive(true);
                    }

                    if (temperature_readings.Count > 10)
                    {
                        temperature_counter++;

                        temperature_parent.transform.GetChild(temperature_readings.Count - 11).gameObject.SetActive(false);

                        foreach (Transform child in temperature_parent.transform)
                        {
                            child.transform.localPosition = new Vector3(child.transform.localPosition.x - 10, child.transform.localPosition.y, 0);
                        }
                    }

                    break;

                case 2:

                    humidity_readings.Add(graphpoint_instanced);

                    graphpoint_instanced.transform.parent = humidity_parent.transform;

                    graphpoint_instanced.transform.localPosition = new Vector3(-100 + (humidity_readings.Count - humidity_counter) * 10, humidity - 50, 0);

                    graphpoint_instanced.GetComponent<ReadingStorage>().storedvalue = humidity;

                    connectingline = graphpoint_instanced.GetComponent<MeasureLine>();

                    if (humidity_readings.Count >= 2)
                    {

                        MeasureLine.AddTarget(connectingline, humidity_parent.transform.GetChild(humidity_readings.Count - 2).transform);

                    }

                    if (humidity_readings.Count > 10)
                    {
                        humidity_counter++;

                        humidity_parent.transform.GetChild(humidity_readings.Count - 11).gameObject.SetActive(false);

                        foreach (Transform child in humidity_parent.transform)
                        {
                            child.transform.localPosition = new Vector3(child.transform.localPosition.x - 10, child.transform.localPosition.y, 0);
                        }
                    }

                    break;

                case 3:

                    pressure_readings.Add(graphpoint_instanced);

                    graphpoint_instanced.transform.parent = pressure_parent.transform;

                    graphpoint_instanced.transform.localPosition = new Vector3(-100 + (pressure_readings.Count - pressure_counter) * 10, pressure - 100, 0);

                    graphpoint_instanced.GetComponent<ReadingStorage>().storedvalue = pressure;

                    connectingline = graphpoint_instanced.GetComponent<MeasureLine>();

                    if (pressure_readings.Count >= 2)
                    {

                        MeasureLine.AddTarget(connectingline, pressure_parent.transform.GetChild(pressure_readings.Count - 2).transform);

                    }

                    if (pressure_readings.Count > 10)

                    {
                        pressure_counter++;

                        pressure_parent.transform.GetChild(pressure_readings.Count - 11).gameObject.SetActive(false);

                        foreach (Transform child in pressure_parent.transform)
                        {
                            child.transform.localPosition = new Vector3(child.transform.localPosition.x - 10, child.transform.localPosition.y, 0);
                        }
                    }

                    break;

                case 4:

                    illuminance_readings.Add(graphpoint_instanced);

                    graphpoint_instanced.transform.parent = illuminance_parent.transform;

                    graphpoint_instanced.transform.localPosition = new Vector3(-100 + (illuminance_readings.Count - illuminance_counter) * 10, illuminance * 10 - 100, 0);

                    graphpoint_instanced.GetComponent<ReadingStorage>().storedvalue = illuminance;

                    connectingline = graphpoint_instanced.GetComponent<MeasureLine>();

                    if (illuminance_readings.Count >= 2)
                    {

                        MeasureLine.AddTarget(connectingline, illuminance_parent.transform.GetChild(illuminance_readings.Count - 2).transform);

                    }

                    if (illuminance_readings.Count > 10)
                    {
                        illuminance_counter++;

                        illuminance_parent.transform.GetChild(illuminance_readings.Count - 11).gameObject.SetActive(false);

                        foreach (Transform child in illuminance_parent.transform)
                        {
                            child.transform.localPosition = new Vector3(child.transform.localPosition.x - 10, child.transform.localPosition.y, 0);
                        }
                    }

                    break;

                case 5:

                    RSSI_readings.Add(graphpoint_instanced);

                    graphpoint_instanced.transform.parent = RSSI_parent.transform;

                    graphpoint_instanced.transform.localPosition = new Vector3(-100 + (RSSI_readings.Count - RSSI_counter) * 10, RSSI + 50, 0);

                    graphpoint_instanced.GetComponent<ReadingStorage>().storedvalue = RSSI;

                    connectingline = graphpoint_instanced.GetComponent<MeasureLine>();

                    if (RSSI_readings.Count >= 2)
                    {

                        MeasureLine.AddTarget(connectingline, RSSI_parent.transform.GetChild(RSSI_readings.Count - 2).transform);

                    }

                    if (RSSI_readings.Count > 10)
                    {
                        RSSI_counter++;

                        RSSI_parent.transform.GetChild(RSSI_readings.Count-11).gameObject.SetActive(false);

                        foreach (Transform child in RSSI_parent.transform)
                        {
                            child.transform.localPosition = new Vector3(child.transform.localPosition.x - 10, child.transform.localPosition.y, 0);
                        }
                    }

                    break;

                default:
                    break;
            }
        }
    }

    public void EnlargeMenu()
    {
        Side_Panels.transform.parent = Sensor_Menu.transform;
        
    }

    public void TestMessage()
    {
        ParseReceivedMessage(teststring);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
