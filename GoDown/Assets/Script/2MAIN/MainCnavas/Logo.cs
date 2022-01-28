using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Logo : MonoBehaviour
{
    public RectTransform logo;
    int clickCount;
    public GameObject fps_Check;


    bool isDelay;
    bool isToggle;

/*    private void Awake()
    {
        fps_Check = FindObjectOfType<FPS_Check>();
    }*/


    private void FixedUpdate()
    {
        if (!isDelay)
        {
            isDelay = true;

            StartCoroutine(MovingLogo());
        }
        else
        {
            //Debug.Log("픽스드 업데이트 실행 갯수");
        }
    }

    IEnumerator MovingLogo()
    {
        if (!isToggle)
        {
            // Debug.Log("아래로");
            logo.DOAnchorPos(new Vector2(0, 350), 5f);
            isToggle = true;
        }
        else
        {
            // Debug.Log("위로");
            logo.DOAnchorPos(new Vector2(0, 320), 5f);
            isToggle = false;
        }

        yield return new WaitForSeconds(5f);
        
        isDelay = false;
    }

    public void ShowFPS()
    {
        bool fpsOn = false;
        clickCount++;
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Dead);
        //Debug.Log("철퍽"+clickCount);
        if ((clickCount % 6 == 5) && fpsOn == false)
        {
            fps_Check.SetActive(true);
            fpsOn = true;
        }
        else
        {
            fps_Check.SetActive(false);
            fpsOn = false;
        }
    }
}
