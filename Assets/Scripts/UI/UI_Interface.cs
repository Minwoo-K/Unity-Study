using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Interface : UI_Base
{
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

    public override void Init()
    {
        //Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GameObject go = GetText((int)Texts.Score_TMPText).gameObject;
        UI_EventHandler evt = go.AddOrGetComponent<UI_EventHandler>();

        go.AddUIEvent((PointerEventData data) => { evt.gameObject.transform.position = data.position; }, Define.EventType.Drag);
    }

    private void Start()
    {
        
    }

    int score = 0;
    public void IncreaseScore()
    {
        GetText((int)Texts.Score_TMPText).text = $"Score: {++score}";
    }

}
