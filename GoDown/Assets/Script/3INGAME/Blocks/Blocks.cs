using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public float speed;
        
    
    public void FreezeBlocks()
    {
        Debug.Log("FreezeBlocks ¾óÀ½");        
        speed = 0;
    }        
}
