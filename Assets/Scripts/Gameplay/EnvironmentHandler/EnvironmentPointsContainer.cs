using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPointsContainer : MonoBehaviour, ITransformPointsCollectionServices
{
    [SerializeField] private Transform _soccerPointTransform;
    [SerializeField] private Transform[] _playerSpawnPoints;

    public Transform GetSoccerBallPoint() => _soccerPointTransform;
    public Transform[] GetPlayerSpawnPoints() => _playerSpawnPoints;
}
