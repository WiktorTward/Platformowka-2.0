using ECM2;
using ECM2.Examples.PlanetWalk;
using System.Collections;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    bool isJumping = false;
    bool isLifting = false;
    bool isGathering = false;
    bool isCrouching = false;
    bool isCrouchIdle = false;
    public ECM2.Examples.ThirdPerson.ThirdPersonController move;
    public Character myRb;

    // Animator parameter names
    private string isCrouchingAnimator = "isCrouching";
    private string isCrouchingIdleAnim = "isCrouchIdle";
    private string isWalkingAnim = "isWalking";
    private string isRunningJumpAnim = "isRunningJump";
    private string isWalkingJumpAnim = "isWalkingJump";
    private string isIdleJumpAnim = "isIdleJump";
    private string isRunningAnim = "isRunning";
    private string MovingAnim = "Moving";

    // Animation states
    private enum AnimationState
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Lifting,
        Crouching,
        CrouchIdle
    }

    private AnimationState currentAnimationState = AnimationState.Idle;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Coroutine to wait during the lifting animation
    IEnumerator LiftWait()
    {
        yield return new WaitForSeconds(2.2f);
        move.enabled = true;
        myRb.enabled = true;
        isGathering = false;
    }

    // Coroutine to enable jumping after a delay
    IEnumerator EnableJumpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        myRb.canEverJump = true;
    }

    void Update()
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Input checks
        bool isRunning = animator.GetBool(isRunningAnim);
        bool isWalking = animator.GetBool(isWalkingAnim);
        bool movePressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool liftPressed = Input.GetKeyDown(KeyCode.E);
        bool crouchPressed = Input.GetKey(KeyCode.LeftControl) && movePressed;
        bool crouchIdlePressed = Input.GetKey(KeyCode.LeftControl) && !movePressed;
        bool crouchHeld = Input.GetKey(KeyCode.LeftControl);

        // Check if currently lifting or in mid-air
        isLifting = currentStateInfo.IsTag("Lifting");
        bool isMidAir = !myRb.IsGrounded();

        if (isLifting || isMidAir)
        {
            movePressed = false;
            runPressed = false;
            jumpPressed = false;
            crouchPressed = false;
            crouchIdlePressed = false;
            crouchHeld = false;
        }

        // Lifting logic
        if (liftPressed && !isLifting && !isGathering && !isMidAir)
        {
            animator.SetTrigger("isLifting");
            move.enabled = false;
            myRb.enabled = false;
            isGathering = true;
            StartCoroutine(LiftWait());
            currentAnimationState = AnimationState.Lifting;
        }

        // Jumping logic
        if (!isLifting && !isMidAir)
        {
            if (jumpPressed && !isJumping)
            {
                isJumping = true;
                if (isRunning)
                {
                    animator.SetTrigger(isRunningJumpAnim);
                }
                else if (isWalking)
                {
                    animator.SetTrigger(isWalkingJumpAnim);
                }
                else
                {
                    animator.SetTrigger(isIdleJumpAnim);
                }
                myRb.Jump();
                currentAnimationState = AnimationState.Jumping;
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                isJumping = false;
                currentAnimationState = AnimationState.Idle;
            }
        }

        // Handle different animation states
        switch (currentAnimationState)
        {
            case AnimationState.Idle:
                if (!isLifting && !isJumping && !isMidAir)
                {
                    if (crouchPressed && !isCrouching)
                    {
                        isCrouching = true;
                        isCrouchIdle = false;
                        animator.SetBool(isCrouchingAnimator, true);
                        animator.SetBool(isCrouchingIdleAnim, false);
                        myRb.canEverJump = false;
                        animator.SetBool(MovingAnim, movePressed);
                        currentAnimationState = AnimationState.Crouching;
                    }
                    else if (crouchIdlePressed && !isCrouchIdle)
                    {
                        isCrouching = false;
                        isCrouchIdle = true;
                        animator.SetBool(isCrouchingAnimator, false);
                        animator.SetBool(isCrouchingIdleAnim, true);
                        animator.SetBool(MovingAnim, false);
                        myRb.canEverJump = false;
                        currentAnimationState = AnimationState.CrouchIdle;
                    }
                    else if (!crouchHeld && (isCrouching || isCrouchIdle))
                    {
                        isCrouching = false;
                        isCrouchIdle = false;
                        animator.SetBool(isCrouchingAnimator, false);
                        animator.SetBool(isCrouchingIdleAnim, false);
                        animator.SetBool(MovingAnim, false);
                        StartCoroutine(EnableJumpAfterDelay(0.4f));
                        currentAnimationState = AnimationState.Idle;
                    }
                }

                if (!isCrouching && !isCrouchIdle && !isMidAir && !isJumping)
                {
                    if (!isWalking && movePressed)
                    {
                        animator.SetBool(isWalkingAnim, true);
                        currentAnimationState = AnimationState.Walking;
                    }
                    else if (isWalking && !movePressed)
                    {
                        animator.SetBool(isWalkingAnim, false);
                        currentAnimationState = AnimationState.Idle;
                    }
                    else if (!isRunning && (movePressed && runPressed))
                    {
                        animator.SetBool(isRunningAnim, true);
                        currentAnimationState = AnimationState.Running;
                    }
                    else if (isRunning && (!movePressed || !runPressed))
                    {
                        animator.SetBool(isRunningAnim, false);
                        currentAnimationState = AnimationState.Idle;
                    }
                }
                break;

            case AnimationState.Crouching:
                if (!crouchHeld)
                {
                    isCrouching = false;
                    animator.SetBool(isCrouchingAnimator, false);
                    animator.SetBool(isCrouchingIdleAnim, false);
                    animator.SetBool(MovingAnim, false);
                    StartCoroutine(EnableJumpAfterDelay(0.4f));
                    currentAnimationState = AnimationState.Idle;
                }
                break;

            case AnimationState.CrouchIdle:
                if (!crouchHeld)
                {
                    isCrouchIdle = false;
                    animator.SetBool(isCrouchingAnimator, false);
                    animator.SetBool(isCrouchingIdleAnim, false);
                    animator.SetBool(MovingAnim, false);
                    StartCoroutine(EnableJumpAfterDelay(0.4f));
                    currentAnimationState = AnimationState.Idle;
                }
                break;

            case AnimationState.Walking:
                if (!movePressed)
                {
                    animator.SetBool(isWalkingAnim, false);
                    currentAnimationState = AnimationState.Idle;
                }
                else if (movePressed && runPressed)
                {
                    animator.SetBool(isRunningAnim, true);
                    currentAnimationState = AnimationState.Running;
                }
                break;

            case AnimationState.Running:
                if (!movePressed || !runPressed)
                {
                    animator.SetBool(isRunningAnim, false);
                    currentAnimationState = AnimationState.Idle;
                }
                break;

            case AnimationState.Jumping:
                if (!Input.GetKey(KeyCode.Space))
                {
                    isJumping = false;
                    currentAnimationState = AnimationState.Idle;
                }
                break;

            case AnimationState.Lifting:
                // Do nothing, waiting for the lift animation to finish
                break;
        }
    }
}


















