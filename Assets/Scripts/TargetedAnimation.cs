using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Targeted(bool value)
    {
        animator.SetBool("Targeted", value);
    }
}
