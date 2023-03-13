using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadingStorage : MonoBehaviour
{
    public float storedvalue;

    public string storedtime;

    public Shaper2D point_colors;

    private int menu_num;

    public TextMeshProUGUI temperature_displayed, humidity_displayed, pressure_displayed, illuminance_displayed, RSSI_displayed, temperature_timed, humidity_timed, pressure_timed, illuminance_timed, RSSI_timed; 

    public void ShowValueOnHovered()
    {
        menu_num = ParseFromArduino.sensor_menu_opened;

        point_colors.innerColor = Color.green;
        point_colors.outerColor = Color.green;

        switch (menu_num)
        {
            case 1:
                temperature_displayed.text = storedvalue.ToString();
                temperature_timed.text = storedtime + "GMT";
                break;

            case 2:
                humidity_displayed.text = storedvalue.ToString();
                humidity_timed.text = storedtime + "GMT";
                break;

            case 3:
                pressure_displayed.text = storedvalue.ToString();
                pressure_timed.text = storedtime + "GMT";
                break;

            case 4:
                illuminance_displayed.text = storedvalue.ToString();
                illuminance_timed.text = storedtime + "GMT";
                break;

            case 5:
                RSSI_displayed.text = storedvalue.ToString();
                RSSI_timed.text = storedtime + "GMT";
                break;

            default:
                break;
        }
    }

    public void UnHoverAxisPoint()
    {
        point_colors.innerColor = Color.white;
        point_colors.outerColor = Color.white;
    }
}
