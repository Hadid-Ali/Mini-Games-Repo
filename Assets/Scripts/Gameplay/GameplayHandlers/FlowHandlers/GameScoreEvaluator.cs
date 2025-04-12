using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;

public class GameScoreEvaluator : MonoBehaviour
{
    private int _stepsForScore = 0;
    private int _stepsForCombo = 0;
    
    private int _comboScore = 0;
    private int _negativeMarking = 0;
    
    private int _currentScore = 0;
    private int _currentConsecutiveHits = 0;
    private int _normalScoreAddition = 1;

    public void Initialize(GameModeMetaData gameModeMetaData)
    {
        _stepsForCombo = gameModeMetaData.ConsecutiveHitsForCombo;
       _comboScore = gameModeMetaData.ComboScore;
       _negativeMarking = gameModeMetaData.NegativeScoreForMistake;
    }

    public void SetMovesForScore(int movesForScore)
    {
        _stepsForScore = movesForScore;
    }

    public void AddScoreAgainstPlayer(bool status)
    {
        if (status)
        {
            _stepsForScore--;

            if (_stepsForScore <= 0)
            {
                AddScore();
            }
        }
        else
        {
            AddScoreInternal(-_negativeMarking);
        }
    }

    private void AddScore()
    {
        AddScoreInternal(_normalScoreAddition);
        _currentConsecutiveHits++;

        if (_currentConsecutiveHits >= _stepsForCombo)
        {
            _currentConsecutiveHits = 0;
            AddScoreInternal(_comboScore);
        }
    }

    private void AddScoreInternal(int score)
    {
        _currentScore += score;
        GameEvents.GameplayUIEvents.ScoreUpdated.Raise(_currentScore, score);
    }
}
