using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        //if (Q2a)
        //Question2a();
        //if (Q2b)
        Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {

    }

    void Question2a()
    {
        // Set startpoint to be 0 on x-axis and 0 on y-axis
        startPt = new Vector2(0, 0);
        // Set endpoint to be 2 on x-axis and 3 on y-axis
        endPt = new Vector2(2, 3);

        // Set the drawing of line from startpoint to endpoint, at 0.02f thick and in black colour
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        // Enable the drawing process
        drawnLine.EnableDrawing(true);

        // Calculate magnitude of vector
        Vector2 vec2 = endPt - startPt;
        // Debug
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        // Repeat if n is below 20
        for(n=0; n<20; n++)
        {
            // Startpoint to be randomised, set in a range between negative and positive maximum x-coordinate,
            // and a range between negative and positive maximum y-coordinate
            startPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            // Endpoint to be randomised, set in a range between negative and positive maximum x-coordinate,
            // and a range between negative and positive maximum y-coordinate
            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            // Maximum of both x-coordinates and y-coordinates are 5
            maxX = 5; maxY = 5;
            // Minimum of both x-coordinates and y-coordinates are the negative maximum values
            minX = -maxX; minY = -maxY;

            // Set the drawing of line from startpoint to endpoint, at 0.02f thick and in black colour
            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

            // Enable the drawing process
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {

    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY));

            // Your code here
            // ...

            //DebugExtension.DebugArrow(
            //    new Vector3(0, 0, 0),
            //    // Your code here,
            //    Color.white,
            //    60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        //HVector2D b = // Your code here;
        //HVector2D c = // Your code here;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
        // ...

        // Your code here

        //Debug.Log("Magnitude of a = " + // Your code here.ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        // Your code here
        // ...

        //DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
    }

    public void Question3c()
    {

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
