using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverEffect : MonoBehaviour
{
    public GameObject FeverHighlight;
    bool isFever = false;
    int rand = 0;
    int pre_rand;

    public void RandomShake()
    {
        rand = Random.Range(0, 4);

        //연속 같은 번호 제거
        if (pre_rand == rand)
        {
            rand = (rand + 1)%4;
            Debug.Log("연속 번호 제거");
        }
        switch(rand){
            case 0:
                ShakeOrig();
                pre_rand = rand;
                break;
            case 1:
                ShakeLeftRight();
                pre_rand = rand;
                break;
            case 2:
                ShakeUpDown();
                pre_rand = rand;
                break;
            case 3:
                Shakediagonal();
                pre_rand = rand;
                break;
        }
    }

    void ShakeOrig()
    {
        FeverHighlight.transform.localScale = new Vector3(1, 1);
        Debug.Log("피버 반전1");
    }
    void ShakeLeftRight()
    {
        FeverHighlight.transform.localScale = new Vector3(-1,1);
        Debug.Log("피버 반전2");
    }

    void ShakeUpDown()
    {
        FeverHighlight.transform.localScale = new Vector3(1, -1);
        Debug.Log("피버 반전3");
    }
    void Shakediagonal()
    {
        FeverHighlight.transform.localScale = new Vector3(-1, -1);
        Debug.Log("피버 반전4");
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
