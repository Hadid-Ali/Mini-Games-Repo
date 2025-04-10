using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class UIMenuBase : MonoBehaviour
{
    [Header("Base Menu Refs")] 
    
    [SerializeField] private MenuName _menuName;
    [SerializeField] private GameObject _menuContainer;
      
    public MenuName MenuName => _menuName;

    public void SetMenuActiveState(bool isActive)
    {
        if (_menuContainer == null)
        {
            Debug.LogWarning("Menu Container is null");
            return;
        }

        _menuContainer.SetActive(isActive);

        if (isActive)
            OnContainerEnable();
        else
            OnContainerDisable();
    }

    protected virtual void OnContainerEnable()
    {

    }

    protected virtual void OnContainerDisable()
    {

    }

    protected void ChangeMenuState(MenuName menuName)
    {
        GameEvents.MenuEvents.MenuTransition.Raise(menuName);
    }
}
