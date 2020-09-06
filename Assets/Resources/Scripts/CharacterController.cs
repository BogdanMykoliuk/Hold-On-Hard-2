using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private GameObject winPanel;
    private GameObject losePanel;
    public GameObject choosePanel;

    private AudioListener audiolistener;

    public static bool isTouch;

    public Transform cameraTransform;
    public float finishPoint;

    public static Rigidbody2D charaterRigidbody;
    public static Animator characterAnimator;
    public static AudioSource characterAudioSource;

    public bool isLever = false;

    public static string lastTrigger;

    public enum State { Static, Falling, FallingHold, Running, RunningHold, Dead, FinishRunning };
    public static State currentState;

    public enum MovingDirection { Vertical, Horizontal };
    public MovingDirection currentMovingDirection;

    private bool isChangedMovingDirection = false;
    private float timeToHoldingAnimation = 0;
    public static bool isGamePaused;

    private void Awake()
    {
        isTouch = false;
        winPanel = GameObject.FindGameObjectWithTag("WinPanel");
        losePanel = GameObject.FindGameObjectWithTag("LosePanel");
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        audiolistener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
        lastTrigger = "Clear";
        characterAudioSource = GetComponent<AudioSource>();
        characterAnimator = GetComponent<Animator>();
        charaterRigidbody = GetComponent<Rigidbody2D>();
        isGamePaused = false;

        if(isLever)
            lastTrigger = "Fall";

        //currentMovingDirection = MovingDirection.Vertical;

        currentState = State.Static;

        if (currentMovingDirection == MovingDirection.Vertical) {
            MovementController.speed.y = -MovementController.FallingSpeed;
        }

    }

    private void FixedUpdate()
    {
        if (!isGamePaused)
        {
            //Debug.Log(currentState);
            if (currentState != State.Dead && currentState != State.Static)
            {
                if (currentState != State.FinishRunning)
                {
                    //Debug.Log(isTouch);
                    if (isTouch)
                        toHold(Time.deltaTime);
                    else
                        toMove(Time.deltaTime);
 
                }
                else {
                    
                    toMove(Time.deltaTime);
                }


            }
            else
            {
                if (currentMovingDirection == MovingDirection.Vertical)
                {
                    toMove(Time.deltaTime);

                }
                else
                {
                    toHold(Time.deltaTime);
                }
                


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (currentState != State.Dead) {
            if (collision.tag == "Trap")
            {
                Dead(collision.name);
            }
            else if (collision.tag == "Finish")
            {
                Finish();
            }
            else if (collision.tag == "ChangeMovingDirection" && !isChangedMovingDirection) {
                isChangedMovingDirection = true;
                ChangeMovingDirection();
                
            }
            else if (collision.tag == "ChoosePoint")
            {
                ChoosePoint();
            }
            else if (collision.tag == "StopPoint")
            {
                StopPoint();
            }
        }
    }

    public void Dead(string name) {
        currentState = State.Dead;
        characterAudioSource.Play();
        if (name.Substring(0, 3) == "Fir")
        {
            characterAnimator.SetTrigger("FallFireDeath");
        }
        else if (name == "Gorgona") {
            characterAnimator.SetTrigger("Level_2_Death_Anim");
        }
        else
        {
            characterAnimator.SetTrigger("FallDeath");
        }

        cameraTransform.parent = null;

        losePanel.SetActive(true);

    }

    public void Finish() {
        isGamePaused = false;
        currentState = State.FinishRunning;
        cameraTransform.parent = null;
        winPanel.SetActive(true);

    }

    public void ChangeMovingDirection(){

        if (currentMovingDirection == MovingDirection.Vertical)
            currentMovingDirection = MovingDirection.Horizontal;
        else
            currentMovingDirection = MovingDirection.Vertical;

    }

    public void ChoosePoint()
    {
        currentState = State.Static;
        //isGamePaused = true;
        MovementController.speed = Vector2.zero;
        charaterRigidbody.velocity = Vector2.zero;
        choosePanel.SetActive(true);
        if (currentMovingDirection == MovingDirection.Vertical)
            characterAnimator.SetTrigger("FallingHold");
        else
            characterAnimator.SetTrigger("RunningHold");
        lastTrigger = "UseItem";
            

    }

    public void StopPoint() {
        isGamePaused = true;
        MovementController.speed = Vector2.zero;
        charaterRigidbody.velocity = Vector2.zero;
        if (currentMovingDirection == MovingDirection.Vertical)
            characterAnimator.SetTrigger("FallingHold");
        else
            characterAnimator.SetTrigger("RunningHold");
    }


    public void toHold(float time) {
        timeToHoldingAnimation += time;
        Vector2 speed;
        if (true) {

            if (currentMovingDirection == MovingDirection.Vertical)
            {
                speed = MovementController.VerticalMoveStopping(time);
                if (currentState != State.Dead) {
                    if (timeToHoldingAnimation >= 3 && lastTrigger != "FallingContinueHolding")
                    {
                        characterAnimator.SetTrigger("FallingContinueHolding");
                        lastTrigger = "FallingContinueHolding";
                    }
                    else if (lastTrigger != "FallingHold" && lastTrigger != "FallingContinueHolding")
                    {
                        characterAnimator.SetTrigger("FallingHold");
                        lastTrigger = "FallingHold";
                    }
                }
                
            }
            else {

                speed = MovementController.HorizontalMoveStopping(time);
                if (currentState != State.Dead)
                {
                    if (lastTrigger != "RunningHold")
                    {
                        characterAnimator.SetTrigger("RunningHold");
                        lastTrigger = "RunningHold";
                    }
                }
            }
            charaterRigidbody.velocity = speed;
        }
        
        
    }

    public void toMove(float time) {
        timeToHoldingAnimation = 0;
        Vector2 speed;
        if (currentMovingDirection == MovingDirection.Vertical) {

            if (MovementController.speed.y >= -MovementController.FallingSpeed)
                MovementController.speed.y = -MovementController.FallingSpeed;

            speed = MovementController.VerticalMove(time);
            if (lastTrigger != "Fall" && currentState != State.Dead)
            {
                characterAnimator.SetTrigger("Fall");
                lastTrigger = "Fall";
            }
        }
        else {

            if (MovementController.speed.x <= MovementController.RunningSpeed)
                MovementController.speed.x = MovementController.RunningSpeed;

            speed = MovementController.HorizontalMove(time);
            if (lastTrigger != "Run" && currentState != State.Dead)
            {
                characterAnimator.SetTrigger("Run");
                lastTrigger = "Run";
            }
        } 
        charaterRigidbody.velocity = speed;
    }

    public void PauseResumeGame(bool boolean) {
        isGamePaused = boolean;
        if (boolean)
        {
            audiolistener.enabled = false;
            Time.timeScale = 0;
        }
        else {
            audiolistener.enabled = true;
            Time.timeScale = 1;
        }
            
    }

    public void ResumeAnimation(string trigger) {
        characterAnimator.SetTrigger(trigger);
    }



}