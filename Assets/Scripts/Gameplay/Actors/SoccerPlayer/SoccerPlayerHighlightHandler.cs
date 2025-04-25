using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayerHighlightHandler : MonoBehaviour, IHighlighterComponent
{
    [SerializeField] private SoccerPlayerViewHandler _soccerPlayerViewHandler;

    [Header("Materials")] [SerializeField] private Material _highlightedMaterial;
    [SerializeField] private Material _normalMaterial;

    private bool _isHighlighted = false;

    public bool IsHighlighted => _isHighlighted;
    
    private void Start()
    {
        _soccerPlayerViewHandler ??= GetComponentInParent<SoccerPlayerViewHandler>();
    }
    
    public void Highlight()
    {
        _isHighlighted = true;
        _soccerPlayerViewHandler.SetMaterial(_highlightedMaterial);
    }

    public void UnHighlight()
    {
        _isHighlighted = false;
        _soccerPlayerViewHandler.SetMaterial(_normalMaterial);
    }
}
