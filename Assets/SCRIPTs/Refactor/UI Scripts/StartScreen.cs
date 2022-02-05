using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private Button _playBtn;

    void Start()
    {
        _playBtn.onClick.AddListener(()=>_startScreen.SetActive(false));
    }
}
