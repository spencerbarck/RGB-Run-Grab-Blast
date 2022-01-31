using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Sound[] sounds;
    
    private void Awake()
    {
        if(SoundManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance=this;
        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
            sound.source.pitch = sound.pitch;
        }
    }
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name ==name);
        if(s == null)
            return;
        s.source.Play();
    }
    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name ==name);
        if(s == null)
            return;
        s.source.Stop();
    }

    public void PlaySoundLoud(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name ==name);
        if(s == null)
            return;
        s.volume = 3f;
        s.source.Play();
    }
}
