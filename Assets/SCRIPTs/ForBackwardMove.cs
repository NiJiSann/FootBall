using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ForBackwardMove : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalMove((transform.up + transform.up.normalized/4), 1f).SetLoops(-1, LoopType.Yoyo);
    }


}
