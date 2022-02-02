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
    public GameObject playerPos;

    bool isFever;

    void FixedUpdate()
    {
        if(isFever)
        {
            Vector2 playerViewPos = Camera.main.WorldToScreenPoint(new Vector3(playerPos.transform.position.x, playerPos.transform.position.y + 5.5f));
            feverSlider.transform.position = playerViewPos;
            Debug.Log(" 플레이어 위치 좌표 " + playerViewPos);
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
