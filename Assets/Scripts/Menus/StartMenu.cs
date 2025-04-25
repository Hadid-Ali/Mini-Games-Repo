using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : UIMenuBase
{
   [SerializeField] private Button _easyModeButton;
   [SerializeField] private Button _mediumModeButton;
   [SerializeField] private Button _hardModeButton;

   private void Start()
   {
      _easyModeButton.onClick.AddListener(OnEasyButtonTap);
      _mediumModeButton.onClick.AddListener(OnMediumButtonTap);
      _hardModeButton.onClick.AddListener(OnHardButtonTap);
   }

   private void OnEasyButtonTap()
   {
      StartGameWithMode(GameMode.EASY);
   }

   private void OnMediumButtonTap()
   {
      StartGameWithMode(GameMode.MEDIUM);
   }

   private void OnHardButtonTap()
   {
      StartGameWithMode(GameMode.HARD);
   }
   
   private void StartGameWithMode(GameMode gameMode)
   {
      ChangeMenuState(MenuName.Gameplay);
      GameEvents.GameSetupEvents.GameModeSelected.Raise(gameMode);
   }
}
