using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionHandler : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter()
    {
        DOTween.Kill("Test");
        Sequence collisionSequence = DOTween.Sequence();
        collisionSequence.Append(_playerMovement.transform.DOMove(_playerMovement.PreviousPosition, _playerMovement.MovementDuration));
      
        collisionSequence.OnComplete(_playerMovement.MovementEnded);
        //_playerMovement.CurrentMovement.Kill();
    }
    
}
