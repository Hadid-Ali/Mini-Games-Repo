using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "GameModeMetaData", menuName = "ScriptableObjects/MetaData/Create GameModeMetaData")]
public class GameModeMetaData : ScriptableObject
{
    [field: SerializeField] public GameMode GameMode { get; private set; }
    [field: SerializeField] public PlayerCompositionType PlayerCompositionType { get; private set; }

    [field: SerializeField, Header("Game Settings")] public int NumberOfSoccerPlayers { get; private set; }
    [field: SerializeField] public float TotalGameTime { get; private set; }
    [field: SerializeField] public float MinTimeForSelection { get; private set; }
    [field: SerializeField] public float MaxTimeForSelection { get; private set; }

    [field: SerializeField, Header("Combo Settings")] public int ConsecutiveHitsForCombo { get; private set; }

    [field: SerializeField] public int ComboScore { get; private set; }

    [field: SerializeField, Header("Gameplay Settings")] public int MinNumberOfTapsForMove { get; private set; }
    [field: SerializeField] public int MaxNumberOfTapsForMove { get; private set; }
    [field: SerializeField] public int NegativeScoreForMistake { get; private set; }
}
