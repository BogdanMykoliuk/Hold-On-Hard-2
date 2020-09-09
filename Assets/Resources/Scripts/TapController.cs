using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    private void OnMouseDown()
    {
        CharacterController.isTouch = true;        
    }
    private void OnMouseUp()
    {
        CharacterController.isTouch = false;
    }
}
