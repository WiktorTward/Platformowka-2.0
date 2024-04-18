using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isrunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool movePressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        //je�li wci�ni�ty jest klawisz W,A,S,D
        if (!isWalking && movePressed)
        {
            //ustaw "isWalking" jako warto�� true
            animator.SetBool("isWalking", true);
        }
        //Je�li gracz nie wciska przycisku W,A,S,D
        if (isWalking && !movePressed)
        {
            //Ustaw warto�� "isWalking" jako false
            animator.SetBool("isWalking", false);
        }
        //je�li gracz wciska klawisz W,A,S,D i lewy shift
        if (!isrunning && (movePressed && runPressed)) 
        {
            //ustaw "isRunning" jako true
            animator.SetBool("isRunning", true );        
        }
        //Je�li gracz nie wciska przycisku W,A,S,D lub lewy shift
        if (isrunning && (!movePressed || !runPressed))
        {
            animator.SetBool("isRunning", false);
        }
    }
}
