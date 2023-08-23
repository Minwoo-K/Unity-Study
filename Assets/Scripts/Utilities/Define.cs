using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
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
