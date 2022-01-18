using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround2 : MonoBehaviour
{
    private MeshRenderer render;

    private float offset;
    public float speed;
    // private
    public bool isBackGroundMove;

    void Start()
    {
        render = GetComponentInChildren<MeshRenderer>();
    }


    void FixedUpdate()
    {
        MoveBackGround();
    }

    void MoveBackGround()
    {
        if (isBackGroundMove)
        {
            offset += Time.deltaTime * speed;
            render.material.mainTextureOffset = new Vector2(0, -offset);
        }        
    }

    public void FreezeBackGroundMove()
    {
        Debug.Log("백그라운드 얼음");
        isBackGroundMove = false;
    }

    public void MeltBackGroundMove()
    {
        isBackGroundMove = true;
    }
}
