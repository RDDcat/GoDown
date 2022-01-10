using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    

    void Start()
    {
        InitScene();
    }

    // æ¿ √ ±‚ ªÛ≈¬
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
        if (SceneManager.GetSceneByName(sceneName).isLoaded == true)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }



}
