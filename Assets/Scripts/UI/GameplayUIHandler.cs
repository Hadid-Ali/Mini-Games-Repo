using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;

public class GameplayUIHandler : MonoBehaviour
{
    [SerializeField] private GameText _scoreText;

    private void OnEnable()
    {
        GameEvents.GameplayUIEvents.ScoreUpdated.Register(OnScoreUpdated);
    }

    private void OnDisable()
    {
        GameEvents.GameplayUIEvents.ScoreUpdated.UnRegister(OnScoreUpdated);
    }

    private void OnScoreUpdated(int score, int addition)
    {
        _scoreText.SetText($"Score: {score}");
    }
}
