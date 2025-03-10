using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnTrigger : MonoBehaviour
{

    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //animates the hand to either pinch or grab, depending on which button is pressed and how hard it is being pressed.
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>(); //reads how much the trigger is pressed
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue <float>();
        handAnimator.SetFloat("Grip", gripValue);
        //Debug.Log(triggerValue);
    }
}
