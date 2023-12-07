using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody from game object
        rb.AddForce(force, ForceMode.Impulse); // Use ForceMode.Impulse to only apply force once
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

