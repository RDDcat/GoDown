using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    Player player;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    public void HighSpeedAni()
    {
        if (player.gauge > (player.gaugelimit / 3)*2)
        {
            // 빠른 애니메이션
            // Debug.Log("빠른 애니메이션으로 실행");
            animator.SetBool("HighSpeed", true);
        }
        else
        {
            // 저속 애니메이션
            // Debug.Log("느린 애니메이션으로 실행");
            animator.SetBool("HighSpeed", false);
        }
    }
}
