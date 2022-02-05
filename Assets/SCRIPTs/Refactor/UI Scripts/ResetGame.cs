using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    [SerializeField] private GameObject[] _endScreens;
    [SerializeField] private Button[] _resetButtons;

    private void Start()
    {
        foreach (var btn in _resetButtons)
        {
            btn.onClick.AddListener(RstGame);
        }
    }

    private void RstGame()
    {
        foreach (var screen in _endScreens)
        {
            screen.SetActive(false);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
