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
        // Ŭ������
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        canvas.enabled = true;
    }


    public void CloseButton()
    {
        // Ŭ������
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        // �ɼ�ĵ���� �ݱ�
        canvas.enabled = false;
    }
}
