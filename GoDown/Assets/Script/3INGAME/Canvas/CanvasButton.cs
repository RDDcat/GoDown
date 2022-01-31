using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public GameObject pause;

    public void PauseGame()
    {
        Debug.Log("�Ͻ�����");

        // ���� ��ž
        Time.timeScale = 0;
        AudioListener.pause = true;

        // ���� ĵ���� �ѱ�
        pause.SetActive(true);
    }

    public void ResumeGame()
    {       
        // ���� ĵ���� ����
        pause.SetActive(false);

        Time.timeScale = 1;
        AudioListener.pause = false;
        Debug.Log("�����簳");                
    }    
}
