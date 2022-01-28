using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easter : MonoBehaviour
{
    int comboCount;

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Clicked()
    {
        comboCount++;
        StartCoroutine(CountCombo());
        Debug.Log(comboCount);
        switch (comboCount)
        {
            case 1:
                animator.SetInteger("ClickCount", 0);
                break;
            case 10:
                animator.SetInteger("ClickCount", 11);
                break;
            case 100:
                animator.SetInteger("ClickCount", 101);
                break;
        }
    }

    IEnumerator CountCombo()
    {
        float RTime = 1f;
        float Temp = RTime;
        while (comboCount > 1)
        {
            int C = comboCount;
            yield return new WaitForSeconds(0.5f);
            if (C == comboCount)
            {
                RTime -= 0.5f;
                if (RTime <= 0)
                {
                    comboCount = 0;
                }
            }
            else
            {
                RTime = Temp;
            }
        }
    }
}
