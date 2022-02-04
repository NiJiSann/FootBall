using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _ball;

    private bool isSaved = false;
    float _latestDIst;

    private void Start()
    {
        _animator.SetInteger("AnimIndex", 0);
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, _ball.transform.position);
        if (dist > 10 && dist < 13f && !isSaved)
        {
            print("ee");
            isSaved = true;
            _animator.SetInteger("AnimIndex", Random.Range(1, 10));
            StartCoroutine(Co());
        }
    }

    IEnumerator Co()
    {
        yield return new WaitForSeconds(2f);
        isSaved = false;
    }
}