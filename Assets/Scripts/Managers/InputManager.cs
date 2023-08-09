using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action inputController = null;

    public void UpdateInput()
    {
        if (inputController != null)
        {
            inputController.Invoke();
        }
    }
}
