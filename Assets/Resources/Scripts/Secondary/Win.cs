using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private CharacterController controller;

    public Animator bossAnimator;
    public Animator characterParentAnimator;
    public GameObject gameObjectToHide;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterController>();
    }

    public void AdditionAnimation(string name) {

        characterParentAnimator.SetTrigger(name);
    }

    public void HideGameObject() {
        gameObjectToHide.SetActive(false);
    }

    void Finish() {
        controller.Finish();
    }

    void Death()
    {
        controller.Dead("Gorgona");
    }

    public void Attack() {
        bossAnimator.SetTrigger("Attack");
    }

    public void ResumeGame() {
        CharacterController.currentState = CharacterController.State.Running;
    }

    public void PauseGame()
    {
        CharacterController.currentState = CharacterController.State.Static;
    }

    public void ResumeAnimation(string trigger) {
        CharacterController.lastTrigger = "Run";
        CharacterController.currentState = CharacterController.State.Running; 
        controller.ResumeAnimation(trigger);
    }   
}
