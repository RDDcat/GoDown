using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvas : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        if (canvas.enabled)
        {
            canvas.enabled = false;
        }
    }

    public void OpenOptionCanvas()
    {
        // 클릭사운드
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        canvas.enabled = true;
    }


    public void CloseButton()
    {
        // 클릭사운드
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        // 옵션캔버스 닫기
        canvas.enabled = false;
    }
}
