
using BansheeGz.BGSpline.Curve;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using System;
using UnityEngine.UI;

public class BallKick : MonoBehaviour
{
    [SerializeField] private BGCurve[] bGCurve;
    [SerializeField] private Button saveRUp;
    [SerializeField] private Button saveRDown;
    [SerializeField] private Button saveCUp;
    [SerializeField] private Button saveCenter;
    [SerializeField] private Button saveLUp;
    [SerializeField] private Button saveLDown;
    private BGCcTrs _trs;
    private bool iskicked =false;
    int curveIndex = 0;
    private void Start()
    {
      
            saveRUp.onClick.AddListener(() =>       {SetIndex(0); OnKick(); });
            saveRDown.onClick.AddListener(() =>     {SetIndex(1); OnKick(); });
            saveCUp.onClick.AddListener(() =>       {SetIndex(2); OnKick(); });
            saveCenter.onClick.AddListener(() =>    {SetIndex(3); OnKick(); });
            saveLUp.onClick.AddListener(() =>       {SetIndex(4); OnKick(); });
            saveLDown.onClick.AddListener(() =>     {SetIndex(5); OnKick(); });
        
        _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
    }

    private void Update()
    {
        if (_trs.DistanceRatio>.9f)
        {
            _trs.DistanceRatio = 0;
            _trs.MoveObject = false;
           // curveIndex = UnityEngine.Random.Range(0, bGCurve.Length - 1);
            _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
        }

        if (GameState.GetState == GameState.GameStates.save && !iskicked)
        {
            iskicked = true;
            _trs.Speed = 0;
            _trs.DistanceRatio = 0;
            _trs.MoveObject = true;
            //curveIndex = UnityEngine.Random.Range(0, bGCurve.Length - 1);
            _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
        }
        if (GameState.GetState == GameState.GameStates.watch)
        {
            _trs.Speed = 0;
            _trs.DistanceRatio = 0;
            _trs.MoveObject = true;
            //curveIndex = UnityEngine.Random.Range(0, bGCurve.Length - 1);
            _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Player"))
        {
            _trs.Speed = 10;
        }
        if(collision.transform.CompareTag("Enemy"))
        {
            _trs.Speed = 0;
            _trs.DistanceRatio = 0;
            _trs.MoveObject = false;
        }
        if (collision.transform.CompareTag("Gate"))
        {
            OnGoal();
        }
    }
    void SetIndex(int i)
    {
        curveIndex = i;
    }
    public static Action OnKick;
    public static Action OnGoal;
}