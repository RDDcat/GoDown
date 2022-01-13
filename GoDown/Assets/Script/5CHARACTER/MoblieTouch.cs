using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoblieTouch : MonoBehaviour
{
    public Transform t;
    public float speed;
    public Text tt;
    public Text ttt;

    private void Update()
    {
        OnTouch();
    }

    void OnTouch()
    {
        // 터치 입력시 실행
        if(Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            float offset = speed * Time.deltaTime;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(touch.position);

            // 디버그 텍스트
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
