using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAnimController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private void OnEnable()
    {
        InputHandler.OnKick += StartKickAnim;
    }
    private void OnDisable()
    {
        InputHandler.OnKick -= StartKickAnim;
    }

    private void StartKickAnim()
    {
        _playerAnimator.SetTrigger("Kick"); 
    }
}
