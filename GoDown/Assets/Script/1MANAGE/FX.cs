using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    private void OnEnable()
    {
        //활성화시 타이머 작동
        Invoke(nameof(DeactiveDelay), 4);
    }

    void DeactiveDelay() => gameObject.SetActive(false);

    private void OnDisable()
    {
        //비활성화시 오브젝트 풀로 반환
        EffectManager.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
