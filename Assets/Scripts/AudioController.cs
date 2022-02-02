using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _golClip;
    [SerializeField] private AudioSource _btnClip;

    private void OnEnable()
    {
        BallKick.OnKick += _btnClip.Play;
        BallKick.OnGoal += _golClip.Play;
    }
    private void OnDisable()
    {
        BallKick.OnKick -= _btnClip.Play;
        BallKick.OnGoal -= _golClip.Play;

    }
}
