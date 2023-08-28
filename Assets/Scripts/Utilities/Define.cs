using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Masks
    {
        Obstacle = 7,
        Ground = 8,
        Enemy = 9,

    }

    public enum SceneType
    {
        None,
        Login,
        Game,
    }

    public enum AudioSourceType
    {
        Background,
        SoundEfx,
        Narration,

        Count
    }

    public enum MouseMode
    {
        Click,
        Press
    }

    public enum EventType
    {
        Click,
        Drag,
    }
}
