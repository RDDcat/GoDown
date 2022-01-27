using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffSound : MonoBehaviour
{

    public void OnOff_BGM(bool on)
    {
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        //브금 온오프
        BGM_Player.SetActive(on ? true : false);
    }
    public void OnOff_SFX(bool on)
    {
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        //효과음 온오프
        if (on)
        {
            SFX_Player.SetActive(true);
            SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
        }
        else
        {
            SFX_Player.SetActive(false);
        }
    }
}
