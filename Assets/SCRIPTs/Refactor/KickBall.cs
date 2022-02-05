using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    [SerializeField] private BGCurve[] _bGCurve;
    [SerializeField] private float _kickOffset = 0.35f;

    [SerializeField] private InputHandler _inputHandler;

    private BGCcTrs _trs;

    private void OnEnable()
    {
        GameState.OnStateChange += Kick;
    }

    private void OnDisable()
    {
        GameState.OnStateChange -= Kick;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {

            _trs.MoveObject = false;
            _trs.DistanceRatio = 0;
            _trs.Speed = 0;
        }
    }
    private void Kick(GameState.GameStates gameState)
    {
        if (gameState == GameState.GameStates.kick)
            return;


        int _curveIndex = _inputHandler.LastPressedBtnIndex - 1;

        if (gameState == GameState.GameStates.watch)
            _curveIndex = Random.Range(0, 5);

        _trs = _bGCurve[_curveIndex].GetComponent<BGCcTrs>();

        _trs.Speed = 0;
        StartCoroutine(KickCo(gameState));
    }
    private IEnumerator KickCo(GameState.GameStates gameState)
    {
        if (gameState == GameState.GameStates.watch)
            yield return new WaitForSeconds(2f);

        yield return new WaitForSeconds(_kickOffset);

        _trs.MoveObject = true;
        _trs.DistanceRatio = 0;
        _trs.Speed = 15;
    }
}
