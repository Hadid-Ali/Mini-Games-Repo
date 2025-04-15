using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;

public class GameplayUIHandler : UIMenuBase
{
    [SerializeField] private GameText _scoreText;
    [SerializeField] private GameText _timeText;

    protected override void OnContainerEnable()
    {
        base.OnContainerEnable();
        
        GameEvents.GameplayUIEvents.ScoreUpdated.Register(OnScoreUpdated);
        GameEvents.GameplayUIEvents.TimeUpdated.Register(OnTimeUpdated);
    }

    protected override void OnContainerDisable()
    {
        base.OnContainerDisable();
        
        GameEvents.GameplayUIEvents.ScoreUpdated.UnRegister(OnScoreUpdated);
        GameEvents.GameplayUIEvents.TimeUpdated.UnRegister(OnTimeUpdated);
    }

    private void OnTimeUpdated(float time)
    {
        _timeText.SetText($"TIME: {time}");
    }
    
    private void OnScoreUpdated(int score, int addition)
    {
        _scoreText.SetText($"Score: {score}");
    }
}
