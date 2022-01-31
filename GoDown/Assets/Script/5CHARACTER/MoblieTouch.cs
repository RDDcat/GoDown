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
    public int touchVersion; // 터치 입력방식 변환

    private void Start()
    {
        playerSpeed = AccountManager.instance.accountVO.playerSpeed;
        touchVersion = PlayerPrefs.GetInt("Touch");
    }

    private void Update()
    {
        OnTouch();
    }

    void OnTouch()
    {
        if (isTouch)
        {
            TouchVer(touchVersion);
        }

    }

    void TouchVer(int version)
    {
        // 버전 1
        if (version == 1)
        {
            // 터치 입력시 실행
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float offset = playerSpeed * Time.deltaTime;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(touch.position);

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
        else // 버전 2
        {
            // 터치 입력시 실행
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float offset = playerSpeed * Time.deltaTime;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(touch.position);

                if (mousePos.x - Camera.main.transform.position.x > 0)
                {
                    transform.position = new Vector2(transform.position.x + offset, transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - offset, transform.position.y);
                }
            }
        }
    }

    // 외부에서 터치 컨트롤
    public void FreezeTouch()
    {        
        isTouch = false;
    }

    public void MeltTouch()
    {
        isTouch = true;
    }


    // 에디터 디버그용
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
