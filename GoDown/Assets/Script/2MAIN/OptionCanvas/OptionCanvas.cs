using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvas : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        if (canvas.enabled)
        {
            canvas.enabled = false;
        }
    }

    public void OpenOptionCanvas()
    {
        canvas.enabled = true;
    }


    public void CloseButton()
    {
        // ¿É¼ÇÄµ¹ö½º ´Ý±â
        canvas.enabled = false;
    }
}
