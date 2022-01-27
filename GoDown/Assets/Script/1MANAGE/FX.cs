using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    private void OnEnable()
    {
        //Ȱ��ȭ�� Ÿ�̸� �۵�
        Invoke(nameof(DeactiveDelay), 4);
    }

    void DeactiveDelay() => gameObject.SetActive(false);

    private void OnDisable()
    {
        //��Ȱ��ȭ�� ������Ʈ Ǯ�� ��ȯ
        EffectManager.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
