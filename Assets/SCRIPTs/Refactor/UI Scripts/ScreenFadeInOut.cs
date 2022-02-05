using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (gameState==GameState.GameStates.kick)
        {
            StartCoroutine(FadeCo());    
        }
    }

    IEnumerator FadeCo()
    {
        yield return new WaitForSeconds(1f);

        _fade.gameObject.SetActive(true);
        for (float i = 0; i < 270; i+=5)
        {
            _fade.color = new Color(_fade.color.r, _fade.color.g, _fade.color.b, i/255);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(.5f);
        for (float i = 270; i > 0; i-=5)
        {
            _fade.color = new Color(_fade.color.r, _fade.color.g, _fade.color.b, i/255);
            yield return new WaitForSeconds(0.01f);
        }
        _fade.gameObject.SetActive(false);

    }
}
