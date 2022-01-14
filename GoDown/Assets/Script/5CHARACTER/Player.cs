using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float gauge;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 블럭에 부딪혔을때 플레이어는
        if (collision.gameObject.tag == "Block")
        {
            // 블럭 채력 받아와서 speed 감소
            Block block = collision.gameObject.GetComponent<Block>();
            gauge = block.GetAfterGauge(gauge);

            // gauge 가 음수면 사망띠
            IsPlayerDead();

            // 점수 증가

        }
    }

    void IsPlayerDead()
    {
        if(gauge < 0)
        {
            //플레이어 사망


            // 게임종료
            gameManager.GameEnd();

            // 디버그
            Debug.Log("플레이어의 gauge가 다 닳았습니다... (사망)");

        }
    }
}
