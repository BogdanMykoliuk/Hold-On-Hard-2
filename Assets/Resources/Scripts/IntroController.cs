using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    private Animator currentAnimator;
    public enum IntroType { FallingIntro, LeverIntro, RunningIntro, LiftIntro };
    public IntroType currentIntroType;

    private void Awake()
    {
        currentAnimator = GetComponent<Animator>();
        switch (currentIntroType){
            case IntroType.FallingIntro:
                currentAnimator.SetBool("FallingIntro", true);
                break;

            case IntroType.LeverIntro:
                currentAnimator.SetBool("LeverIntro", true);
                break;
            case IntroType.RunningIntro:
                currentAnimator.SetBool("RunningIntro", true);
                break;
            case IntroType.LiftIntro:
                currentAnimator.SetBool("LiftIntro", true);
                break;
        }
    }
}
