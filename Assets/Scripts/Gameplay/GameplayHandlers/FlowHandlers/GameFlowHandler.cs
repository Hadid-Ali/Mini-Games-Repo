using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;

public class GameFlowHandler : MonoBehaviour
{
   [SerializeField] private SoccerPlayersContainer _soccerPlayersContainer;
   [SerializeField] private GameScoreEvaluator _gameScoreEvaluator;
   
   private SoccerBall _soccerBall;
   private GameModeMetaData _currentGameMode;

   private void OnEnable()
   {
      GameEvents.GameSetupEvents.GameModeInitialized.Register(OnGameModeInitialized);
      GameEvents.GameplayEvents.SoccerPlayerSelected.Register(OnSoccerPlayerSelected);
      GameEvents.GameSetupEvents.SoccerBallSpawned.Register(OnSoccerBallSpawned);
   }

   private void OnDisable()
   {
      GameEvents.GameSetupEvents.GameModeInitialized.UnRegister(OnGameModeInitialized);
      GameEvents.GameplayEvents.SoccerPlayerSelected.UnRegister(OnSoccerPlayerSelected);
      GameEvents.GameSetupEvents.SoccerBallSpawned.UnRegister(OnSoccerBallSpawned);
   }

   private void OnSoccerBallSpawned(SoccerBall soccerBall)
   {
      _soccerBall = soccerBall;
   }
   
   private void OnSoccerPlayerSelected(SoccerPlayer soccerPlayer, bool selectionStatus)
   {
      Debug.Log($"Selected {soccerPlayer} with selection status {selectionStatus}");
      _gameScoreEvaluator.AddScoreAgainstPlayer(selectionStatus);
   }

   private void OnGameModeInitialized(GameModeMetaData gameModeMetaData)
   {
      _currentGameMode = gameModeMetaData;
      _gameScoreEvaluator.Initialize(gameModeMetaData);
      
      Invoke(nameof(HighlightPlayers), 0.5f);
   }

   private void HighlightPlayers()
   {
      int movesForScore =
         Random.Range(_currentGameMode.MinNumberOfTapsForMove, _currentGameMode.MaxNumberOfTapsForMove);

      _soccerPlayersContainer.Highlight(movesForScore);
      _gameScoreEvaluator.SetMovesForScore(movesForScore);
   }
}
