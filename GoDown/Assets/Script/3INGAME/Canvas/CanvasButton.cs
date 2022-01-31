using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public GameObject pause;

    public void PauseGame()
    {
        Debug.Log("일시정지");

        // 게임 스탑
        Time.timeScale = 0;
        AudioListener.pause = true;

        // 퍼즈 캔버스 켜기
        pause.SetActive(true);
    }

    public void ResumeGame()
    {       
        // 퍼즈 캔버스 끄기
        pause.SetActive(false);

        Time.timeScale = 1;
        AudioListener.pause = false;
        Debug.Log("게임재개");                
    }    
}
