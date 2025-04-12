using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameTextScaleComponent : GameTextUpdatedComponent
{
    [SerializeField] private RectTransform _rectTransform;
    
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;
    
    private Vector3 _originalScale = Vector3.one;
    
    protected override void OnTextUpdated()
    {
        ScaleInternal(_scale, OnScaledUp);
    }

    private void OnScaledUp()
    {
        ScaleInternal(_originalScale, null);
    }

    private void ScaleInternal(Vector3 value, TweenCallback callback)
    {
        var component = _rectTransform.DOScale(value, _duration).SetEase(_ease);

        if (callback != null)
        {
            component.onComplete += callback;
        }
    }
}
