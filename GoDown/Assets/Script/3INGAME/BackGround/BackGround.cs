using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Blocks blocks;

    public GameObject[] BackGrounds;
    public float BackGroundSpeed;

    private void Start()
    {
        blocks = FindObjectOfType<Blocks>();
    }

    private void Update()
    {        
        MoveObject();
    }

    private void MoveObject()
    {
        for(int i =0; i< BackGrounds.Length; i++)
        {
            BackGrounds[i].transform.Translate(Vector3.up * BackGroundSpeed * Time.deltaTime / 2f);
            if (BackGrounds[i].gameObject.transform.position.y > 38.35f)
            {
                BackGrounds[i].gameObject.transform.position = new Vector2(BackGrounds[i].gameObject.transform.position.x, -76.8f);
            }
        }
    }    
}
