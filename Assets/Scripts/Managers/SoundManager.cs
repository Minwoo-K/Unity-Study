using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager
{
    public Transform Sound_Root { get; private set; }
    private Dictionary<int, AudioSource> AudioSources = new Dictionary<int, AudioSource>();

    public void Init()
    {
        if ( Sound_Root == null )
        {
            GameObject root = new GameObject() { name = "#SoundManager" };
            //DontDestroyOnLoad(go); // if needed
            Sound_Root = root.transform;
        }

        string[] soundTypes = Enum.GetNames(typeof(Define.AudioSourceType));
        for ( int i = 0; i < soundTypes.Length - 1; i++ )
        {
            GameObject go = new GameObject() { name = soundTypes[i] };
            go.transform.parent = Sound_Root;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            AudioSources.Add(i, audioSource);
            SourceSetup(i);
        }
    }

    private void SourceSetup(int AudioSourceType)
    {
        AudioSource source = null;

        switch ( AudioSourceType )
        {
            case (int)Define.AudioSourceType.Background:
                source = AudioSources[(int)Define.AudioSourceType.Background];
                source.loop = true;
                source.spatialBlend = 0;
                break;

            case (int)Define.AudioSourceType.SoundEfx:
                source = AudioSources[(int)Define.AudioSourceType.SoundEfx];
                source.loop = false;
                source.spatialBlend = 1;
                source.playOnAwake = false;
                break;

            case (int)Define.AudioSourceType.Narration:
                source = AudioSources[(int)Define.AudioSourceType.Narration];
                source.loop = false;
                source.spatialBlend = 0;
                source.playOnAwake = false;
                break;
        }
    }

    private AudioClip LoadClip(string location)
    {
        AudioClip audioClip = GameManager.Resource.Load<AudioClip>($"Sounds/{location}");
        
        if ( audioClip == null )
        {
            Debug.Log($"couldn't find an AudioClip named {location}");
            return null;
        }

        return audioClip;
    }

    public void Play(string audioLocation, Define.AudioSourceType sourceType = Define.AudioSourceType.SoundEfx, float pitch = 1f)
    {
        AudioClip audioClip = LoadClip(audioLocation);
        Play(audioClip, sourceType, pitch);
    }

    public void Play(AudioClip audioClip, Define.AudioSourceType sourceType = Define.AudioSourceType.SoundEfx, float pitch = 1f)
    {
        if (audioClip == null)
            return;

        AudioSource source = AudioSources[(int)sourceType];
        if (source.isPlaying)
        {
            source.Stop();
        }

        source.clip = audioClip;
        source.pitch = pitch;
        source.Play();
    }

    public void Clear()
    {
        Sound_Root = null;
        AudioSources.Clear();
    }
}
