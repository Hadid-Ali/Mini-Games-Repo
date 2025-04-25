using System;
using Infrastructure.GameEvents;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour,ISoccerBallTarget
{
    private IHighlighterComponent _soccerPlayerHighlightHandler;
    
    private Transform _transform;
    private bool _isSelected;
    
    public bool IsHighlighted => _soccerPlayerHighlightHandler.IsHighlighted;
    
    private void Awake()
    {
        _transform = transform;
        CheckAndFixDependencies();
    }

    private void CheckAndFixDependencies()
    {
        _soccerPlayerHighlightHandler ??= GetComponent<IHighlighterComponent>();
    }

    public Vector2 GetTargetPosition() => _transform.position;

    public void Highlight()
    {
        CheckAndFixDependencies();
        ToggleHighlight(true);
        _soccerPlayerHighlightHandler.Highlight();
    }

    public void UnHighlight()
    {
        CheckAndFixDependencies();
        ToggleHighlight(false);
        _soccerPlayerHighlightHandler.UnHighlight();
    }

    public void Select()
    {
        GameEvents.GameplayEvents.SoccerPlayerSelected.Raise(this, _isSelected);
        UnHighlight();
    }

    private void ToggleHighlight(bool status)
    {
        _isSelected = status;
    }
}
