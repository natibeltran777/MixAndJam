using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControlScheme : IInputController
{
    public bool IsDownPressed()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    public bool IsLeftPressed()
    {
        return Input.GetKeyDown(KeyCode.A);
    }

    public bool IsRightPressed()
    {
        return Input.GetKeyDown(KeyCode.D);
    }

    public bool IsUpPressed()
    {
        return Input.GetKeyDown(KeyCode.W);
    }

    public bool IsAnyKeyReleased()
    {
        return Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S);
    }
}
