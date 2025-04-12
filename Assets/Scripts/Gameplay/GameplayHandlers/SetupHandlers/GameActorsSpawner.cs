using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;

public class GameActorsSpawner : MonoBehaviour
{
    private ITransformPointsCollectionServices _transformPointsCollectionServices;
    
    [SerializeField] private SoccerBall _soccerBallPrefab;
    [SerializeField] private SoccerPlayer _soccerPlayerPrefab;
    
    //Setup a repository for metadata access across the project
    [SerializeField] private SoccerPlayerMetaData[] _soccerPlayerMetaDatas;
    
    private Transform _soccerBallPointTransform;
    private Transform [] _soccerPlayerPoints;
    
    void Start()
    {
        _transformPointsCollectionServices = ServiceLocator.GetService<ITransformPointsCollectionServices>();

        if (_transformPointsCollectionServices == null)
        {
            Debug.LogError("No ITransformPointsCollectionServices found.");
            return;
        }
        
        _soccerBallPointTransform = _transformPointsCollectionServices.GetSoccerBallPoint();
        _soccerPlayerPoints = _transformPointsCollectionServices.GetPlayerSpawnPoints();
    }

    public void SpawnSoccerBall()
    {
        SoccerBall soccerBall = Instantiate(_soccerBallPrefab, _soccerBallPointTransform.position, _soccerBallPointTransform.rotation);
        GameEvents.GameSetupEvents.SoccerBallSpawned.Raise(soccerBall);
    }

    public void SpawnSoccerPlayers(int count, PlayerCompositionType compositionType)
    {
        switch (compositionType)
        {
            case PlayerCompositionType.LINEAR:
                SpawnLinear(count);
                break;
            
            case PlayerCompositionType.RANDOM:
                SpawnRandomly(count);
                break;
        }
    }

    private void SpawnLinear(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnPlayerInternal(_soccerPlayerPoints[i]);
        }
    }

    private void SpawnRandomly(int count)
    {
        List<Transform> spawnPoints = new();
        spawnPoints.AddRange(_soccerPlayerPoints);
        
        while (count > 0)
        {
            Transform spawnPoint = spawnPoints.GetRandom();
            spawnPoints.Remove(spawnPoint);
            
            SpawnPlayerInternal(spawnPoint);
            
            count--;
        }
    }

    private void SpawnPlayerInternal(Transform spawnPoint)
    {
        SoccerPlayer player = Instantiate(_soccerPlayerPrefab,spawnPoint.position,
            spawnPoint.rotation);

        player.GetComponent<SoccerPlayerViewHandler>().SetIcon(_soccerPlayerMetaDatas.GetRandom().Icon);
        GameEvents.GameSetupEvents.SoccerPlayerSpawned.Raise(player);
    }
}
