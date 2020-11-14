using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private ControllerType _controllerType;
    private IInputController _inputController;

    private int _verticalComponent = 0;
    private int _horizontalComponent = 0;

    public bool MovementIsInCoolDown
    {
        set
        {
            _movementIsInCooldown = value;
        }
        get
        {
            return _movementIsInCooldown;
        }
    }


    private bool _movementIsInCooldown = false;

    public Vector3 GetCurrentDirection
    {
        get
        {
            return GetNormalizedDirection();
        }
    }

    private void Awake()
    {
        switch (_controllerType)
        {
            // TODO add the other control schemes
            case ControllerType.WASD:
                _inputController = new WASDControlScheme();
                return;
            case ControllerType.ArrowKeys:
                _inputController = new ArrowKeyControlScheme();
                return;
            case ControllerType.Switch:
                return;
            case ControllerType.Xbox:
                return;
            default:
                return;
        }
    }

    private void Update()
    {
        if (_movementIsInCooldown == false)
        {
            if (_inputController.IsUpPressed())
            {
                _verticalComponent = 1;
            }
            if (_inputController.IsDownPressed())
            {
                _verticalComponent = -1;
            }
            if (_inputController.IsRightPressed())
            {
                _horizontalComponent = 1;
            }
            if (_inputController.IsLeftPressed())
            {
                _horizontalComponent = -1;
            }
            if (_inputController.IsAnyKeyReleased())
            {
                ResetMovementComponents();
            }
        }
    }

    private Vector3 GetNormalizedDirection()
    {
        return new Vector3(_horizontalComponent,_verticalComponent,0);
    }

    /// <summary>
    /// Resets vertical and horizontal components
    /// </summary>
    public void ResetMovementComponents()
    {
        _verticalComponent = 0;
        _horizontalComponent = 0;
    }

}

public enum ControllerType
{
    WASD,
    ArrowKeys,
    Switch,
    Xbox
};