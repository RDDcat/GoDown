using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go : MonoBehaviour
{
    public Canvas upgradeCanvas;
    public Canvas feverCanvas;

    private void Start()
    {
        upgradeCanvas.enabled = true;
        feverCanvas.enabled = true;
    }

    public void ExitStore()
    {
        SceneManager.UnloadSceneAsync("4STORE");
        SceneManager.LoadSceneAsync("2MAIN", LoadSceneMode.Additive);
    }


    public void GoUpgrade()
    {
        // ���Ž�
        // ���׷��̵� â���� ����
        // ���׷��̵� â���� ���� ��ư ����
        // �ǹ� ���׷��̵� â���ΰ��� ��ư �ѱ�
        upgradeCanvas.enabled = true;
        feverCanvas.enabled = false;
    }
    public void GoFever()
    {
        // ���Ž�
        // �ǹ� ���׷��̵� â���� ����
        // �ǹ� ���׷��̵� â���� ���� ��ư ����
        // ���׷��̵� â���ΰ��� ��ư �ѱ�
        upgradeCanvas.enabled = false;
        feverCanvas.enabled = true;
    }
}
