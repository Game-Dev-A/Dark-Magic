using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image imageToFill;
    public TMP_Text PV;

    public void SetMaxHealt(int healt)
    {
        slider.maxValue = healt;  //Set the max value of the sllider
        slider.value = healt;  //Set the value of the slider

        imageToFill.color = gradient.Evaluate(1f);  //Set the color of the bar
    }

    public void setHealt(int healt)
    {
        slider.value = healt;  //Updated the value of the bar

        imageToFill.color = gradient.Evaluate(slider.normalizedValue);  //Updated the color of the bar

        PV.text = $"PV {healt}/100";  //Updated the PV text
    }
}
