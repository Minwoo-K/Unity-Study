using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        transform.SetParent(GameManager.UI.PopupUI_Root);
        SetCanvas();
    }

    public void SetCanvas()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = GameManager.UI.SortingOrder;

        //CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
        //canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        //canvasScaler.matchWidthOrHeight = 0.5f;
        //canvasScaler.referenceResolution = 
    }
}
