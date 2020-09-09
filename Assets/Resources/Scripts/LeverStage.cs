using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverStage : MonoBehaviour
{    
    private Animator characterAnimator;
    public Animator cameraAnimator;
    public Animator leverAnimator;
    private CharacterController characterController;
    [SerializeField] private UI _ui;

    public enum Introduction { Lever, Hole, Lift };
    public Introduction currentIntroduction;

    void Awake() {
        characterController = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();
        if (currentIntroduction == Introduction.Hole) {
            characterController.enabled = true;
            StartCoroutine(HoleEvents());
        }
        else if (currentIntroduction == Introduction.Lift)
            characterAnimator.SetBool("Lift", true);
    }

    private void Update()
    {
        if (CharacterController.isTouch) {
            ChooseIntroduction();
        }

    }

    private void ChooseIntroduction() {
        switch (currentIntroduction) {
            case Introduction.Hole:
                StartCoroutine(HoleEvents());
                break;
            case Introduction.Lever:
                StartCoroutine(LeverEvents());
                break;
            case Introduction.Lift:
                StartCoroutine(LeverEvents());
                break;
        }
    }

    public IEnumerator LeverEvents() {

        characterAnimator.SetTrigger("PushLever");
        leverAnimator.SetTrigger("PushLever");
        _ui.HideTextTapToPlay();
        yield return new WaitForSeconds(1.5f);

        characterController.enabled = true;
        
        cameraAnimator.SetTrigger("BalanceCamera");

        yield return new WaitForSeconds(1f);
        StateFall();
        Destroy(this);

        yield break;
    }
    public IEnumerator HoleEvents(){

        yield return new WaitForSeconds(2f);
        StateFall();
        Destroy(this);

        yield break;
    }

    public void StateFall() {
        CharacterController.currentState = CharacterController.State.Falling;
    }

}
