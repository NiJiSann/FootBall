using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _speed =10f;
    [SerializeField] private Animator animator; 
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) )
        {
            transform.Rotate(new Vector3(0,-1,0)*Time.deltaTime* _speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * _speed);
        }
    }
}
