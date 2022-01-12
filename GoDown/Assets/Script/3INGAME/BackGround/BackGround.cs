using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] BackGrounds;
    public float BackGroundSpeed;


    private void FixedUpdate()
    {        
        MoveObject();
    }

    private void MoveObject()
    {
        foreach (GameObject obj in BackGrounds)
        {
            obj.transform.Translate(Vector3.up * BackGroundSpeed * Time.deltaTime);
        }
    }

    public void SwapObject()
    {
        if(BackGrounds[0].transform.position.y > BackGrounds[1].transform.position.y)
        {
            BackGrounds[0].gameObject.transform.position = new Vector3(0, BackGrounds[1].transform.position.y - 38.4f, 0);
        }
        else
        {
            BackGrounds[1].gameObject.transform.position = new Vector3(0, BackGrounds[0].transform.position.y - 38.4f, 0);
        }
    }
    
}
