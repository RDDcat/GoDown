using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvas : MonoBehaviour
{
    public Canvas canvas;
    public GameObject[] tutorial;
    public GameObject Option;


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

    public void GoHelp()
    {
        // ���� ���̱�
        tutorial[0].SetActive(true);
        tutorial[0].transform.position = transform.position;
        Option.SetActive(false);
    }

    public void GoNextHelp()
    {
        // ���� ���� ���̱�
        for(int index = 0; index < tutorial.Length; index++)
        {
            if (tutorial[index].activeSelf)
            {
                tutorial[index].SetActive(false);

                if(index + 1 == tutorial.Length)
                {                                    
                    Option.SetActive(true);

                    return;
                }

                tutorial[index + 1].SetActive(true);

                tutorial[index + 1].transform.position = transform.position;

                return;
            }
        }
        

    }
}
