using System.Collections;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _gK;

    private Vector3 _ballInitPos;
    private Vector3 _playerInitPos;
    private Vector3 _GKInitPos;

    private void OnEnable()
    {
        GameState.OnStateChange += RePos;
    }

    private void OnDisable()
    {
        GameState.OnStateChange -= RePos;
    }

    private void RePos(GameState.GameStates obj)
    {
        StartCoroutine(RePosCo());
    }

    void Start()
    {
        _ballInitPos = _ball.transform.position;
        _playerInitPos = _player.transform.position;
        _GKInitPos = _gK.transform.position;
    }

    private void ResetPlayer()
    {
        //resetPos
        _ball.transform.position = _ballInitPos;
        _player.transform.position = _playerInitPos;
        _gK.transform.position = _GKInitPos;

        //resetRot
        _gK.transform.eulerAngles = new Vector3(0, 180, 0);
        _player.transform.eulerAngles = new Vector3(0, 0, 0);

        _ball.GetComponent<Rigidbody>().isKinematic = true;
        _ball.GetComponent<Rigidbody>().isKinematic = false;
    }

    private IEnumerator RePosCo()
    {
        yield return new WaitForSeconds(2f);
        ResetPlayer();
    }

    // private void Swap(GameState.GameStates gameState)
    // {
    //     StartCoroutine(SwapCo(gameState));
    // }
    
    // IEnumerator SwapCo(GameState.GameStates gameState)
    // {
    //     yield return new WaitForSeconds(2f);
    //     if (gameState == GameState.GameStates.kick)
    //     {
    //         _player.SetActive(true);
    //         _playerGK.SetActive(false);
    //         _playerEnem.SetActive(false);
    //         _gK.SetActive(true);
    //         ResetPlayer();
    //     }
    //     else if (gameState == GameState.GameStates.save)
    //     {
    //         _player.SetActive(false);
    //         _playerGK.SetActive(true);
    //         _playerEnem.SetActive(true);
    //         _gK.SetActive(false);
    //         ResetPlayer();
    //
    //     }
    // }
}