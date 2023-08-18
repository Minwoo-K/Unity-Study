using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager
{
    public Transform Sound_Root { get; private set; }
    private Dictionary<string, AudioSource> AudioSources = new Dictionary<string, AudioSource>();

    public void Init()
    {
        GameObject root = new GameObject() { name = "#SoundManager" };
        //DontDestroyOnLoad(go); // if needed
        Sound_Root = root.transform;

        string[] soundTypes = Enum.GetNames(typeof(Define.AudioSourceType));
        for ( int i = 0; i < soundTypes.Length; i++ )
        {
            GameObject go = new GameObject() { name = soundTypes[i] };
            go.transform.parent = Sound_Root;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            AudioSources.Add(soundTypes[i], audioSource);
        }
    }
}
