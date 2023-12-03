// uncomment this whole file.

using system.collections;
using system.collections.generic;
using unityengine;

public class hmatrix2d
{
    public float[,] entries { get; set; } = new float[3, 3];

    public hmatrix2d()
    {
        // your code here
    }

    public hmatrix2d(float[,] multiarray)
    {
        // your code here
    }

    public hmatrix2d(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // first row
        // your code here

        // second row
        // your code here

        // third row
        // your code here
    }

    public static hmatrix2d operator +(hmatrix2d left, hmatrix2d right)
    {
        return // your code here
    }

    public static hmatrix2d operator -(hmatrix2d left, hmatrix2d right)
    {
        return // your code here
    }

    public static hmatrix2d operator *(hmatrix2d left, float scalar)
    {
        return // your code here
    }

    // note that the second argument is a hvector2d object
    //
    public static hvector2d operator *(hmatrix2d left, hvector2d right)
    {
        return // your code here
    }

    // note that the second argument is a hmatrix2d object
    //
    public static hmatrix2d operator *(hmatrix2d left, hmatrix2d right)
    {
        return new hmatrix2d
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],

        // and so on for another 7 entries
    );
    }

    public static bool operator ==(hmatrix2d left, hmatrix2d right)
    {
        // your code here
    }

    public static bool operator !=(hmatrix2d left, hmatrix2d right)
    {
        // your code here
    }

    public hmatrix2d transpose()
    {
        return // your code here
    }

    public float getdeterminant()
    {
        return // your code here
    }

    public void setidentity()
    {
        // your code here
    }

    public void settranslationmat(float transx, float transy)
    {
        // your code here
    }

    public void setrotationmat(float rotdeg)
    {
        // your code here
    }

    public void setscalingmat(float scalex, float scaley)
    {
        // your code here
    }

    public void print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        debug.log(result);
    }
}
