using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Slider slider;
    public Slider feverSlider;
    public RectTransform backGround;

    public Player player;

    public void SetGaugeSlider(float gauge)
    {
        slider.value = 1 - (gauge / player.gaugelimit);
    }

    public void SetFeverSlider(float time)
    {
        feverSlider.value -= time;
    }

    public void CloseFeverSlider()
    {
        feverSlider.gameObject.SetActive(false);
    }

    public void OpenFeverSlider()
    {
        feverSlider.gameObject.SetActive(true);    
        feverSlider.value = 1;
    }
}
