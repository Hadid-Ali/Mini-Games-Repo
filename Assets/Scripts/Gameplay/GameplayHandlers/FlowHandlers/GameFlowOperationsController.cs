using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowOperationsController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private AudioClip _correctSelection;
    [SerializeField] private AudioClip _wrongSelection;
    [SerializeField] private AudioClip _gameOverSound;

    public void OnGameOver()
    {
        _audioSource.PlayOneShot(_gameOverSound);
    }

    public void OnCorrectSelection()
    {
        _audioSource.PlayOneShot(_correctSelection);
    }

    public void OnWrongSelection()
    {
        _audioSource.PlayOneShot(_wrongSelection);
    }
}
