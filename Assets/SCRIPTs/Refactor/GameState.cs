using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum GameStates
    {
        kick,
        save,
        watch
    }
    public static Action<GameStates> OnStateChange;
    private GameStates gameSt;

    public GameStates GameSt
    {
        get
        {
            return gameSt;
        }
        set
        {
            //Debug.Log(value);
            int intEnum = (int)value;
            gameSt = (GameStates)(intEnum%3);
            OnStateChange?.Invoke(gameSt);
            if (gameSt == GameStates.watch)
                StartCoroutine(AutoSwitchState());
        }
    }

    IEnumerator AutoSwitchState()
    {
        print("auto switch start");
        yield return new WaitForSeconds(5f);
        print("auto switch end");

        GameSt = GameStates.kick;
    }
}