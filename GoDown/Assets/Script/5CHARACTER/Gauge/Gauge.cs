using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Slider slider;
    public RectTransform backGround;

    public Player player;

    public void SetGaugeSlider(float gauge)
    {
        slider.value = 1 - (gauge / player.gaugelimit);
    }

}
