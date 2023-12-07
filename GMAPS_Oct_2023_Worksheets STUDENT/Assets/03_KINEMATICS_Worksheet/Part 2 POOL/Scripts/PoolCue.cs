using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        // If left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Set start line by converting mouse position to world space
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            // If mouse collides with the existing ball, create and start drawing a line
            if (ball != null && ball.IsCollidingWith(startLinePos))
            {
                drawnLine = lineFactory.CreateLine(startLinePos);
                drawnLine.EnableDrawing(true);
            }
        }
        // If mouse button is released when line is drawn
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            // Disable line drawing
            drawnLine.EnableDrawing(false);

            // Update velocity of ball to move to mouse position
            HVector2D v = new HVector2D(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            // Set velocity of the ball to v
            ball.Velocity = v;

            // End line drawing
            drawnLine = null;             
        }
        // Update line end at mouse position while drawing
        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
