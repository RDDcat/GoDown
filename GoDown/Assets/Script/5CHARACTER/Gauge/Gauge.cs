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

    bool isFever;

    private void FixedUpdate()
    {
        if(isFever)
        {
            feverSlider.transform.position = player.transform.position;
        }
    }


    public void SetSlider()
    {
        float max = (10000 - ((player.gameManager.blockSpeedLimit - 10) * 125));
        if(max < 0)
        {
            max = 0;
        }
        backGround.offsetMax = new Vector2(0, max);
    }

    public void UpdateGaugeSlider(float gauge)
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
        isFever = false;
    }

    public void OpenFeverSlider()
    {
        feverSlider.gameObject.SetActive(true);
        isFever = true;
        feverSlider.value = 1;
    }
}
