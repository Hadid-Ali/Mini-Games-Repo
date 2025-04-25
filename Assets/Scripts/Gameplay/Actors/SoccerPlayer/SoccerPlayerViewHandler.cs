using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayerViewHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        CheckAndFixReferences();
    }

    void CheckAndFixReferences()
    {
        _spriteRenderer ??= GetComponent<SpriteRenderer>();
    }

    public void SetIcon(Sprite icon)
    {
        CheckAndFixReferences();
        _spriteRenderer.sprite = icon;
    }

    public void SetMaterial(Material material)
    {
        _spriteRenderer.materials = new[] { material };
    }
}
