using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersafe : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _ball;

    private bool isSaved = false;
    void Update()
    {
        if (Vector3.Distance(transform.position, _ball.transform.position) < 13f &&  !isSaved && GameState.GetState == GameState.GameStates.watch)
        {
            isSaved = true;
            switch (GoalkeeperInput.animIndex)
            {
                case GoalkeeperInput.SaveDir.saveRUp:
                    //make some anim to affset to right
                    _animator.SetInteger("AnimIndex", 3);
                    break;
                case GoalkeeperInput.SaveDir.saveRDown:
                    _animator.SetInteger("AnimIndex", 1);
                    break;
                case GoalkeeperInput.SaveDir.saveLUp:
                    //make some anim to affset to left
                    _animator.SetInteger("AnimIndex", 3);
                    break;
                case GoalkeeperInput.SaveDir.saveLDown:
                    _animator.SetInteger("AnimIndex", 5);
                    break;
                case GoalkeeperInput.SaveDir.saveCenter:
                    _animator.SetInteger("AnimIndex", 2);
                    break;
                case GoalkeeperInput.SaveDir.saveCUp:
                    _animator.SetInteger("AnimIndex", 3);
                    break;
                default:
                    break;
            }
         
        }
    }
}
