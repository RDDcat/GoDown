using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeButton : MonoBehaviour
{
    
    public void GoUpgrade()
    {
        // ���׷��̵� �Ƿ�
        // ���� �� ����
        SceneManager.UnloadSceneAsync("2MAIN");

        // ����� �� �ѱ�
        SceneManager.LoadSceneAsync("4STORE", LoadSceneMode.Additive);

    }
}
