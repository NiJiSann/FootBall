using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScoreCount : MonoBehaviour
{
    [SerializeField] private Image[] _egyptAtt;
    [SerializeField] private Image[] _camerAtt;
    [SerializeField] private Image _fail;
    [SerializeField] private Image _win;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private Button _play;

    [SerializeField] private Button _rest;
    [SerializeField] private BallKick _ballKick;

    private int _egpScore = 0;
    private int _camerScore = 0;

    private void OnEnable()
    {
        BallKick.OnGoal += UpdateScore;
        BallKick.OnFail += Fail;
    }



    private void OnDisable()
    {
        BallKick.OnGoal -= UpdateScore;
        BallKick.OnFail -= Fail;
    }

    private void Start()
    {
        _rest.onClick.AddListener(() => SceneManager.LoadScene(0));
        _play.onClick.AddListener(() => _startScreen.SetActive(false));
    }

    private void Update()
    {
        if (_egpScore == 3)
        {
            _winScreen.SetActive(true);
            _rest.gameObject.SetActive(true);
        }
        if (_camerScore == 3)
        {
            _loseScreen.SetActive(true);
            _rest.gameObject.SetActive(true);

        }

    }

    private void Fail()
    {
        if (GameState.GetState == GameState.GameStates.watch)
        {
            _camerAtt[_camerScore].sprite = _fail.sprite;
            _camerScore++;
        }
        else
        {
            _egyptAtt[_egpScore].sprite = _fail.sprite;
            _egpScore++;
        }
    }

    private void UpdateScore()
    {

        if (!_ballKick.IsKickPlayer)
        {
            _camerAtt[_camerScore].sprite = _win.sprite;
            _camerScore++;
        }
        else
        {
            _egyptAtt[_egpScore].sprite = _win.sprite;
            _egpScore++;
        }
    }
}
