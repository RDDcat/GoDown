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
        // ���׷��̵� �Ƿ�
        // ���� �� ����
        mainCanvas.DOAnchorPos(new Vector2(-1200, 0), 0.25f);

        // ����� �� �ѱ�
        SceneManager.LoadSceneAsync("4STORE", LoadSceneMode.Additive);

        // Ŭ������
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);

    }

    public void ResetMain()
    {
        mainCanvas.DOAnchorPos(Vector2.zero, 0.25f);
    }
}
