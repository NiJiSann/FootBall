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

    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _opponentName;
    
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

    private void Start()
    {
        switch (PlayerPrefs.GetString("character"))
        {
            case "Amy":
                _playerName.text = "Amy";
                _opponentName.text = "Emy";
                break;
            default:
                _playerName.text = "Emy";
                _opponentName.text = "Amy";
                break;
        }

    }

    private void UpdateSscore()
    {
        if (_gameState.GameSt == GameState.GameStates.save)
        {
            _egyAttempts[_egyAttempt-1].sprite = _goalImg.sprite;
            _egyScore++;
            _egyScoreText.text = _egyScore.ToString();
            _egyAttempts[_egyAttempt-1].color = Color.white;

        }
        else if (_gameState.GameSt == GameState.GameStates.watch)
        {
            _cmrAttempts[_cmrAttempt-1].sprite = _goalImg.sprite;
            _cmrScore++;
            _cmrScoreText.text = _cmrScore.ToString();
            _cmrAttempts[_cmrAttempt-1].color = Color.white;
        }
        
        _winCheck.Check(_egyScore, _cmrScore, _egyAttempt, _cmrAttempt);
    }

    private void UpdateAttempt(GameState.GameStates gameStates)
    {
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
            images[index].color = Color.red;
        }
    }
}
