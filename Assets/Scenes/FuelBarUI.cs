using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarUI : MonoBehaviour
{
    // Unity UI References
    public Slider slider;
    public Text displayText;
    public PlayerCharacter player;

    private float fuel = 0f;
    public float Fuel
    {
        get
        {
            return fuel;
        }
        set
        {
            fuel = value;
            slider.value = fuel;
            displayText.text = (slider.value * 100).ToString("0");
        }
    }

    void Update()
    {
        Fuel = player.fuelLevel;
    }
}
