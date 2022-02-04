using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _golClip;

    private void OnEnable()
    {
        BallKick.OnGoal += _golClip.Play;
    }
    private void OnDisable()
    {
        BallKick.OnGoal -= _golClip.Play;

    }
}
