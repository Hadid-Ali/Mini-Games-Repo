using Infrastructure.GameEvents;
using UnityEngine;

public class GameplayUIHandler : UIMenuBase
{
    [SerializeField] private GameText _scoreText;
    [SerializeField] private GameText _gameCompleteText;
    [SerializeField] private GameText _timeText;

    private GameObject _comboIcon;
    
    protected override void OnContainerEnable()
    {
        base.OnContainerEnable();
        
        GameEvents.GameplayUIEvents.ScoreUpdated.Register(OnScoreUpdated);
        GameEvents.GameplayUIEvents.ComboScored.Register(OnComboScored);
        GameEvents.GameplayUIEvents.TimeUpdated.Register(OnTimeUpdated);
        GameEvents.GameplayEvents.GameCompleted.Register(OnGameCompleted);
    }

    protected override void OnContainerDisable()
    {
        base.OnContainerDisable();
        
        GameEvents.GameplayUIEvents.ScoreUpdated.UnRegister(OnScoreUpdated);
        GameEvents.GameplayUIEvents.ComboScored.UnRegister(OnComboScored);
        GameEvents.GameplayUIEvents.TimeUpdated.UnRegister(OnTimeUpdated);
        GameEvents.GameplayEvents.GameCompleted.UnRegister(OnGameCompleted);
    }

    private void OnGameCompleted()
    {
        ChangeMenuState(MenuName.GameOver);
    }

    private void OnComboScored()
    {
        if (_comboIcon == null)
            _comboIcon.SetActive(true);
    }

    private void OnTimeUpdated(float time)
    {
        _timeText.SetText($"TIME: {time}");
    }
    
    private void OnScoreUpdated(int score, int addition)
    {
        _scoreText.SetText($"Score: {score}");
        _gameCompleteText.SetText($"Total Score: {score}");
    }
}
