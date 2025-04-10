using System;
using UnityEngine;

public interface ISoccerBallTarget
{
    public Vector2 GetTargetPosition();
    public void Highlight(Action<bool> onSelection);
    public void UnHighlight();
    public void Select();
}
