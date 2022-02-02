using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject _leftLeg;
    [SerializeField] private GameObject _rightLeg;

    private bool iskicked;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("isRunning", false);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("isRunningBack", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("isRunningBack", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameState.GetState==GameState.GameStates.kick)
        {
            _leftLeg.tag = "Player";
            _rightLeg.tag = "Player";
            animator.SetTrigger("Kick");
            //Update GameState
            StartCoroutine(SwitchGameState());
        }

        if (GameState.GetState == GameState.GameStates.watch && !iskicked)
        {
            iskicked = true;
            _leftLeg.tag = "Player";
            _rightLeg.tag = "Player";
            animator.SetTrigger("Kick");
            //Update GameState
            StartCoroutine(SwitchGameStateB());
        }

        IEnumerator SwitchGameState()
        {
            yield return new WaitForSeconds(2f);
            GameState.GetState = GameState.GameStates.save;

        }
        IEnumerator SwitchGameStateB()
        {
            yield return new WaitForSeconds(2f);
            GameState.GetState = GameState.GameStates.kick;

        }
    }
}
