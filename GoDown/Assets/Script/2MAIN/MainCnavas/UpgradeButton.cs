using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeButton : MonoBehaviour
{
    public Canvas mainCanvas;
    public void GoUpgrade()
    {
        // 업그레이드 실로
        // 메인 씬 종료
        SceneManager.UnloadSceneAsync("2MAIN");

        // 스토어 씬 켜기
        SceneManager.LoadSceneAsync("4STORE", LoadSceneMode.Additive);
        // 클릭사운드
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

    }
}
