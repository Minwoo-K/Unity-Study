using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager
{
    private AudioSource[] AudioSources;
    private Dictionary<string, AudioClip> AudioClip_pool = new Dictionary<string, AudioClip>();

    public Transform Sound_Root { get; private set; }


    public void Init()
    {
        GameObject root = GameObject.Find("#SoundManager");
        if ( root == null )
        {
            root = new GameObject() { name = "#SoundManager" };
            //DontDestroyOnLoad(go); // if needed
        }
        Sound_Root = root.transform;

        string[] soundTypes = Enum.GetNames(typeof(Define.AudioSourceType));
        AudioSources = new AudioSource[soundTypes.Length - 1]; // "Length-1" is to exclude the "Count" in the enum

        for ( int i = 0; i < soundTypes.Length - 1; i++ )
        {
            GameObject go = new GameObject() { name = soundTypes[i] };
            go.transform.parent = Sound_Root;
            AudioSources[i] = go.AddComponent<AudioSource>();
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

    private AudioClip GetOrAddAudioClip(string location)
    {
        AudioClip audioClip = null;
        if ( AudioClip_pool.TryGetValue(location, out audioClip) )
        {
            return audioClip;
        }
        else
        {
            audioClip = GameManager.Resource.Load<AudioClip>($"Sounds/{location}");
        }

        if ( audioClip == null )
        {
            Debug.Log($"couldn't find an AudioClip named {location}");
            return null;
        }

        AudioClip_pool.Add(location, audioClip);
        return audioClip;
    }

    public void Play(string audioLocation, Define.AudioSourceType sourceType = Define.AudioSourceType.SoundEfx, float pitch = 1f)
    {
        AudioClip audioClip = GetOrAddAudioClip(audioLocation);
        Play(audioClip, sourceType, pitch);
    }

    public void Play(AudioClip audioClip, Define.AudioSourceType sourceType = Define.AudioSourceType.SoundEfx, float pitch = 1f)
    {
        if (audioClip == null)
            return;

        AudioSource source = AudioSources[(int)sourceType];
        if ( sourceType != Define.AudioSourceType.SoundEfx )
        {
            if (source.isPlaying)
            {
                source.Stop();
            }

            source.clip = audioClip;
            source.pitch = pitch;
            source.Play();
        }
        else
        {
            source.pitch = pitch;
            source.PlayOneShot(audioClip);
        }
        
    }

    public void Clear()
    {
        Sound_Root = null;
        AudioSources = null;
        AudioClip_pool.Clear();
    }
}
