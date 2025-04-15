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
      _gameScoreEvaluator.AddScoreAgainstPlayer(selectionStatus, out bool isCompleted);

      if (!isCompleted)
         return;

      NextRound();
   }

   private void NextRound()
   {
      CancelInvoke(nameof(CancelInvoke));
      StartRoundWithDelay();
   }

   private void OnGameModeInitialized(GameModeMetaData gameModeMetaData)
   {
      _currentGameMode = gameModeMetaData;
      _gameScoreEvaluator.Initialize(gameModeMetaData);
      
      GameEvents.JobEvents.ScheduleJob.Raise(new JobMetaData()
      {
         JobAction = OnGameCompleted,
         StepDelay = gameModeMetaData.TotalGameTime,
         Mode = JobTimeMode.TIME,
      });
      StartRoundWithDelay();
   }

   private void StartRoundWithDelay()
   {
      Invoke(nameof(StartRound), 0.5f);
   }

   private void OnGameCompleted()
   {
      Debug.Log($"Game completed {_gameScoreEvaluator.CurrentScore}");
   }

   private void StartRound()
   {
      HighlightPlayers();
      Invoke(nameof(RoundFailed),
         Random.Range(_currentGameMode.MinTimeForSelection, _currentGameMode.MaxTimeForSelection));
   }
   
   private void HighlightPlayers()
   {
      int movesForScore =
         Random.Range(_currentGameMode.MinNumberOfTapsForMove, _currentGameMode.MaxNumberOfTapsForMove);

      _soccerPlayersContainer.Highlight(movesForScore);
      _gameScoreEvaluator.SetMovesForScore(movesForScore);
   }

   private void RoundFailed()
   {
      Debug.LogError("Round Failed");
   }
}
