using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public static Vector3 speed = Vector3.zero;

    public static float FallingSpeed = 5f;
    public static float RunningSpeed = 3f;


    private void Awake()
    {
        speed = Vector3.zero;
    }

    public static Vector2 HorizontalMove(float time) {
        var runningSpeed = Mathf.MoveTowards(speed.x, 6, time);
        speed = new Vector2(runningSpeed, 0);
        return speed;
    }
    public static Vector2 VerticalMove(float time)
    {
        var fallingSpeed = Mathf.MoveTowards(-speed.y, 10, time * 3);
        speed = new Vector2(0, -fallingSpeed);
        return speed;

    }
    public static Vector2 VerticalMoveStopping(float time) {
        var fallingSpeed = Mathf.MoveTowards(-speed.y, 0, time * 17);
        speed = new Vector2(0, -fallingSpeed);
        return speed;

    }
    public static Vector2 HorizontalMoveStopping(float time)
    {
        var runningSpeed = Mathf.MoveTowards(speed.x, 0, time * 20);
        speed = new Vector2(runningSpeed, 0);
        return speed;

    }
}
