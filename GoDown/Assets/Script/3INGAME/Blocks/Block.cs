using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 블럭에 부딪혔을때 블럭은
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("블락 터치");
            Player p = collision.gameObject.GetComponent<Player>();

            // 플레이어의 속도가 블럭 hp보다 크면
            if (p.gauge > hp)
            {
                // 블럭이 부서짐
                
            }
            else
            {
                // 블럭이 안부서짐

            }

        }
    }

    public float GetAfterGauge(float gauge)
    {
        return gauge - hp;
    }
}
