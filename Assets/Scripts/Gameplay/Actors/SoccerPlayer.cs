using System;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour,ISoccerBallTarget
{
    private Transform _transform;
    private bool _isSelected;

    private GameEvent<bool> _onSelection = new();
    
    private void Awake()
    {
        _transform = transform;
    }

    private void OnDestroy()
    {
        _onSelection.UnRegisterAll();
        _onSelection = null;
    }

    public Vector2 GetTargetPosition() => _transform.position;

    public void Highlight(Action<bool> onSelection)
    {
        _onSelection.Register(onSelection);
        ToggleHighlight(true);
    }

    public void UnHighlight()
    {
        _onSelection.UnRegisterAll();
        ToggleHighlight(false);
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
