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

    public void GoHelp()
    {
        // 도움말 보이기
        tutorial[0].SetActive(true);
        tutorial[0].transform.position = transform.position;
        Option.SetActive(false);
    }

    public void GoNextHelp()
    {
        // 다음 도움말 보이기
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
