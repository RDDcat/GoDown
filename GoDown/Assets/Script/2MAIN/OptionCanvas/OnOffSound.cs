using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSound : MonoBehaviour
{
    SoundManager soundManager;

    bool BGMOn, SFXOn;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void OnOff_BGM()
    {
        
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        //��� �¿���
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
        //ȿ���� �¿���
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
}
