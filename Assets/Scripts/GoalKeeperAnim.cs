using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _ball;

    private bool isSaved = false;
    void Update()
    {
            if (Vector3.Distance(transform.position, _ball.transform.position) < 13f && !isSaved)
            {
                isSaved = true;
                _animator.SetInteger("AnimIndex", Random.Range(1, 10));
            }
            else
            {
                _animator.SetInteger("AnimIndex", 0);

            }
        
    
    }
}