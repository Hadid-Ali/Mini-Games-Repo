using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;

public class LevelSetupHandler : MonoBehaviour
{
   [SerializeField] private List<GameModeMetaData> _gameModes = new();
   [SerializeField] private GameActorsSpawner _gameActorsSpawner;

   private GameModeMetaData _currentGameMode;
   
   private void OnEnable()
   {
      GameEvents.GameplayEvents.GameModeSelected.Register(SetupLevel);
   }

   private void OnDisable()
   {
      GameEvents.GameplayEvents.GameModeSelected.UnRegister(SetupLevel);
   }

   [ContextMenu("Setup Level")]
   public void SetupLevelTest()
   {
      SetupLevel(GameMode.MEDIUM);
   }

   private void SetupLevel(GameMode mode)
   {
      _currentGameMode = _gameModes.Find(x => x.GameMode == mode);
      SetupLevelInternal();
   }

   private void SetupLevelInternal()
   {
      _gameActorsSpawner.SpawnSoccerBall();
      _gameActorsSpawner.SpawnSoccerPlayers(_currentGameMode.NumberOfSoccerPlayers,
         _currentGameMode.PlayerCompositionType);
   }
}
