using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public BackGround backGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("건드림");

        // collision.gameObject.transform.position = new Vector3(0, -57.6f, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("건드림");
        if (collision.gameObject.transform.position.y > 32)
        {
            backGround.SwapObject();
        }
    }


}
