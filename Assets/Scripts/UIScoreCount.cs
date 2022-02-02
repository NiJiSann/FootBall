using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScoreCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _egptScore;
    [SerializeField] private TMP_Text _camerooonScore;

    private int _egpScore = 0 ;
    private int _camerScore = 0;

    private void OnEnable()
    {
        BallKick.OnGoal += UpdateScore;
    }

    private void OnDisable()
    {
        BallKick.OnGoal -= UpdateScore;
    }

    private void UpdateScore()
    {
        if (GameState.GetState == GameState.GameStates.save)
        {
            _camerScore++;
            _camerooonScore.text = _camerScore.ToString();
        }
        else if (GameState.GetState == GameState.GameStates.kick)
        {
            _egpScore++;
            _egptScore.text = _camerScore.ToString();
        }
    }
}
