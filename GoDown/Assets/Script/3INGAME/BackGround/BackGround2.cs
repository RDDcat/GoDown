using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround2 : MonoBehaviour
{
    private MeshRenderer render;

    private float offset;
    public float speed;

    void Start()
    {
        render = GetComponentInChildren<MeshRenderer>();
    }


    void FixedUpdate()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(0, -offset);
    }
}
