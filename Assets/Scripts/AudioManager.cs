using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] AudioSource audio_music;
    [SerializeField] AudioSource audio_effect;
    [SerializeField] AudioType[] audio_list;

    public static AudioManager Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        
    }

    public void PlayAudioMusic(AudioTypes audio_type)
    {
        AudioClip clip = GetAudioClip(audio_type);
        if (clip != null)
        {
            audio_music.clip = clip;
            audio_music.Play();
        }
        else
            Debug.Log("Clip not found: " + audio_type);
    }

    public void PlayAudioEffect(AudioTypes audio_type)
    {
        AudioClip clip = GetAudioClip(audio_type);
        if (clip != null)
        {
            audio_effect.clip = clip;
            audio_effect.PlayOneShot(clip);
        }
        else
            Debug.Log("Clip not found: " + audio_type);
    }
    
    private AudioClip GetAudioClip(AudioTypes type_of_audio)
    {
        AudioType type = Array.Find(audio_list, x => x.audio_type == type_of_audio);
        if (type != null)
            return type.audio_clip;
        return null;
    }
}

[Serializable]
public class AudioType
{
    public AudioTypes audio_type;
    public AudioClip audio_clip;
}

public enum AudioTypes
{
    ButtonClick,
    Background,
    SnakeMove,
    Eat,
    Pause,
    GameOver,
    Resume,
    FoodSpawn
}

