using System.Collections;
using UnityEngine;

public class KickAnimController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private void OnEnable()
    {
        GameState.OnStateChange += StartKickAnim;
    }

    private void OnDisable()
    {
        GameState.OnStateChange -= StartKickAnim;
    }

    private void StartKickAnim(GameState.GameStates gameState)
    {
        if (gameState == GameState.GameStates.kick)
            return;
        StartCoroutine(StartKickAnimCo(gameState));
    }

    IEnumerator StartKickAnimCo(GameState.GameStates gameState)
    {
        if (gameState == GameState.GameStates.watch)
            yield return new WaitForSeconds(2f);

        _playerAnimator.SetTrigger("Kick");

    }
}