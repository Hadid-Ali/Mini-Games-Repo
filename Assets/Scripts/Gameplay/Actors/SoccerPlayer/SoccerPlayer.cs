using System;
using Infrastructure.GameEvents;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour,ISoccerBallTarget
{
    [SerializeField] private IHighlighterComponent _soccerPlayerHighlightHandler;
    
    private Transform _transform;
    private bool _isSelected;

    private GameEvent<bool> _onSelection = new();
    
    private void Awake()
    {
        _transform = transform;
        CheckAndFixDependencies();
    }

    private void CheckAndFixDependencies()
    {
        _soccerPlayerHighlightHandler ??= GetComponent<IHighlighterComponent>();
    }

    private void OnDestroy()
    {
        _onSelection.UnRegisterAll();
        _onSelection = null;
    }

    public Vector2 GetTargetPosition() => _transform.position;

    public void Highlight(Action<bool> onSelection)
    {
        CheckAndFixDependencies();
        _onSelection.Register(onSelection);
        ToggleHighlight(true);
        _soccerPlayerHighlightHandler.Highlight();
    }

    public void UnHighlight()
    {
        CheckAndFixDependencies();
        _onSelection.UnRegisterAll();
        ToggleHighlight(false);
        _soccerPlayerHighlightHandler.UnHighlight();
    }

    public void Select()
    {
        _onSelection.Raise(_isSelected);
    }

    private void ToggleHighlight(bool status)
    {
        _isSelected = status;
    }
}
