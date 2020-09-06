using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    public Animator transitionAnimator;

    private void Awake()
    {
        transitionAnimator.SetTrigger("Awake");
    }

    public void EndGame() {
        transitionAnimator.SetTrigger("EndGame");
    }
}
