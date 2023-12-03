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
        CalculateGameDimensions();
        //if (Q2a)
        //Question2a();
        //if (Q2b)
        //Question2b(20);
        //if (Q2d)
        //Question2d();
        //if (Q2e)
        //Question2e(20);
        //if (Q3a)
        //Question3a();
        //if (Q3b)
        //Question3b();
        //if (Q3c)
        Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        // Set 2x enlarged orthographic camera to be the game height
        GameHeight = Camera.main.orthographicSize * 2f;
        // Set size of game width according to the aspect ratio
        GameWidth = Camera.main.aspect * GameHeight;

        // Maximum of both x-coordinates and y-coordinates of dimensions are the half of game's width and height
        maxX = GameWidth / 2;
        maxY = GameHeight / 2;

        // Minimum of both x-coordinates and y-coordinates are the negative maximum values
        minX = -maxX;
        minY = -maxY;
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
        // Set up program to draw red 3D debug arrow from origin to new point(5,5,0), and display it for 60 seconds
        DebugExtension.DebugArrow(new Vector3(0, 0, 0), new Vector3(5, 5, 0), Color.red, 60f);
    }

    void Question2e(int n)
    {
        // Repeat if i is below n
        for (int i = 0; i < n; i++)
        {
            // Startpoint to be randomised, set in a range between negative and positive maximum x-coordinate,
            // and a range between negative and positive maximum y-coordinate
            startPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            // Minimum of both x-coordinates and y-coordinates are the negative maximum values
            minX = -maxX; minY = -maxY;

            // Set up program to draw white 3D debug arrow from origin to new randomized point, and display it for 60 seconds. Endpoint to be randomised, set
            // in a range between negative and positive maximum x-coordinate, and a range between negative and positive maximum y-coordinate. Z-coordinates
            // follow that of y-coordinates
            DebugExtension.DebugArrow(new Vector3(0, 0, 0), new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(minY, maxY)), Color.white, 60f);
        }  
    }

    public void Question3a()
    {
        // Create new vectors a,b,and c
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b;

        // Draw arrow from origin to a, coloured red, at 60f size, and print out console message of its magnitude
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));

        // Draw arrow from origin to b, coloured green, at 60f size, and print out console message of its magnitude
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));

        // Draw arrow from origin to c, coloured white, at 60f size, and print out console message of its magnitude
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));

        // Draw c arrow from b, coloured white, at 60f size
        DebugExtension.DebugArrow(b.ToUnityVector3(), c.ToUnityVector3(), Color.white, 60f);

        // Draw -b arrow from a, coloured white, at 60f size
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.white, 60f);
    }

    public void Question3b()
    {
        // Create new vectors a and b, which is twice the size of a
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a*2;

        // Draw arrow from origin to a, coloured red, at 60f size divided by 2
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f/2);

        // Draw arrow 1f from origin, to b, coloured green
        DebugExtension.DebugArrow(new Vector3(1,0,0), b.ToUnityVector3(), Color.green);

    }

    public void Question3c()
    {
        // Create new vector a
        HVector2D a = new HVector2D(3, 5);

        // Draw arrow from origin to a, coloured red, at 60f size
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);

        // Draw arrow from normalised 1f from origin, to a, coloured red, at 60f size
        DebugExtension.DebugArrow(new Vector3.Normalize(1,0,0), a.ToUnityVector3(), Color.red, 60f);
        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
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
