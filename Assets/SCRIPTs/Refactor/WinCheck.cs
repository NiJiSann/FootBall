using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    [SerializeField] private GameObject _holder;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _score;

    private void SetResults(string  title, string score)
    {
        _holder.SetActive(true);
        _title.text = title;
        _score.text = score;
    }

    private IEnumerator SetResCo(string  title, string score)
    {
        yield return new WaitForSeconds(1f);
        SetResults(title, score);
    }

    public void Check(int egyScore, int cmrScore, int egyAttempt, int cmrAttempt)
    {
        if (egyAttempt == 4 && cmrAttempt == 4)
        {
            if (egyScore > cmrScore)
                StartCoroutine(SetResCo("You Win!", $"{egyScore}:{cmrScore}"));
            else if (egyScore == cmrScore)
                StartCoroutine(SetResCo("Friendship Wins!", $"{egyScore}:{cmrScore}"));
            else
                StartCoroutine(SetResCo("You Lose!", $"{egyScore}:{cmrScore}"));
        }
    }
}
