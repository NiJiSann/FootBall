using System.Collections;
using UnityEngine;

public class VCamController : MonoBehaviour
{
    [SerializeField] private GameObject[] _vCams;

    private int _camIndex;

    private void OnEnable()
    {
        GameState.OnStateChange += SwitchCamToNext;
    }
    private void OnDisable()
    {
        GameState.OnStateChange -= SwitchCamToNext;

    }

    private void SwitchCamToNext(GameState.GameStates gameState)
    {
        StartCoroutine(SwitchCamToNextCo(gameState));
    }

    private IEnumerator SwitchCamToNextCo(GameState.GameStates gameState)
    {
        if (gameState != GameState.GameStates.watch)
            yield return new WaitForSeconds(1f);
        _camIndex++;
        int _indexMod = _camIndex % 3;

        for (int i = 0; i < _vCams.Length; i++)
            if (i != _indexMod)
                _vCams[i].SetActive(false);
            else
                _vCams[i].SetActive(true);
    }
}
