using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { Click, Dead, Break};
    int sfxCursor;

    private void Start()
    {
        instance = this;

        //배경음 시작
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
