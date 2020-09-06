using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSprites : MonoBehaviour
{
    public enum Location {Egypet, Drakula };
    public Location currentLocation;

    private Animator thisAnimator;

    private void Awake()
    {
        thisAnimator = GetComponent<Animator>();
        Debug.Log(currentLocation);
        if (currentLocation == Location.Egypet)
        {
            thisAnimator.SetBool("Egypet", true);
            thisAnimator.SetBool("Drakula", false);
        }
        else if (currentLocation == Location.Drakula)
        {
            thisAnimator.SetBool("Drakula", true);
            thisAnimator.SetBool("Egypet", false);
        }
    }

}
