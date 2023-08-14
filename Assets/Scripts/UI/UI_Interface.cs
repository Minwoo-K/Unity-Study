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
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    private void Start()
    {
        GetText((int)Texts.Score_TMPText).text = "GetText complete";
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

    public T Get<T>(int index) where T: UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if ( UI_Storage.TryGetValue(typeof(T), out objects) )
        {
            return objects[index] as T;
        }

        Debug.Log($"Couldn't find the {index}th object in {typeof(T)}");
        return null;
    }
    
    public Image GetImage(int index) { return Get<Image>(index); }
    public Button GetButton(int index) { return Get<Button>(index); }
    public TextMeshProUGUI GetText(int index) { return Get<TextMeshProUGUI>(index); }
}
