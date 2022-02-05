using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private BtnData[] _btns;

    [SerializeField] private Image _attackImg;
    [SerializeField] private Image _defenseImg;

    [SerializeField] private GameObject _btnHolder;

    [SerializeField] private Transform _defensePos;
    [SerializeField] private Transform _attackPos;

    [SerializeField] private bool isAttackState;

    [SerializeField] private GameState _gameState;

    private int _lastPressedBtnIndex;

    public static Action OnKick;

    public int LastPressedBtnIndex { get => _lastPressedBtnIndex; set => _lastPressedBtnIndex = value; }

    private void OnEnable()
    {
        GameState.OnStateChange += SetButtons;
    }

    private void OnDisable()
    {
        GameState.OnStateChange -= SetButtons;
    }

    void Start()
    {
        for (int i = 0; i < _btns.Length; i++)
        {
            int t = i;
            _btns[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                LastPressedBtnIndex = _btns[t].BtnIndex;
                int temp = (int)_gameState.GameSt;
                temp++;
                _gameState.GameSt = (GameState.GameStates)temp;

                OnKick?.Invoke();
            });
        }
    }

    private void SetButtons(GameState.GameStates gameState)
    {
        if (gameState == GameState.GameStates.kick)
        {
            StartCoroutine(SetAttackBtnsWithOffsetCo());
        }
        else if (gameState == GameState.GameStates.save)
        {
            _btnHolder.transform.eulerAngles = new Vector3(0, 180, 0);
            _btnHolder.transform.position = _defensePos.position;

            for (int i = 0; i < _btns.Length; i++)
                _btns[i].SetSprite(_defenseImg.sprite);
        }
        else
        {
            foreach (var btn in _btns)
            {
                btn.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator SetAttackBtnsWithOffsetCo()
    {
        yield return new WaitForSeconds(2f);
        foreach (var btn in _btns)
        {
            btn.gameObject.SetActive(true);
        }
        _btnHolder.transform.eulerAngles = Vector3.zero;
        _btnHolder.transform.position = _attackPos.position;

        for (int i = 0; i < _btns.Length; i++)
            _btns[i].SetSprite(_attackImg.sprite);
    }
}
