using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameTextUpdatedComponent : MonoBehaviour
{
    private IGameText _gameText;
    
    private void Awake()
    {
        _gameText = GetComponent<IGameText>();
    }

    private void OnEnable()
    {
        _gameText.SubscribeToTextUpdate(OnTextUpdated);
    }

    private void OnDisable()
    {
        _gameText.UnSubscribeFromTextUpdate(OnTextUpdated);
    }
    
    protected abstract void OnTextUpdated();
}
