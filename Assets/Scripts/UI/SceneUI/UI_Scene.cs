using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Scene : UI_Base
{
    public override void Init()
    {
        SetCanvas();
    }

    public void SetCanvas()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 0;

        //CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
        //canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        //canvasScaler.matchWidthOrHeight = 0.5f;
        //canvasScaler.referenceResolution = 
    }
}
