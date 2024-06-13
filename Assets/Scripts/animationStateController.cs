using ECM2;
using ECM2.Examples.PlanetWalk;
using System.Collections;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    bool isJumping = false;
    bool isLifting = false;
<<<<<<< HEAD
    bool isGathering = false; // Flag to track if gathering action is in progress
    bool isCrouching = false; // Flag to track if crouching action is in progress
    private bool isCrouchIdle = false; // Flag to track if crouch idle action is in progress
    public ECM2.Examples.ThirdPerson.ThirdPersonController move;
    public Character myRb;

    // Enum for animation states
=======
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
>>>>>>> origin/Kamil
    private enum AnimationState
    {
        Idle,
        Walking,
        Running,
<<<<<<< HEAD
        RunningJump,
        WalkingJump,
        IdleJump,
        Lifting,
        Crouching,
        CrouchIdle,
        Moving
    }

=======
        Jumping,
        Lifting,
        Crouching,
        CrouchIdle
    }

    private AnimationState currentAnimationState = AnimationState.Idle;

>>>>>>> origin/Kamil
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
<<<<<<< HEAD
                    SetAnimatorTrigger(AnimationState.RunningJump);
                }
                else if (isWalking)
                {
                    SetAnimatorTrigger(AnimationState.WalkingJump);
                }
                else
                {
                    SetAnimatorTrigger(AnimationState.IdleJump);
=======
                    animator.SetTrigger(isRunningJumpAnim);
                }
                else if (isWalking)
                {
                    animator.SetTrigger(isWalkingJumpAnim);
                }
                else
                {
                    animator.SetTrigger(isIdleJumpAnim);
>>>>>>> origin/Kamil
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
<<<<<<< HEAD
            if (crouchPressed && !isCrouching)
            {
                isCrouching = true;
                SetAnimatorBool(AnimationState.Crouching, true);
                myRb.canEverJump = false; // Disable jumping while crouching
                SetAnimatorBool(AnimationState.Moving, movePressed); // Set Moving based on player movement
            }
            else if (!crouchHeld && isCrouching)
            {
                isCrouching = false;
                SetAnimatorBool(AnimationState.Crouching, false);
                SetAnimatorBool(AnimationState.Moving, false);
                StartCoroutine(EnableJumpAfterDelay(0.4f)); // Enable jumping after 0.4 seconds
            }

            // Handle crouch idle
            if (crouchIdlePressed && !isCrouchIdle)
            {
                isCrouchIdle = true;
                SetAnimatorBool(AnimationState.CrouchIdle, true);
                SetAnimatorBool(AnimationState.Moving, false);
                myRb.canEverJump = false; // Disable jumping while crouch idle
            }
            else if (!crouchHeld && isCrouchIdle)
            {
                isCrouchIdle = false;
                SetAnimatorBool(AnimationState.CrouchIdle, false);
                SetAnimatorBool(AnimationState.Moving, movePressed); // Set Moving based on player movement
                StartCoroutine(EnableJumpAfterDelay(0.4f)); // Enable jumping after 0.4 seconds
            }
        }

        // Handle movement animations while not crouching
        if (!isCrouching && !isCrouchIdle && !isMidAir && !isJumping)
        {
            if (!isWalking && movePressed)
            {
                SetAnimatorBool(AnimationState.Walking, true); // Enable walking animation
            }
            else if (isWalking && !movePressed)
            {
                SetAnimatorBool(AnimationState.Walking, false); // Disable walking animation
            }
            if (!isRunning && (movePressed && runPressed))
            {
                SetAnimatorBool(AnimationState.Running, true); // Enable running animation
            }
            else if (isRunning && (!movePressed || !runPressed))
            {
                SetAnimatorBool(AnimationState.Running, false); // Disable running animation
            }
        }
    }

    private void SetAnimatorBool(AnimationState state, bool value)
    {
        switch (state)
        {
            case AnimationState.Walking:
                animator.SetBool("isWalking", value);
                break;
            case AnimationState.Running:
                animator.SetBool("isRunning", value);
                break;
            case AnimationState.Crouching:
                animator.SetBool("isCrouching", value);
                break;
            case AnimationState.CrouchIdle:
                animator.SetBool("isCrouchIdle", value);
                break;
            case AnimationState.Moving:
                animator.SetBool("Moving", value);
                break;
            default:
                break;
        }
    }

    private void SetAnimatorTrigger(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.RunningJump:
                animator.SetTrigger("isRunningJump");
                break;
            case AnimationState.WalkingJump:
                animator.SetTrigger("isWalkingJump");
                break;
            case AnimationState.IdleJump:
                animator.SetTrigger("isIdleJump");
                break;
            case AnimationState.Lifting:
                animator.SetTrigger("isLifting");
                break;
            default:
                break;
        }
    }
=======
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
>>>>>>> origin/Kamil
}


















<<<<<<< HEAD



=======
>>>>>>> origin/Kamil
