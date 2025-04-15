using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompletedMenu : UIMenuBase
{
   [SerializeField] private Button _restartButton;

   private void Start()
   {
      _restartButton.onClick.AddListener(OnRestart);
   }

   private void OnRestart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
