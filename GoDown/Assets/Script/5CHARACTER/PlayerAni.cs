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
            // ���� �ִϸ��̼�
            // Debug.Log("���� �ִϸ��̼����� ����");
            animator.SetBool("HighSpeed", true);
        }
        else
        {
            // ���� �ִϸ��̼�
            // Debug.Log("���� �ִϸ��̼����� ����");
            animator.SetBool("HighSpeed", false);
        }
    }
}
