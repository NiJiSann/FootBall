using System.Collections;
using System.Collections.Generic;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    [SerializeField] private BGCurve[] bGCurve;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private float _kickOffset = 0.35f;

    private BGCcTrs _trs;

    private void OnEnable()
    {
        InputHandler.OnKick += Kick;
    }

    private void OnDisable()
    {
        InputHandler.OnKick -= Kick;

    }

    private void Kick()
    {
        _trs = bGCurve[_inputHandler.LastPressedBtnIndex-1].GetComponent<BGCcTrs>();
        _trs.Speed = 0;
        StartCoroutine(KickCo());
    }
    private IEnumerator KickCo()
    {
        yield return new WaitForSeconds(_kickOffset);

        _trs.DistanceRatio = 0;
        _trs.Speed = 15;
        //_trs.MoveObject = true;
    }
}
