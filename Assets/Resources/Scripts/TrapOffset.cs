using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapOffset : MonoBehaviour
{
    public float plusOffset = 0;
    public bool isManualOffset = false;
    private void Awake()
    {
        Animator trapAnimator = GetComponent<Animator>();
        if (!isManualOffset)
            trapAnimator.SetFloat("RandomOffset", Random.Range(0, 0.5f));
        else
            trapAnimator.SetFloat("RandomOffset", plusOffset);
    }
}
