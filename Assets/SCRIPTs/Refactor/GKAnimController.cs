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

    private void OnEnable()
    {
        InputHandler.OnKick += Save;
    }

    private void OnDisable()
    {
        InputHandler.OnKick -= Save;
    }

    private void Save()
    {
        StartCoroutine(SaveCo());
    }

    IEnumerator SaveCo()
    {
        int AnimRandomindex = UnityEngine.Random.RandomRange(1, 9);

        if (AnimRandomindex == 6)
        {
            yield return new WaitForSeconds(_moveSaveTImeOffset);
            _gKAnimator.SetInteger("AnimIndex", AnimRandomindex);
        }
        else if (AnimRandomindex == 1 || AnimRandomindex == 3)
        {
            yield return new WaitForSeconds(_moveSaveTImeOffset);
            _gKAnimator.SetInteger("AnimIndex", AnimRandomindex);
        }
        else
        {
            _gKAnimator.SetInteger("AnimIndex", AnimRandomindex);
        }
        yield return new WaitForSeconds(1);
        _gKAnimator.SetInteger("AnimIndex", 0);
    }
}
