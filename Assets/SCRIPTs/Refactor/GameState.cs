using System;
using System.Collections;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum GameStates
    {
        kick,
        save,
        watch,
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
            int intEnum = (int)value;
            gameSt = (GameStates)(intEnum % 3);
            OnStateChange?.Invoke(gameSt);
            if (gameSt == GameStates.watch)
                StartCoroutine(AutoSwitchState());
        }
    }

    IEnumerator AutoSwitchState()
    {
        yield return new WaitForSeconds(5f);

        GameSt = GameStates.kick;
    }
}