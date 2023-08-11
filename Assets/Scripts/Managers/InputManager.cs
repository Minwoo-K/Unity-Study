using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action keyController = null;
    public Action<Define.MouseMode> mouseController = null;

    private bool pressed = false; // To Detect Press Event

    public void UpdateInput()
    {
        if (keyController != null)
        {
            keyController.Invoke();
        }

        if (mouseController != null)
        {
            if (Input.GetMouseButton(0))
            {
                if (pressed)
                {
                    mouseController.Invoke(Define.MouseMode.Press);
                }
                else
                {
                    pressed = true;
                    mouseController.Invoke(Define.MouseMode.Click);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                pressed = false;
            }

        }
    }
}
