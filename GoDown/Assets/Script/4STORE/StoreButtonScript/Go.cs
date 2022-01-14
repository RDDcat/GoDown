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
        feverCanvas.enabled = false;
    }

    public void ExitStore()
    {
        SceneManager.UnloadSceneAsync("4STORE");
        SceneManager.LoadSceneAsync("2MAIN", LoadSceneMode.Additive);
    }


    public void GoUpgrade()
    {
        // 업그레이드 창으로 가기
        // 업그레이드 창으로 가기 버튼 끄기
        // 피버 업그레이드 창으로가기 버튼 켜기
        upgradeCanvas.enabled = true;
        feverCanvas.enabled = false;
    }
    public void GoFever()
    {
        // 피버 업그레이드 창으로 가기
        // 피버 업그레이드 창으로 가기 버튼 끄기
        // 업그레이드 창으로가기 버튼 켜기
        upgradeCanvas.enabled = false;
        feverCanvas.enabled = true;
    }
}
