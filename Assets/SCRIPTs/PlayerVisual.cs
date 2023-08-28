using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.Experimental;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    [SerializeField] private GameObject _emyMesh;
    [SerializeField] private GameObject _emyBones;
    [SerializeField] private Avatar _emyAvatar;
    [SerializeField] private GameObject _amyMesh;
    [SerializeField] private GameObject _amyBones;
    [SerializeField] private Avatar _amyAvatar;

    [SerializeField] private bool _isPlayer = false;

    private void OnEnable()
    {
        GameState.OnStateChange += UpdateVisual;
    }

    private void OnDisable()
    {
        GameState.OnStateChange += UpdateVisual;
    }

    private void UpdateVisual(GameState.GameStates state)
    {
        if (state==GameState.GameStates.watch)
            return;
        
        StartCoroutine(UpdateVisualCo(2));
    }

    private IEnumerator UpdateVisualCo(int time)
    {
        yield return new WaitForSeconds(time);
        _amyBones.SetActive(true);
        _amyMesh.SetActive(true);
        _emyBones.SetActive(true);
        _emyMesh.SetActive(true);
        
        if (!_isPlayer)
        {
            _emyBones.SetActive(false);
            _emyMesh.SetActive(false);
            _animator.avatar = _amyAvatar;
            _isPlayer = true;
        }
        else
        {
            _isPlayer = false;
            _amyBones.SetActive(false);
            _amyMesh.SetActive(false);
            _animator.avatar = _emyAvatar;
        }
    }
    
    private void Start()
    {
        if (PlayerPrefs.GetString("character") == "Amy")
            _isPlayer = !_isPlayer;
        
        StartCoroutine(UpdateVisualCo(0));
    }

    public void SetVisual(string name)
    {
        _amyBones.SetActive(true);
        _amyMesh.SetActive(true);
        _emyBones.SetActive(true);
        _emyMesh.SetActive(true);
        
        switch (name)
        {
            case "Amy":
                _emyBones.SetActive(false);
                _emyMesh.SetActive(false);
                _animator.avatar = _amyAvatar;
                break;
            case "Emy":
                _amyBones.SetActive(false);
                _amyMesh.SetActive(false);
                _animator.avatar = _emyAvatar;
                break;
            default:
                _amyBones.SetActive(false);
                _amyMesh.SetActive(false);
                _animator.avatar = _emyAvatar;
                break;
        }
    }

}
