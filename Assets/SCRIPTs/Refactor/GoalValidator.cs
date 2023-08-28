using System;
using UnityEngine;

public class GoalValidator : MonoBehaviour
{
    public static Action OnGoal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            OnGoal?.Invoke();
        }
    }
}
