using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;
    public float speed;
<<<<<<< HEAD
    public int score;
    public float resistance;
=======
    public int blockLv;
>>>>>>> [UPDATE] ì´í™íŠ¸ ë§¤ë‹ˆì €, ì´í™íŠ¸ í”„ë¦¬í© ì—…ë°ì´íŠ¸, ì•±ì´ë¯¸ì§€ ì¶”ê°€


    // private
    public bool isBlocksMove = true;

    private void Start()
    {
        // rigid = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        MoveObject();
        Destroy();
    }

    public void SetSpeed(float _speed)
    {
        // Debug.Log("ºí·°º° ¼Óµµº¯È­ °¹¼ö");
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
        if (gameObject.activeSelf)
        {
            if (isBlocksMove)
            {
                // rigid.AddForce(Vector3.up * speed );
                transform.Translate(0, speed * 0.008f, 0);
                //* Time.deltaTime
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ÇÃ·¹ÀÌ¾î°¡ ºí·°¿¡ ºÎµúÇûÀ»¶§ ºí·°Àº
        if(collision.gameObject.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();

            // ÇÃ·¹ÀÌ¾îÀÇ ¼Óµµ°¡ ºí·° hpº¸´Ù Å©¸é
            if (p.gauge >= hp)
            {
                Debug.Log("ºí·° ºÎ¼­Áü");
                // ºí·°ÀÌ ºÎ¼­Áü
                gameObject.SetActive(false);
                // ºí·° ÆÄ±« ÀÌÆåÆ®
                switch (blockLv)
                {
                    case 0 :
                        GameObject Break1 = EffectManager.SpawnFromPool("Break1", rigid.position);
                        break;
                    case 1:
                        GameObject Break2 = EffectManager.SpawnFromPool("Break2", rigid.position);
                        break;
                    case 2:
                        GameObject Break3 = EffectManager.SpawnFromPool("Break3", rigid.position);
                        break;
                }
                

                // Á¡¼ö È¹µæ (ÀÏ´Ü +1000)
                AccountManager.instance.score += score;


            }
            else
            {
                // ºí·°ÀÌ ¾ÈºÎ¼­Áü
                gameObject.SetActive(false);
            }

        }
    }

    public float GetAfterGauge(float gauge)
    {
        float damage = hp * resistance;
        return gauge - damage;
    }

    public void SetBlock(int _hp, float _speed, int _score, float _resistance)
    {
        hp = _hp;
        speed = _speed;
        score = _score;
        resistance = _resistance / (_resistance + 2500);

    }
}
