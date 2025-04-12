using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreEvaluator : MonoBehaviour
{
    private int _stepsForScore = 0;
    private int _stepsForCombo = 0;
    
    private int _comboScore = 0;
    private int _negativeMarking = 0;
    
    private int _currentScore = 0;
    private int _currentConsecutiveHits = 0;

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
    }

    private void AddScore()
    {
        _currentScore++;
        _currentConsecutiveHits++;

        if (_currentConsecutiveHits >= _stepsForCombo)
        {
            _currentConsecutiveHits = 0;
            _currentScore += _comboScore;
        }
    }
}
