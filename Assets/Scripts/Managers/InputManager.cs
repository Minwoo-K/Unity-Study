using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action keyController = null;
    public Action mouseController = null;

    public void UpdateInput()
    {
        if (keyController != null)
        {
            keyController.Invoke();
        }

        if (mouseController != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseController.Invoke();
            }
        }
    }
}
