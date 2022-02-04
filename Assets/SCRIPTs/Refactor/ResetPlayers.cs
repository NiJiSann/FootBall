using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayers : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerEnem;
    [SerializeField] private GameObject _playerGK;
    [SerializeField] private GameObject _GK;

    private Vector3 _ballInitPos;
    private Vector3 _playerInitPos;
    private Vector3 _playerEnemInitPos;
    private Vector3 _playerGKInitPos;
    private Vector3 _GKInitPos;

    private void OnEnable()
    {
        InputHandler.OnKick += ResetPlayer;
    }

    private void OnDisable()
    {
        InputHandler.OnKick -= ResetPlayer;
    }

    void Start()
    {
        _ballInitPos         = _ball.transform.position;
        _playerInitPos       = _player.transform.position;
        _playerEnemInitPos   = _playerEnem.transform.position;
        _playerGKInitPos     = _playerGK.transform.position;
        _GKInitPos           = _GK.transform.position;
    }

    private void ResetPlayer()
    {
        StartCoroutine(ResetPlayersCo());
    }

    IEnumerator ResetPlayersCo()
    {
        print("Reset after 2sec");
        yield return new WaitForSeconds(2f);
        print("Reset");

        //resetPos
        _ball.transform.position = _ballInitPos;
        _player.transform.position = _playerInitPos;
        _playerEnem.transform.position = _playerEnemInitPos;
        _playerGK.transform.position = _playerGKInitPos;
        _GK.transform.position = _GKInitPos;

        //resetRot
        _playerGK.transform.eulerAngles = new Vector3(0, 180, 0);
        _GK.transform.eulerAngles = new Vector3(0, 180, 0);
        _player.transform.eulerAngles = new Vector3(0, 0, 0);
        _playerEnem.transform.eulerAngles = new Vector3(0, 0, 0);

        _ball.GetComponent<Rigidbody>().isKinematic = true;
        _ball.GetComponent<Rigidbody>().isKinematic = false;
    }
}
