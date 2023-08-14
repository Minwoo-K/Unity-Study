using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Interface : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> UI_Storage = new Dictionary<Type, UnityEngine.Object[]>();

    private enum Images
    {
        Interface_Panel,
    }

    private enum Texts
    {
        Score_TMPText,
        ScoreButton_TMPText,
    }

    private enum Buttons
    {
        Score_Button,
    }

    private enum GameObjects
    {
        Interface_Panel,
        Score_TMPText,
        ScoreButton_TMPText,
        Score_Button,
    }

    private void Awake()
    {
        Bind<GameObject>(typeof(GameObjects));
    }

    public void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        UI_Storage.Add(typeof(T), objects);

        for ( int i = 0; i < names.Length; i++ )
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Utils.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Utils.FindChild<T>(gameObject, names[i], true);
            }
        }
    }
}
