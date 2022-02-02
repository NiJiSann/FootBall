
using BansheeGz.BGSpline.Curve;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class BallKick : MonoBehaviour
{
    [SerializeField] private BGCurve[] bGCurve;
    private BGCcTrs _trs;
    private bool iskicked =false;
    private void Awake()
    {
        int curveIndex = Random.Range(0, bGCurve.Length - 1);
        _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
    }
    private void Update()
    {
        if (_trs.DistanceRatio>.9f)
        {
            _trs.DistanceRatio = 0;
            _trs.MoveObject = false;
        }

        if (GameState.GetState == GameState.GameStates.save && !iskicked)
        {
            iskicked = true;
            _trs.Speed = 0;
            _trs.MoveObject = true;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Player"))
        {
            _trs.Speed = 15;
        }
        if(collision.transform.CompareTag("Enemy"))
        {
            _trs.MoveObject = false;
        }
    }
}