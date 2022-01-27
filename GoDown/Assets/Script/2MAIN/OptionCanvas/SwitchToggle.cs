using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;

    Color backgroundDefaultColor, handleDefaultColor;

    Image backgroundImage, handleImage;

    Toggle toggle;

    Vector2 handlePosition;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = backgroundImage.color;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);
    }

    void OnSwitch (bool on)
    {
        //핸들 위치전환
        uiHandleRectTransform.DOAnchorPos(on ? handlePosition * -1 : handlePosition, .4f).SetEase(Ease.InOutBack);
        //토글 배경색 전환
        backgroundImage.DOColor(on ? backgroundActiveColor : backgroundDefaultColor, .6f);
        //토글 핸들색 전환
        handleImage.DOColor(on ? handleActiveColor : handleDefaultColor, .6f);

    }

    private void OnDestroy()
    {
        
    }
}
