using System.Collections;
using UnityEngine;

public class SwapPlayers : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerEnem;
    [SerializeField] private GameObject _playerGK;
    [SerializeField] private GameObject _gK;

    private Vector3 _ballInitPos;
    private Vector3 _playerInitPos;
    private Vector3 _playerEnemInitPos;
    private Vector3 _playerGKInitPos;
    private Vector3 _GKInitPos;

    private void OnEnable()
    {
        GameState.OnStateChange += Swap;
    }

    private void OnDisable()
    {
        GameState.OnStateChange -= Swap;
    }

    void Start()
    {
        _ballInitPos = _ball.transform.position;
        _playerInitPos = _player.transform.position;
        _playerEnemInitPos = _playerEnem.transform.position;
        _playerGKInitPos = _playerGK.transform.position;
        _GKInitPos = _gK.transform.position;
    }

    private void Swap(GameState.GameStates gameState)
    {
        StartCoroutine(SwapCo(gameState));
    }

    private void ResetPlayer()
    {
        //resetPos
        _ball.transform.position = _ballInitPos;
        _player.transform.position = _playerInitPos;
        _playerEnem.transform.position = _playerEnemInitPos;
        _playerGK.transform.position = _playerGKInitPos;
        _gK.transform.position = _GKInitPos;

        //resetRot
        _playerGK.transform.eulerAngles = new Vector3(0, 180, 0);
        _gK.transform.eulerAngles = new Vector3(0, 180, 0);
        _player.transform.eulerAngles = new Vector3(0, 0, 0);
        _playerEnem.transform.eulerAngles = new Vector3(0, 0, 0);

        _ball.GetComponent<Rigidbody>().isKinematic = true;
        _ball.GetComponent<Rigidbody>().isKinematic = false;
    }

    IEnumerator SwapCo(GameState.GameStates gameState)
    {
        yield return new WaitForSeconds(2f);
        if (gameState == GameState.GameStates.kick)
        {
            _player.SetActive(true);
            _playerGK.SetActive(false);
            _playerEnem.SetActive(false);
            _gK.SetActive(true);
            ResetPlayer();
        }
        else if (gameState == GameState.GameStates.save)
        {
            _player.SetActive(false);
            _playerGK.SetActive(true);
            _playerEnem.SetActive(true);
            _gK.SetActive(false);
            ResetPlayer();

        }
    }
}
