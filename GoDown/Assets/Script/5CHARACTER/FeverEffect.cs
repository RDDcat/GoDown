using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverEffect : MonoBehaviour
{
    RectTransform rectTrans;
    public GameObject FeverHighlight;
    bool isFever = false;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    public void ShakeOrig()
    {
        rectTrans.localScale = new Vector3(1, 1);
    }
    public void ShakeLeftRight()
    {
        rectTrans.localScale = new Vector3(-1,1);
    }

    public void ShakeUpDown()
    {
        rectTrans.localScale = new Vector3(1, -1);
    }

    public void OnOff_Fever()
    {
        if (isFever)
        {
            FeverHighlight.SetActive(false);
            isFever = false;
        } else
        {
            FeverHighlight.SetActive(true);
            isFever = true;
        }
    }

}
