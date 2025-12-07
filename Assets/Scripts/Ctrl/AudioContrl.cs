using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioContrl : Singleton<AudioContrl>
{
    [Header("Main Setting")]
    [Range(0, 1)]
    public float musicVolume;
    [Range(0, 1)]
    public float sfxVolume;

    public AudioSource musicAus;
    public AudioSource sfxAus;

    [Header("Game Suund and Music")]

    public AudioClip shooting;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip[] bgMusics;//mang nhieu am thanh
    public override void Start()
    {
        PlayMusic(bgMusics);
    }


    public void PlaySound(AudioClip sound, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }
        if (aus)
        {
            aus.PlayOneShot(sound, sfxVolume);
        }
    }
    //mang nhieu am thanh hieu ung, ngau nhien nhac trong mang
    public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }
        if (aus)
        {
            int ranIdx = Random.Range(0, sounds.Length);

            if (sounds[ranIdx] != null)
            {
                aus.PlayOneShot(sounds[ranIdx], sfxVolume);
            }
        }
    }

    public void PlayMusic(AudioClip music, bool loop = true)
    {
        if (musicAus)
        {
            musicAus.clip = music;
            musicAus.loop = loop;
            musicAus.volume = musicVolume;
            musicAus.Play();
        }
    }
    

     //mang nhieu am thanh , ngau nhien nhac trong mang

    public void PlayMusic(AudioClip[] musics, bool loop = true)
    {
        if (musicAus)
        {
            int ranIdx = Random.Range(0, musics.Length);

            if (musics[ranIdx] != null)
            {
                musicAus.clip = musics[ranIdx];
                musicAus.loop = loop;
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }



}
