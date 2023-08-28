using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private RectTransform _fade;
    private void Awake()
    {
        _fade.DOAnchorPos(new Vector2(3000, 0), 1f);
    }

    public void StartTransition(string name)
    {
            StartCoroutine(TransitionCo(name));
    }
    
    private IEnumerator TransitionCo(string name)
    {
        _fade.anchoredPosition = new Vector2(-3000,0);
        _fade.DOAnchorPos(new Vector2(0, 0), 1f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
    }

}
