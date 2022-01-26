using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoblieTouch : MonoBehaviour
{
    public Transform t;
    public float playerSpeed;
    public Text tt;
    public Text ttt;
    // private
    public bool isTouch;

    private void Start()
    {
        playerSpeed = AccountManager.instance.accountVO.playerSpeed;
    }

    private void Update()
    {
        OnTouch();
    }

    void OnTouch()
    {
        if (isTouch)
        {
            // ��ġ �Է½� ����
            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);
                float offset = playerSpeed * Time.deltaTime;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(touch.position);

                // ����� �ؽ�Ʈ
                tt.text = touch.position.x.ToString();
                ttt.text = mousePos.x.ToString();


                if (mousePos.x - transform.position.x > 0)
                {
                    transform.position = new Vector2(transform.position.x + offset, transform.position.y);
                }
                if (mousePos.x - transform.position.x < 0)
                {
                    transform.position = new Vector2(transform.position.x - offset, transform.position.y);
                }




            }
        }

    }


    // �ܺο��� ��ġ ��Ʈ��
    public void FreezeTouch()
    {        
        isTouch = false;
    }

    public void MeltTouch()
    {
        isTouch = true;
    }


    // ������ ����׿�
    public void Right()
    {                   
        float offset = playerSpeed * Time.deltaTime;
            
        transform.position = new Vector2(transform.position.x + 1, transform.position.y);
           
    }
    public void Left()
    {
        float offset = playerSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x - 1, transform.position.y);
    }



}
