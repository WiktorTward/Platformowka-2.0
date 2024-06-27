using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public float bounciness = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Rigidbody rb = collision.transform.GetComponent<Rigidbody>();
            rb.velocity = transform.up * bounciness;
        }
    }
}
