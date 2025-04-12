using System;
using UnityEngine;
using System.Collections.Generic;
using Infrastructure.GameEvents;

public class SoccerPlayersContainer : MonoBehaviour
{
   private List<SoccerPlayer> _players = new();
   
   private void OnEnable()
   {
      GameEvents.GameSetupEvents.SoccerPlayerSpawned.Register(OnSoccerPlayerSpawned);
   }

   private void OnDisable()
   {
      GameEvents.GameSetupEvents.SoccerPlayerSpawned.UnRegister(OnSoccerPlayerSpawned);
   }

   private void OnSoccerPlayerSpawned(SoccerPlayer soccerPlayer)
   {
      _players.Add(soccerPlayer);
   }

   private void UnHighlightAll()
   {
      for (int i = 0; i < _players.Count; i++)
      {
         _players[i].UnHighlight();
      }
   }
   
   public void Highlight(int count)
   {
      UnHighlightAll();
      
      int spawnCount = 0;
      
      if (_players.Count < count)
      {
         Debug.LogError("Not Enough Players");
         return;
      }

      while (spawnCount < count)
      {
         SoccerPlayer player = _players.GetRandom();

         if (player.IsHighlighted)
            continue;
         
         player.Highlight();
         spawnCount++;
      }
   }
}
