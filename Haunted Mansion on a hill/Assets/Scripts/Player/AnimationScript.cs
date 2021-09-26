using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isBackingHash;
    int isTurningRightHash;
    int isTurningLeftHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isBackingHash = Animator.StringToHash("isBacking");
        isRunningHash = Animator.StringToHash("isRunning");
        isTurningRightHash = Animator.StringToHash("isTurningRight");
        isTurningLeftHash = Animator.StringToHash("isTurningLeft");
    }

    // Update is called once per frame
    void Update()
    {
        bool isBacking = animator.GetBool(isBackingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isTurningRight = animator.GetBool(isTurningRightHash);
        bool isTurningLeft = animator.GetBool(isTurningLeftHash);
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool turnLeftPressed = Input.GetKey("a");
        bool turnRightPressed = Input.GetKey("d");
        bool runPressed = Input.GetKey("left shift");

        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isBacking && backwardPressed)
        {
            animator.SetBool(isBackingHash, true);
        }

        if (isBacking && !backwardPressed)
        {
            animator.SetBool(isBackingHash, false);
        }

        if (!isTurningLeft && turnLeftPressed)
        {
            animator.SetBool(isTurningLeftHash, true);
        }

        if (isTurningLeft && !turnLeftPressed)
        {
            animator.SetBool(isTurningLeftHash, false);
        }

        if (!isTurningRight && turnRightPressed)
        {
            animator.SetBool(isTurningRightHash, true);
        }

        if (isTurningRight && !turnRightPressed)
        {
            animator.SetBool(isTurningRightHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
