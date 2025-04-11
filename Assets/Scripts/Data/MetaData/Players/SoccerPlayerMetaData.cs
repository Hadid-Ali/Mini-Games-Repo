using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoccerPlayerMetaData", menuName = "ScriptableObjects/MetaData/Create SoccerPlayerMetaData")]
public class SoccerPlayerMetaData : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
}
