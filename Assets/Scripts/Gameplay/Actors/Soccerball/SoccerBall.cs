using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.GameEvents;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    [SerializeField] private float _travelTime = 0.5f;
    
    private Transform _transform;
    private Vector2 _defaultPosition;
    private Vector3 _offsetVector = new(0f, -0.25f);

    private void Start()
    {
        _transform = transform;
        _defaultPosition = _transform.position;
    }

    private void OnEnable()
    {
        GameEvents.GameplayEvents.SoccerPlayerSelected.Register(OnSoccerPlayerSelected);
        GameEvents.GameplayEvents.RoundStarted.Register(OnRoundStarted);
    }

    private void OnDisable()
    {
        GameEvents.GameplayEvents.SoccerPlayerSelected.UnRegister(OnSoccerPlayerSelected);
        GameEvents.GameplayEvents.RoundStarted.UnRegister(OnRoundStarted);
    }

    private void OnRoundStarted()
    {
        _transform.position = _defaultPosition;
    }

    private void OnSoccerPlayerSelected(SoccerPlayer player, bool status)
    {
        Vector2 position = player.transform.position + _offsetVector;
        _transform.DOMove(position, _travelTime);
    }
}
