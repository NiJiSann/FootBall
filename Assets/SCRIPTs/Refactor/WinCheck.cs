using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    [SerializeField] private GameState _gameState;

    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _drawScreen;

    

    public void Check(int egyScore, int cmrScore, int egyAttempt, int cmrAttempt)
    {
        if (egyAttempt == 3 && cmrAttempt == 3)
        {
            if (egyScore - cmrScore >= 2)
            {
                _winScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else if (cmrScore - egyScore >= 2)
            {
                _loseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (egyAttempt == 4 && cmrAttempt == 4)
        {
            if (egyScore > cmrScore)
            {
                _winScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else if (egyScore == cmrScore)
            {
                _drawScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                _loseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
