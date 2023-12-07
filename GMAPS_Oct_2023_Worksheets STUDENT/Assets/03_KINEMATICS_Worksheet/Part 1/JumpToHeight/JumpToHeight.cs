using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody from game object
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        // Find initial jump velocity (v*v = u*u + 2as), then assign it to new vector3
        float u = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        rb.velocity = new Vector3(0,u,0);

        // Alternatively, calculate jumpForce the same way and use AddForce with impulse:
        float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If space bar is pressed, call jump function
            Jump();
        }
    }
}

