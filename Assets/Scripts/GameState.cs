using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _enemyGK;
    [SerializeField] private GameObject _playerGK;

    public enum GameStates
    {
        kick,
        save,
        watch
    }

    private static  GameStates gameState;

    public static GameStates GetState
    {
        get
        {
            return gameState;
        }
        set
        {
            gameState = value;
            OnStateChange();
        }
    }

    public static Action OnStateChange;

    private void Update()
    {
        if (gameState == GameStates.kick)
        {
            StartCoroutine(Switch());

        }
        else
        {
            StartCoroutine(SwitchB());
        }
    }

    IEnumerator Switch()
    {
        yield return new WaitForSeconds(3f);
        _enemyGK.SetActive(true);
        _playerGK.SetActive(false);
    }
    IEnumerator SwitchB()
    {
        yield return new WaitForSeconds(3f);
        _enemyGK.SetActive(false);
        _playerGK.SetActive(true);
    }

}