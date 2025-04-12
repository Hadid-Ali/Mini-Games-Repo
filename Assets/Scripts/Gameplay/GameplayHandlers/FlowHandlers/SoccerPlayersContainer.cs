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

   public void Highlight(int count)
   {
      List<SoccerPlayer> players = _players.GetRandom(count);

      for (int i = 0; i < players.Count; i++)
      {
         players[i].Highlight();
      }
   }
}
