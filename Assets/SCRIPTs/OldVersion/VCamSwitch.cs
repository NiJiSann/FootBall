using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _startVCam;
    [SerializeField] private GameObject _goalkeeperVCam;
    [SerializeField] private GameObject _watchVCam;

    [SerializeField] private GameObject[] buttonsDef;
    [SerializeField] private GameObject[] buttonsAtck;

    [SerializeField] private GameObject _tut_2;

    private bool isSave = true;
    private bool isWatch = true;
    private static bool tutPass = false;

    void Start()
    {
        _goalkeeperVCam.SetActive(false);
        _watchVCam.SetActive(false);

        foreach (var btn in buttonsDef)
        {
            btn.SetActive(false);
        }
    }


    private void OnEnable()
    {
        GameState.OnStateChange += F;      
    }

    private void OnDisable()
    {
        GameState.OnStateChange -= F;
    }

    private void F()
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
        foreach (var btn in buttonsDef)
        {
            btn.SetActive(false);
        }
        foreach (var btn in buttonsAtck)
        {
            btn.SetActive(false);
        }
        yield return new WaitForSeconds(3f);
        if (!tutPass)
        {
            _tut_2.SetActive(true);
            tutPass = true;
        }

        _goalkeeperVCam.SetActive(true);
        _startVCam.SetActive(false);

        yield return new WaitForSeconds(2f);

        foreach (var btn in buttonsDef)
        {
            btn.SetActive(true);
        }
  

    }

    IEnumerator SwitchToWvCam()
    {
        isWatch = false;
        isSave = true;

        foreach (var btn in buttonsDef)
        {
            btn.SetActive(false);
        }
        foreach (var btn in buttonsAtck)
        {
            btn.SetActive(false);
        }
        yield return new WaitForSeconds(3f);
        _watchVCam.SetActive(true);
        _goalkeeperVCam.SetActive(false);
        _startVCam.SetActive(false);

        yield return new WaitForSeconds(2f);

        foreach (var btn in buttonsAtck)
        {
            btn.SetActive(true);
        }

    }
}
