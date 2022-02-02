using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerEnem;
    [SerializeField] private GameObject _playerGK;
    [SerializeField] private GameObject _GK;
    [SerializeField] private Vector3 _ballinitPos;
    [SerializeField] private Vector3 _playerInitPos;
    [SerializeField] private Vector3 _GKInitPos;

    private void OnEnable()
    {
        GameState.OnStateChange += ResetPPos;
    }
    private void OnDisable()
    {
        GameState.OnStateChange -= ResetPPos;
    }

    private void ResetPPos()
    {
        StartCoroutine(Co());
    }
    IEnumerator Co()
    {
        yield return new  WaitForSeconds(3.9f);
        _ball.transform.localPosition = _ballinitPos;
        _ball.GetComponent<Rigidbody>().isKinematic = true;
        _ball.GetComponent<Rigidbody>().isKinematic = false;

        _playerGK.transform.localPosition = _GKInitPos;
        _GK.transform.localPosition = _GKInitPos;
        _player.transform.localPosition = _playerInitPos;
        _playerEnem.transform.localPosition = _playerInitPos;
        _player.transform.rotation = Quaternion.identity;
        //_playerGK.transform.rotation = Quaternion.identity;
        //_GK.transform.rotation = Quaternion.identity;
    }
}
