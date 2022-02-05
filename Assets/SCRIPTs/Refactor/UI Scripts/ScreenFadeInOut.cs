using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenFadeInOut : MonoBehaviour
{
    [SerializeField] private Image _fade;

    private void OnEnable()
    {
        GameState.OnStateChange += Fade;
    }

    private void OnDisable()
    {
        GameState.OnStateChange -= Fade;
    }
    private void Fade(GameState.GameStates gameState)
    {
        if (gameState == GameState.GameStates.kick)
        {
            StartCoroutine(FadeCo());
        }
    }

    IEnumerator FadeCo()
    {
        yield return new WaitForSeconds(1f);

        _fade.gameObject.SetActive(true);
        _fade.DOFade(1,.7f);
        yield return new WaitForSeconds(1f);
        _fade.DOFade(0 ,1f);
        _fade.gameObject.SetActive(false);

    }
}
