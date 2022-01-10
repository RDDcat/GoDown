using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    

    void Start()
    {
        InitScene();
    }

    // �� �ʱ� ����
    void InitScene()
    {
        LoadSceneByName("2MAIN");

        UnloadSceneByName("3INGAME");
        UnloadSceneByName("4STORE");
        UnloadSceneByName("5CHARACTER");
    }
    void LoadSceneByName(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded == false)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }

    void UnloadSceneByName(string sceneName)
    {
        Debug.Log("���� �̰� �۵�����?");
        if (SceneManager.GetSceneByName(sceneName).isLoaded == true)
        {
            Debug.Log("���� �̰� �۵���!!");
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }



}
