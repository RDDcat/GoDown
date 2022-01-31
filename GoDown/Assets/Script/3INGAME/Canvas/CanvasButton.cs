using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public GameObject pause;

    public void PauseGame()
    {
        // 게임 스탑
        Time.timeScale = 0;
        AudioListener.pause = true;

        // 퍼즈 캔버스 켜기
        pause.SetActive(true);

        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
    }

    public void ResumeGame()
    {       
        // 퍼즈 캔버스 끄기
        pause.SetActive(false);

        Time.timeScale = 1;
        AudioListener.pause = false;

        //효과음
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
    }

    public void EndGameWhilePlay()
    {
        try
        {
            FindObjectOfType<GameManager>().GameEndWhilePlay();
        }
        catch
        {
            Debug.LogErrorFormat("게임 매니저 찾을수 없음");
        }

        ResumeGame();
    }
}
