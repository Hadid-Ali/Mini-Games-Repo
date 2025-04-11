using System.Collections;
using System.Collections.Generic;
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
        Instantiate(_soccerBallPrefab, _soccerBallPointTransform.position, _soccerBallPointTransform.rotation);
    }

    public void SpawnSoccerPlayers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SoccerPlayer player = Instantiate(_soccerPlayerPrefab, _soccerPlayerPoints[i].position,
                _soccerPlayerPoints[i].rotation);

            player.GetComponent<SoccerPlayerViewHandler>().SetIcon(_soccerPlayerMetaDatas.GetRandom().Icon);
        }
    }
}
