using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform Upgrade, Fever;

    private void Start()
    {
        Upgrade.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void SwitchingUI1()
    {
        Upgrade.DOAnchorPos(new Vector2(1200, 0), 0.25f);
        Fever.DOAnchorPos(Vector2.zero, 0.25f);
    }
    public void SwitchingUI2()
    {
        Upgrade.DOAnchorPos(Vector2.zero, 0.25f);
        Fever.DOAnchorPos(new Vector2(1200, 0), 0.25f);
    }
}
