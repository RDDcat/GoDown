using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public GameObject pause;

    public void PauseGame()
    {
        // ���� ��ž
        Time.timeScale = 0;
        AudioListener.pause = true;

        // ���� ĵ���� �ѱ�
        pause.SetActive(true);

        //ȿ����
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
    }

    public void ResumeGame()
    {       
        // ���� ĵ���� ����
        pause.SetActive(false);

        Time.timeScale = 1;
        AudioListener.pause = false;

        //ȿ����
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
            Debug.LogErrorFormat("���� �Ŵ��� ã���� ����");
        }

        ResumeGame();
    }
}
