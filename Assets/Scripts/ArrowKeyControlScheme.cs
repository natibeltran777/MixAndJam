using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyControlScheme : IInputController
{
    public bool IsDownPressed()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }

    public bool IsLeftPressed()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow);
    }

    public bool IsRightPressed()
    {
        return Input.GetKeyDown(KeyCode.RightArrow);
    }

    public bool IsUpPressed()
    {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }

    public bool IsAnyKeyReleased()
    {
        return Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow);
    }
}
