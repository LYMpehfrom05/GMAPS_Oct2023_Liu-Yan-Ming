using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        // Assign time to dt variable for later use
        float dt = Time.deltaTime;

        // Displacement coordinates x, y and z determined by velocity multiplied by time
        float dx = Velocity.x * dt;
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        // Update vector3 position with the new one
        transform.position(new Vector3(dx,dy,dz));
    }
}
