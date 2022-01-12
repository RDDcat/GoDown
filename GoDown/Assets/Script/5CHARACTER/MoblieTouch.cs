using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoblieTouch : MonoBehaviour
{

    private void Update()
    {
        OnTouch();
    }

    void OnTouch()
    {
        // 터치 입력시 실행
        if(Input.touchCount > 0)
        {
            // 
            Touch touch = Input.GetTouch(0);

            // 터치가 캐릭터보다 오른쪽일때

            // 캐릭터인 오른쪽으로 캐릭터 움직임 속도만큼 이동 (+델타타임?)


            // 터치가 캐릭터보다 왼쪽일때

            // 캐릭터인 왼쪽으로 캐릭터 움직임 속도만큼 이동 (+델타타임?)

        }


    }





}
