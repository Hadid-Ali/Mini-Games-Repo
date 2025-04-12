using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using TMPro;
using UnityEngine;

public class GameText : MonoBehaviour,IGameText
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private GameEvent _onTextUpdated = new();
    
    public void SetText(string text)
    {
        _text.text = text;
        _onTextUpdated.Raise();
    }

    public void SubscribeToTextUpdate(Action onTextUpdated)
    {
        _onTextUpdated.Register(onTextUpdated);
    }

    public void UnSubscribeFromTextUpdate(Action onTextUpdated)
    {
        _onTextUpdated.UnRegister(onTextUpdated);
    }
}
