using UnityEngine;

[DefaultExecutionOrder(-10)]
public class EnvironmentPointsContainer : MonoBehaviour, ITransformPointsCollectionServices
{
    [SerializeField] private Transform _soccerPointTransform;
    [SerializeField] private Transform[] _playerSpawnPoints;

    public Transform GetSoccerBallPoint() => _soccerPointTransform;
    public Transform[] GetPlayerSpawnPoints() => _playerSpawnPoints;

    private void Awake()
    {
        ServiceLocator.RegisterService<ITransformPointsCollectionServices>(this);
    }
}
