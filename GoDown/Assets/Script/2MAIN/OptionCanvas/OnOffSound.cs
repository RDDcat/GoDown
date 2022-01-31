using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSound : MonoBehaviour
{
    SoundManager soundManager;

    bool BGMOn, SFXOn, SWTOn;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void OnOff_BGM()
    {
        
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        //브금 온오프
        Debug.Log("BGM" + BGMOn);
        if (BGMOn)
        {
            soundManager.OnOff_BGMPlayer(true);
            BGMOn = false;
        }
        else
        {
            soundManager.OnOff_BGMPlayer(false);
            BGMOn = true;
        }
    }
    public void OnOff_SFX()
    {
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        Debug.Log("SFX" + SFXOn);
        //효과음 온오프
        if (SFXOn)
        {
            soundManager.OnOff_SFXPlayer(true);
            SFXOn = false;
            SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        }
        else
        {
            soundManager.OnOff_SFXPlayer(false);
            SFXOn = true;
        }
    }

    public void SwitchControl()
    {
        if (SWTOn)
        {
            PlayerPrefs.SetInt("Touch", 1);
            SWTOn = false;
        }
        else
        {
            PlayerPrefs.SetInt("Touch", 0);
            SWTOn = true;
        }
    }
}
