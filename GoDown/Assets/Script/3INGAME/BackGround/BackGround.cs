using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] BackGrounds;
    public float BackGroundSpeed;


    private void Update()
    {        
        MoveObject();
    }

    private void MoveObject()
    {
        foreach (GameObject obj in BackGrounds)
        {
            obj.transform.Translate(Vector3.up * BackGroundSpeed * Time.deltaTime);
            if (obj.gameObject.transform.position.y > 38.35f)
            {
                obj.gameObject.transform.position = new Vector2(obj.gameObject.transform.position.x, -76.8f);
            }
        }
    }    
}
