using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public GameObject BGM_Group;
    public GameObject SFX_Group;

    public AudioSource bgmPlayer;
    public AudioClip[] bgmClip;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Bgm { Main, Ingame, Next };
    public enum Sfx { Click, Dead, Break};
    int sfxCursor;

    private void Start()
    {
        instance = this;

        //배경음 시작
        bgmPlay(Bgm.Main);
    }

    public void bgmPlay(Bgm type)
    {
        switch (type)
        {
            case Bgm.Main:
                bgmPlayer.clip = bgmClip[0];
                break;
            case Bgm.Ingame:
                bgmPlayer.clip = bgmClip[1];
                break;
            case Bgm.Next:
                bgmPlayer.clip = bgmClip[2];
                break;
        }

        //배경음 재생
        bgmPlayer.Play();
    }


    public void sfxPlay(Sfx type)
    {
        switch (type)
        {
            case Sfx.Click:
                sfxPlayer[sfxCursor].clip = sfxClip[0];
                break;
            case Sfx.Dead:
                sfxPlayer[sfxCursor].clip = sfxClip[1];
                break;
            case Sfx.Break:
                sfxPlayer[sfxCursor].clip = sfxClip[2];
                break;
        }

        //효과음 재생
        sfxPlayer[sfxCursor].Play();
        //효과음 커서작동
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }

    public void OnOff_BGMPlayer(bool on)
    {
        //브금 활성 비활성
        BGM_Group.SetActive(on ? true : false);
    }
    public void OnOff_SFXPlayer(bool on)
    {
        //효과음 활성 비활성
        if (on)
        {
            SFX_Group.SetActive(true);
        }
        else
        {
            SFX_Group.SetActive(false);
        }
    }
}
