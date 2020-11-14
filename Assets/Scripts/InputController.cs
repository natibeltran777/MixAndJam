using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface with general function of any input used
/// </summary>
public interface IInputController
{
    bool IsLeftPressed();
    bool IsRightPressed();
    bool IsDownPressed();
    bool IsUpPressed();
    bool IsAnyKeyReleased();
}
