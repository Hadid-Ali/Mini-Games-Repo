using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransformPointsCollectionServices : IGameService
{
   public Transform GetSoccerBallPoint();
   public Transform[] GetPlayerSpawnPoints();
}
