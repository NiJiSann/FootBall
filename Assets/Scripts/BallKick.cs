
using BansheeGz.BGSpline.Curve;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class BallKick : MonoBehaviour
{
    [SerializeField] private BGCurve[] bGCurve;
    private BGCcTrs _trs;

    private void Awake()
    {
        int curveIndex = Random.Range(0, bGCurve.Length - 1);
        _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
    }
    private void Update()
    {
        if (_trs.DistanceRatio>.9f)
        {
            _trs.MoveObject = false;
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
            print("Coll");
            _trs.MoveObject = false;

        }
    }
}
