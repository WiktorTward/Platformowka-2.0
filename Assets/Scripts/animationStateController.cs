using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool movePressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space); // Sprawd�, czy spacja zosta�a naci�ni�ta

        // Je�li wci�ni�ty jest klawisz W, A, S, D
        if (!isWalking && movePressed)
        {
            animator.SetBool("isWalking", true);
        }
        // Je�li gracz nie wciska przycisku W, A, S, D
        if (isWalking && !movePressed)
        {
            animator.SetBool("isWalking", false);
        }
        // Je�li gracz wciska klawisz W, A, S, D i lewy shift
        if (!isRunning && (movePressed && runPressed))
        {
            animator.SetBool("isRunning", true);
        }
        // Je�li gracz nie wciska przycisku W, A, S, D lub lewy shift
        if (isRunning && (!movePressed || !runPressed))
        {
            animator.SetBool("isRunning", false);
        }
        // Je�li gracz naci�nie spacj� i nie jest ju� w trakcie skoku
        if (jumpPressed && !animator.GetBool("isJumping"))
        {
            animator.SetBool("isJumping", true); // Ustaw warto�� "isJumping" na true
        }
        else
        {
            animator.SetBool("isJumping", false); // Ustaw warto�� "isJumping" na false, je�li gracz nie nacisn�� spacj�
        }
    }
}

