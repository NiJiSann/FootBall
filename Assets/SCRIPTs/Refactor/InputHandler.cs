using System;
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

    [SerializeField]private bool isAttackState;

    private int _lastPressedBtnIndex;

    public static Action OnKick;

    public int LastPressedBtnIndex { get => _lastPressedBtnIndex; set => _lastPressedBtnIndex = value; }

    void Start()
    {
        for (int i = 0; i < _btns.Length; i++)
        {
            int t = i;
            _btns[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                LastPressedBtnIndex = _btns[t].BtnIndex;
                OnKick();
            });
        }

        SetButtons(isAttackState);
    }

    private void SetButtons(bool _isAttackState)
    {
        if (!_isAttackState)
        {
            _btnHolder.transform.eulerAngles = Vector3.zero;
            _btnHolder.transform.position = _attackPos.position;

            for (int i = 0; i < _btns.Length; i++)
                _btns[i].SetSprite(_attackImg.sprite);
        }
        else
        {
            _btnHolder.transform.eulerAngles = new Vector3(0, 180, 0);
            _btnHolder.transform.position = _defensePos.position;

            for (int i = 0; i < _btns.Length; i++)
                _btns[i].SetSprite(_defenseImg.sprite);
        }
    }


}
