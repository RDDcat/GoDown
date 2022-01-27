using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmPlayer;
    public AudioClip[] bgmClip;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Bgm { Main, Ingame };
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
}
