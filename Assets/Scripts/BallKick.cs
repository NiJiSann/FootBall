
using BansheeGz.BGSpline.Curve;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using System;
using UnityEngine.UI;
using System.Collections;

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
    private bool _player;
    private bool _gate;
    private bool _enemy;

    public static bool isChecked;
    int curveIndex = 0;
    private void Start()
    {
      
            saveRUp.onClick.AddListener(() =>       {SetIndex(0); OnKick(); DisableBtn(); });
            saveRDown.onClick.AddListener(() =>     {SetIndex(1); OnKick(); DisableBtn(); });
            saveCUp.onClick.AddListener(() =>       {SetIndex(2); OnKick(); DisableBtn(); });
            saveCenter.onClick.AddListener(() =>    {SetIndex(3); OnKick(); DisableBtn(); });
            saveLUp.onClick.AddListener(() =>       {SetIndex(4); OnKick(); DisableBtn(); });
            saveLDown.onClick.AddListener(() =>     {SetIndex(5); OnKick(); DisableBtn(); });
        
        _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
        _trs.Speed = 0;
    }

    private void Update()
    {
        if (GameState.GetState == GameState.GameStates.save && !iskicked)
        {
            iskicked = true;
            _trs.Speed = 0;
            _trs.DistanceRatio = 0;
            _trs.MoveObject = true;
            //curveIndex = UnityEngine.Random.Range(0, bGCurve.Length - 1);
            //   _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
        }
        return;

        if (_trs.DistanceRatio > .9f)
        {
            _trs.DistanceRatio = 0;
            _trs.MoveObject = false;
           // curveIndex = UnityEngine.Random.Range(0, bGCurve.Length - 1);
       //     _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
        }

        
        if (GameState.GetState == GameState.GameStates.watch)
        {
            _trs.Speed = 0;
            _trs.DistanceRatio = 0;
            _trs.MoveObject = true;
            //curveIndex = UnityEngine.Random.Range(0, bGCurve.Length - 1);
           // _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
        }

    }

    private void DisableBtn()
    {
        saveRUp.gameObject.SetActive(false);
        saveRDown.gameObject.SetActive(false);
        saveCUp.gameObject.SetActive(false);
        saveCenter.gameObject.SetActive(false);
        saveLUp.gameObject.SetActive(false);
        saveLDown.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.tag);
        if (collision.transform.CompareTag("Player") && !_player)
        {
            _player = true;
            _gate = _enemy = false;
            
            _trs.Speed = 15;
            _trs.DistanceRatio = 0;
        }
        if(collision.transform.CompareTag("Enemy") && !_enemy)
        {
            _player = _gate = false;
            _enemy = true;
            _trs.Speed = 0;
            _trs.DistanceRatio = 0;
            _trs.MoveObject = false;
            iskicked = false;
        }
        if (collision.transform.CompareTag("Gate") && !_gate)
        {
            _player = _enemy = false;
            _gate = true;
            iskicked = false;
            if (!isChecked)
             OnGoal();
            isChecked = true;
            StartCoroutine(Co());


        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            if (!isChecked)
                OnFail();
            isChecked = true;
            StartCoroutine(Co());
        }
    }
    void SetIndex(int i)
    {
        curveIndex = i;
        _trs = bGCurve[curveIndex].GetComponent<BGCcTrs>();
    }

    IEnumerator Co()
    {
        yield return new WaitForSeconds(1f);
        isChecked = false;
    }

    public static Action OnKick;
    public static Action OnGoal;
    public static Action OnFail;
}