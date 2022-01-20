using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Logo : MonoBehaviour
{
    public RectTransform logo;

    bool isDelay;
    bool isToggle;

    private void Start()
    {
        {
            
        }
        
    }
    

    private void FixedUpdate()
    {
        if (!isDelay)
        {
            isDelay = true;

            StartCoroutine(MovingLogo());
        }
        else
        {
            //Debug.Log("�Ƚ��� ������Ʈ ���� ����");
        }
    }

    IEnumerator MovingLogo()
    {
        if (!isToggle)
        {
            // Debug.Log("�Ʒ���");
            logo.DOAnchorPos(new Vector2(0, 300), 5f);
            isToggle = true;
        }
        else
        {
            // Debug.Log("����");
            logo.DOAnchorPos(new Vector2(0, 330), 5f);
            isToggle = false;
        }

        yield return new WaitForSeconds(5f);
        Debug.Log("false");
        isDelay = false;
    }
}
