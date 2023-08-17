using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup : UI_Base
{
    public static Transform PopupUI_Root { get; private set; }

    public override void Init()
    {
        PopupUI_Root.SetParent(GameManager.UI.UI_Root);
    }

    public void SetCanvas()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = GameManager.UI.SortingOrder;

        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.matchWidthOrHeight = 0.5f;
        //canvasScaler.referenceResolution = 
    }
}
