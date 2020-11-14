using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _gridLength = 1.5f;
    [SerializeField]
    private float _movementDuration = 0.2f;

    private Vector3 _previousPosition;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    
    public Sequence CurrentMovement;
    public Vector3 PreviousPosition => _previousPosition;
    public float MovementDuration => _movementDuration;

    private bool _movementIsInProgress = false;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        //_rigidbody = GetComponentInChildren<Rigidbody>();
        _previousPosition = this.transform.position;
        CurrentMovement = DOTween.Sequence();
    }

    private void FixedUpdate()
    {
        Vector3 currDirection = _playerInput.GetCurrentDirection * _gridLength;
        if (currDirection != Vector3.zero && !_movementIsInProgress)
        {
            // This 0.5f will be hard coded into the game
            // Might replace later with a value that relates to the bpm
            _playerInput.MovementIsInCoolDown = true;
            _movementIsInProgress = true;

            CurrentMovement.Append(transform.DOMove(_previousPosition + currDirection, _movementDuration).OnComplete(MovementEnded).SetId("Test"));
        }
    }

    /// <summary>
    /// Movement has been performed and all values reset to prepare for next movement
    /// </summary>
    public void MovementEnded()
    {
        //_rigidbody.s
        //_rigidbody.transform.DOMove(Vector3.zero, _movementDuration);
        _playerInput.MovementIsInCoolDown = false;
        _movementIsInProgress = false;
        _playerInput.ResetMovementComponents();
        _previousPosition = this.transform.position;
    }
}
