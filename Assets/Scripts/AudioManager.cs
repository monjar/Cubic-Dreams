﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public Sound[] sounds;

    public static AudioManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            foreach (var sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Play("MainMenu");
        }
    }

    public void Play(string soundName)
    {
        try
        {
            var sound = Array.Find(sounds, s => s.name == soundName);
            sound.source.Play();
        }
        catch (Exception e)
        {
            print("Sound " + soundName + " Not Found!");
        }
    }

    public void Stop(string soundName)
    {
        try
        {
            var sound = Array.Find(sounds, s => s.name == soundName);
            sound.source.Stop();
        }
        catch (Exception e)
        {
            print("Sound " + soundName + " Not Found!");
        }
    }
}