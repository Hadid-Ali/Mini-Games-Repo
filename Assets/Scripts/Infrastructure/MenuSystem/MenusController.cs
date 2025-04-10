using System;
using UnityEngine;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine.Serialization;

public abstract class MenusController : MonoBehaviour
{
    [SerializeField] private List<UIMenuBase> _menusContainer;
    
    private MenuName _currentMenuStates;

    private void Awake()
    {
        CheckAndCacheMenus();
    }

    private void Start()
    {
        SetMenuState(MenuName.MainMenu);
    }

    protected virtual void OnEnable()
    {
        GameEvents.MenuEvents.MenuTransition.Register(OnMenuTransition);
    }

    protected virtual  void OnDisable()
    {
        GameEvents.MenuEvents.MenuTransition.UnRegister(OnMenuTransition);
    }
    
    public void CheckAndCacheMenus()
    {
        UIMenuBase[] menus = GetComponentsInChildren<UIMenuBase>();

        foreach (var menu in menus)
        {
            if (_menusContainer.Contains(menu))
                continue;
                
            _menusContainer.Add(menu);
        }
    }
        
    private void OnMenuTransition(MenuName menuName)
    {
        SetMenuState(menuName);
    }
    
    protected void SetMenuState(MenuName menuName)
    {
        SetMenuState_Internal(menuName);
        HideAllMenus();

        if (menuName is MenuName.None)
            return;
        
        _menusContainer.Find(x => x.MenuName == menuName).SetMenuActiveState(true);
    }
    
    private void SetMenuState_Internal(MenuName menuName)
    {
        _currentMenuStates = menuName;
    }
    
    private void HideAllMenus()
    {
        for (int i = 0; i < _menusContainer.Count; i++)
        {
            _menusContainer[i].SetMenuActiveState(false);
        }
    }
}