using System.Collections;
using UnityEngine;

public class GKAnimController : MonoBehaviour
{
    [SerializeField] private Animator _gKAnimator;
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

        int _animRandomindex = Random.Range(1, 9);

        if (gameState == GameState.GameStates.watch)
            _animRandomindex = InverseSide(_inputHandler.LastPressedBtnIndex);
        if (_animRandomindex == 6)
        {
            yield return new WaitForSeconds(.7f);
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
            if (gameState == GameState.GameStates.watch)
                yield return new WaitForSeconds(1f);
            _gKAnimator.SetInteger("AnimIndex", _animRandomindex);
        }
        yield return new WaitForSeconds(1);
        _gKAnimator.SetInteger("AnimIndex", 0);
    }

    private int InverseSide(int index)
    {
        return index switch
        {
            1 => 3,
            3 => 1,
            4 => 7,
            6 => 4,
            5 => 6,
            _ => index,
        };
    }
}
