using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    public Canvas canvas;

    

    public void CloseGameOverCanvas()
    {
        canvas.enabled = false;
    }

    public void OpenGameOverCanvas()
    {
        canvas.enabled = true;
    }

}
