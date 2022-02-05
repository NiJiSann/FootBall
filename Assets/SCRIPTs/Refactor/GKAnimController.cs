using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKAnimController : MonoBehaviour
{
    [SerializeField] private Animator _gKAnimator;
    //this offset for anim 2,4,5,7,8
    [SerializeField] private float _inPlaceSaveTImeOffset = 1f;
    //this offset for anim 1,3
    [SerializeField] private float _moveSaveTImeOffset = 1f;

    [SerializeField] private InputHandler _inputHandler;

    private void OnEnable()
    {
        GameState.OnStateChange += Save;
    }

    private void OnDisable()
    {
        GameState.OnStateChange -= Save;
    }

    private void Save(GameState.GameStates gameState)
    {
        if (gameState == GameState.GameStates.kick)
            return;
        StartCoroutine(SaveCo(gameState));
    }

    IEnumerator SaveCo(GameState.GameStates gameState)
    {
        if (gameState == GameState.GameStates.watch)
            yield return new WaitForSeconds(1f);

        int _animRandomindex = UnityEngine.Random.Range(1, 9);

        if (gameState==GameState.GameStates.watch)
            _animRandomindex = _inputHandler.LastPressedBtnIndex;

        print(_animRandomindex);

        if (_animRandomindex == 6)
        {
            yield return new WaitForSeconds(_moveSaveTImeOffset);
            _gKAnimator.SetInteger("AnimIndex", _animRandomindex);
        }
        else if (_animRandomindex == 1 || _animRandomindex == 3)
        {
            yield return new WaitForSeconds(_moveSaveTImeOffset);
            _gKAnimator.SetInteger("AnimIndex", _animRandomindex);
        }
        else
        {
            _gKAnimator.SetInteger("AnimIndex", _animRandomindex);
        }
        yield return new WaitForSeconds(1);
        _gKAnimator.SetInteger("AnimIndex", 0);
    }
}
