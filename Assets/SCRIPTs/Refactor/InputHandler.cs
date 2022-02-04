using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private Button RUBtn;
    [SerializeField] private Button RDBtn;
    [SerializeField] private Button CUBtn;
    [SerializeField] private Button CCBtn;
    [SerializeField] private Button LUBtn;
    [SerializeField] private Button LDBtn;

    //[SerializeField] private 

    private int _lastPressedBtnIndex;

    void Start()
    {
        RUBtn.onClick.AddListener(() => {_lastPressedBtnIndex = 3; print(_lastPressedBtnIndex); });
        RDBtn.onClick.AddListener(() => {_lastPressedBtnIndex = 6; print(_lastPressedBtnIndex); });
        CUBtn.onClick.AddListener(() => {_lastPressedBtnIndex = 2; print(_lastPressedBtnIndex); });
        CCBtn.onClick.AddListener(() => {_lastPressedBtnIndex = 5; print(_lastPressedBtnIndex); });
        LUBtn.onClick.AddListener(() => {_lastPressedBtnIndex = 1; print(_lastPressedBtnIndex); });
        LDBtn.onClick.AddListener(() => {_lastPressedBtnIndex = 4; print(_lastPressedBtnIndex); });
    }
}
