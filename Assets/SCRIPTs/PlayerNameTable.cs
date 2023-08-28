using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerNameTable : MonoBehaviour
{
    [SerializeField] private GameObject _playerNameHolder;
    [SerializeField] private GameObject _opponentNameHolder;

    private bool _isPlayer = false;

    private void OnEnable()
    {
        // GameState.OnStateChange += UpdateVisual;
    }

    private void OnDisable()
    {
        // GameState.OnStateChange += UpdateVisual;
    }
    
    private void Start()
    {
        if (PlayerPrefs.GetString("character") == "Amy")
            _isPlayer = true;
        
        SwitchHolder();
    }
    private void UpdateVisual(GameState.GameStates obj)
    {
        SwitchHolder();
    }
    private void SwitchHolder()
    {
        if (!_isPlayer)
        {
            _playerNameHolder.SetActive(true);
            _opponentNameHolder.SetActive(false);
            _isPlayer = true;
        }
        else
        {
            _isPlayer = false;
            _playerNameHolder.SetActive(false);
            _opponentNameHolder.SetActive(true);
        }
    }
}