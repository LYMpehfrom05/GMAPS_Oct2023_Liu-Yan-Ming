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
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            drawnLine.EnableDrawing(false);

            //update the velocity of the white ball.
            HVector2D v = new HVector2D(/*your code here*/);
            ball./*your code here*/ = v;

            drawnLine = null; // End line drawing            
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
