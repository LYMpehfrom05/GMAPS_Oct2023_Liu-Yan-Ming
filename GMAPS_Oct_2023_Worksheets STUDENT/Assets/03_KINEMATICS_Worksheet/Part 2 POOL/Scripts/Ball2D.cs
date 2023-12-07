using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        float distance = /*your code here*/;
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        // Displacement = velocity * time
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        // Update position of ball according to the displacement
        Position.x += displacementX;
        Position.y += displacementY;

        // Set Unity transform position to the updated one
        transform.position = new Vector2(Position.x,Position.y);
    }
}

