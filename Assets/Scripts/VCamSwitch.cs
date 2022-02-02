using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _startVCam;
    [SerializeField] private GameObject _goalkeeperVCam;
    [SerializeField] private GameObject _watchVCam;

    [SerializeField] private GameObject[] buttons;

    private bool isSave = true;
    private bool isWatch = true;

    void Start()
    {
        _goalkeeperVCam.SetActive(false);
        _watchVCam.SetActive(false);

        foreach (var btn in buttons)
        {
            btn.SetActive(false);
        }
    }

    void Update()
    {
        if (GameState.GetState == GameState.GameStates.save && isSave)
            StartCoroutine(SwitchToGKvCam());
        else if (GameState.GetState == GameState.GameStates.watch && isWatch)
            StartCoroutine(SwitchToWvCam());
    }

    IEnumerator SwitchToGKvCam() 
    {
        isSave = false;
        isWatch = true;
        yield return new WaitForSeconds(3f);
        foreach (var btn in buttons)
        {
            btn.SetActive(true);
        }
        _goalkeeperVCam.SetActive(true);
        _startVCam.SetActive(false);

    }

    IEnumerator SwitchToWvCam()
    {
        isWatch = false;
        isSave = true;

        foreach (var btn in buttons)
        {
            btn.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        _watchVCam.SetActive(true);
        _goalkeeperVCam.SetActive(false);
        _startVCam.SetActive(false);

    }
}
