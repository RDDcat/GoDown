using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public GameObject[] blocks;

    public float speed;

    private void FixedUpdate()
    {
        MoveObject();
    }

    void MoveObject()
    {
        foreach (GameObject obj in blocks)
        {
            obj.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
