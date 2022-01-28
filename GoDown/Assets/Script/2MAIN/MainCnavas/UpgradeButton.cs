using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UpgradeButton : MonoBehaviour
{
    public RectTransform mainCanvas;
    public void GoUpgrade()
    {
        // 업그레이드 실로
        // 메인 씬 종료
        mainCanvas.DOAnchorPos(new Vector2(-1200, 0), 0.25f);

        // 스토어 씬 켜기
        SceneManager.LoadSceneAsync("4STORE", LoadSceneMode.Additive);

        // 클릭사운드
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

    }

    public void ResetMain()
    {
        mainCanvas.DOAnchorPos(Vector2.zero, 0.25f);
    }
}
