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
        slider.maxValue = healt;
        slider.value = healt;

        imageToFill.color = gradient.Evaluate(1f);
    }

    public void setHealt(int healt)
    {
        slider.value = healt;

        imageToFill.color = gradient.Evaluate(slider.normalizedValue);

        PV.text = $"PV {healt}/100";
    }
}
