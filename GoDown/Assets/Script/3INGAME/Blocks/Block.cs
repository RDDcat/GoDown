using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;
    public float speed;

    public Rigidbody2D rigid;

    // private
    public bool isBlocksMove = true;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        MoveObject();
        Destroy();
    }

    public void SetSpeed(float _speed)
    {
        // Debug.Log("블럭별 속도변화 갯수");
        speed = _speed;
    }

    private void Destroy()
    {
        if (gameObject.transform.position.y > 40)
        {
            gameObject.SetActive(false);
        }
    }

    void MoveObject()
    {
        if (isBlocksMove)
        {
            rigid.AddForce(Vector3.up * speed );
            //* Time.deltaTime
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 블럭에 부딪혔을때 블럭은
        if(collision.gameObject.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();

            // 플레이어의 속도가 블럭 hp보다 크면
            if (p.gauge >= hp)
            {
                Debug.Log("블럭 부서짐");
                // 블럭이 부서짐
                gameObject.SetActive(false);

                // 점수 획득 (일단 +1000)
                AccountManager.instance.score += 1000;


            }
            else
            {
                // 블럭이 안부서짐
                gameObject.SetActive(false);
            }

        }
    }

    public float GetAfterGauge(float gauge)
    {
        return gauge - hp;
    }

    public void SetBlock(int _hp, float _speed)
    {
        hp = _hp;
        speed = _speed;
    }
}
