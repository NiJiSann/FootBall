using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] private Image[] _egyAttempts;
    [SerializeField] private Image[] _cmrAttempts;
    [SerializeField] private Image _goalImg;
    [SerializeField] private Image _missImg;
    [SerializeField] private TMP_Text _egyScoreText;
    [SerializeField] private TMP_Text _cmrScoreText;

    [SerializeField] private GameState _gameState;
    [SerializeField] private WinCheck _winCheck;

    private int _egyScore;
    private int _cmrScore;

    private int _egyAttempt;
    private int _cmrAttempt;

    private void OnEnable()
    {
        GoalValidator.OnGoal += UpdateSscore;
        GameState.OnStateChange += UpdateAttempt;
    }

    private void OnDisable()
    {
        GoalValidator.OnGoal -= UpdateSscore;
        GameState.OnStateChange += UpdateAttempt;

    }

    private void UpdateSscore()
    {
        if (_gameState.GameSt == GameState.GameStates.save)
        {
            _egyAttempts[_egyAttempt-1].sprite = _goalImg.sprite;
            _egyScore++;
            _egyScoreText.text = _egyScore.ToString();
        }
        else if (_gameState.GameSt == GameState.GameStates.watch)
        {
            _cmrAttempts[_cmrAttempt-1].sprite = _goalImg.sprite;
            _cmrScore++;
            _cmrScoreText.text = _cmrScore.ToString();
        }
    }

    private void UpdateAttempt(GameState.GameStates gameStates)
    {
        _winCheck.Check(_egyScore, _cmrScore, _egyAttempt, _cmrAttempt);

        if (_gameState.GameSt == GameState.GameStates.save)
        {
            StartCoroutine(SetMissSprite(_egyAttempts, _egyAttempt));
            _egyAttempt++;
        }
        else if (_gameState.GameSt == GameState.GameStates.watch)
        {
            StartCoroutine(SetMissSprite(_cmrAttempts, _cmrAttempt));
            _cmrAttempt++;
        }

    }

    IEnumerator SetMissSprite(Image[] images, int index)
    {
        yield return new WaitForSeconds(2f);
        if (_gameState.GameSt == GameState.GameStates.watch)
            yield return new WaitForSeconds(2f);
        if (images[index].sprite != _goalImg.sprite)
        {
            images[index].sprite = _missImg.sprite;
        }
    }
}
