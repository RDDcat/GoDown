using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    


    public void GameStart()
    {
        // �����
        Debug.Log("���� ��ŸƮ");

        // ����ȯ
        if(SceneManager.GetSceneByName("3INGAME").isLoaded == false)
        {
            SceneManager.LoadSceneAsync("3INGAME", LoadSceneMode.Additive);
        }
        
        

        // ���� ���� ����

        //


    }

    public void GameEnd()
    {
        // ���� ���� ���� ������ ���ϱ�

        // ���� ����

        // ���� ���� ����Ʈ


    }
}
