using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;

public class GameFlowHandler : MonoBehaviour
{
   [SerializeField] private SoccerPlayersContainer _soccerPlayersContainer;
   [SerializeField] private GameScoreEvaluator _gameScoreEvaluator;
   [SerializeField] private GameFlowOperationsController _gameFlowOperationsController;
   
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
      _gameScoreEvaluator.AddScoreAgainstPlayer(selectionStatus, out bool isCompleted);

      if (!isCompleted && selectionStatus)
      {
         return;  
      }

      if (!selectionStatus)
      {
         RoundFailed();
      }
      else
      {
         RoundWin();
      }
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

      ScheduleGameTimeJob(gameModeMetaData);
      StartRoundWithDelay();
   }
   
   //Can Do Some Refactor to combine the Jobs later
   private void ScheduleGameTimeJob(GameModeMetaData gameModeMetaData)
   {
      //Job executes after 30 seconds only once
      GameEvents.JobEvents.ScheduleJob.Raise(new JobMetaData()
      {
         JobAction = OnGameCompleted,
         StepDelay = gameModeMetaData.TotalGameTime,
         Mode = JobTimeMode.TIME,
      });
      
      //Job executes Each second to update game time
      GameEvents.JobEvents.ScheduleJob.Raise(new JobMetaData()
      {
         StepDelay = 1,
         Duration = gameModeMetaData.TotalGameTime,
         Mode = JobTimeMode.TIME,
         OnProgress = OnGameTimeUpdated
      });
   }

   private void OnGameTimeUpdated(float time)
   {
      GameEvents.GameplayUIEvents.TimeUpdated.Raise(time);
   }
   
   private void StartRoundWithDelay()
   {
      Invoke(nameof(StartRound), 0.5f);
   }

   private void StartRound()
   {
      GameEvents.GameplayEvents.RoundStarted.Raise();
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
   
   private void OnGameCompleted()
   {
      Debug.Log($"Game completed {_gameScoreEvaluator.CurrentScore}");
      _gameFlowOperationsController.OnGameOver();  
   }

   private void RoundWin()
   {
      _gameFlowOperationsController.OnCorrectSelection();
   }
   
   private void RoundFailed()
   {
      _gameFlowOperationsController.OnWrongSelection();
   }
}
