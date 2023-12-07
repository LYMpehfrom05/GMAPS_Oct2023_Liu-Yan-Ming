// uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D ()
    {
        // your code here
    }

    public HMatrix2D (float[,] multiarray)
    {
        // 3 rows
        for (int y = 0; y < 3; y++)
        {
            // 3 columns
            for (int x = 0; x < 3; x++)
            {
                // Assign multiarray values to entries
                entries[x, y] = multiarray[x, y];
            }
        }
    }

    public HMatrix2D (float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // first row
        entries[0,0] = m00; // Column 1
        entries[1,0] = m01; // Column 2
        entries[2,0] = m02; // Column 3

        // second row
        entries[0,1] = m10; // Column 1
        entries[1,1] = m11; // Column 2
        entries[2,1] = m12; // Column 3

        // third row
        entries[0,2] = m20; // Column 1
        entries[1,2] = m21; // Column 2
        entries[2,2] = m22; // Column 3
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        // Create variable for new addition operator
        HMatrix2D addEntries = new HMatrix2D();

        // 3 rows
        for (int y = 0; y < 3; y++)
        {
            // 3 columns
            for (int x = 0; x < 3; x++)
            {
                // The operator = left + right entries
                addEntries.entries[x,y] = left.entries[x,y] + right.entries[x,y];
            }
        }
        // Return result
        return addEntries;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        // Create variable for new subtraction operator
        HMatrix2D subtractEntries = new HMatrix2D();

        // 3 rows
        for (int y = 0; y < 3; y++)
        {
            // 3 columns
            for (int x = 0; x < 3; x++)
            {
                // The operator = left - right entries
                subtractEntries.entries[x, y] = left.entries[x, y] - right.entries[x, y];
            }
        }
        // Return result
        return subtractEntries;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        // Create variable for new multiplication operator
        HMatrix2D multiplyEntries = new HMatrix2D();

        // 3 rows
        for (int y = 0; y < 3; y++)
        {
            // 3 columns
            for (int x = 0; x < 3; x++)
            {
                // The operator = left entries multiplied by the scalar
                multiplyEntries.entries[x, y] = left.entries[x, y] * scalar;
            }
        }
        // Return result
        return multiplyEntries;
    }

    // note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            // Multiply each number in the matrix with each axis of the vector, z axis is 0 since the vector is 2D
            left.entries[0,0] * right.x + left.entries[0,1] * right.y + left.entries[0,2] * 1.0f,
            left.entries[1,0] * right.x + left.entries[1,1] * right.y + left.entries[1,2] * 1.0f,
            left.entries[2,0] * right.x + left.entries[2,1] * right.y + left.entries[2,2] * 1.0f
        );
    }

    // note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
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

            /* 
                00 01 02    xx xx 02
                xx xx xx    xx xx 12
                xx xx xx    xx xx 22
                */
            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

            /* 
                xx xx xx    00 xx xx
                10 11 12    10 xx xx
                xx xx xx    20 xx xx
                */
            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],

            /* 
                xx xx xx    xx 01 xx
                10 11 12    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],

            /* 
                xx xx xx    xx xx 02
                10 11 12    xx xx 12
                xx xx xx    xx xx 22
                */
            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

            /* 
                xx xx xx    00 xx xx
                xx xx xx    10 xx xx
                20 21 22    20 xx xx
                */
            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],

            /* 
                xx xx xx    xx 01 xx
                xx xx xx    xx 11 xx
                20 21 22    xx 21 xx
                */
            left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],

            /* 
                xx xx xx    xx xx 02
                xx xx xx    xx xx 12
                20 21 22    xx xx 22
                */
            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]

    );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        // 3 rows
        for (int y = 0; y < 3; y++)
        {
            // 3 columns
            for (int x = 0; x < 3; x++)
            {
                // Return false if left and right entries do not match
                if(left.entries[x,y] != right.entries[x,y])
                {
                    return false;
                }
            }
        }
        // Return true otherwise as this alternate condition means they match
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        // 3 rows
        for (int y = 0; y < 3; y++)
        {
            // 3 columns
            for (int x = 0; x < 3; x++)
            {
                // Return true if left and right entries do not match
                if (left.entries[x, y] != right.entries[x, y])
                {
                    return true;
                }
            }
        }
        // Return false otherwise as this alternate condition means they match
        return false;
    }

    //public hmatrix2d transpose()
    //{
    //    return // your code here
    //}

    //public float getdeterminant()
    //{
    //    return // your code here
    //}

    public void setidentity()
    {
        //// 3 rows
        //for (int y = 0; y < 3 ; y++)
        //{
        //    // 3 columns
        //    for (int x = 0; x < 3; x++)
        //    {
        //        // If elements are on the main diagonal, as the matrix is a square matrix, x is equal to y
        //        if(x == y) 
        //        {
        //            // Elements are set to 1
        //            entries [x,y] = 1;
        //        }
        //        else
        //        {
        //            // Elements not on a diagonal set are set to 0
        //            entries[x,y] = 0;
        //        }
        //    }
        //}

        // 3 rows
        for (int y = 0; y < 3; y++)
        {
            // 3 columns
            for (int x = 0; x < 3; x++)
            {
                // If elements are on the main diagonal, as the matrix is a square matrix, x is equal to y, elements are set to 1. Otherwise, they are set to 0
                entries[x, y] = x == y ? 1: 0;
            }
        }
    }

    public void settranslationmat(float transx, float transy)
    {
        // Set matrix to identity matrix
        setidentity();
        // Rightmost column always used for translation due to "Right-to-Left" order of matrix multiplication
        // Modify third column to represent x transformation
        entries[0,2] = transx;
        // Move down the column to the next row to represent y transformation
        entries[1,2] = transy;
    }

    public void setrotationmat(float rotdeg)
    {
        // Set matrix to identity matrix
        setidentity();
        // Degrees to radians
        float rad = rotdeg * Mathf.Deg2Rad;

        // The entries in a 2D rotation matrix, by rows, are Cos - Sin, Sin + Cos
        entries[0,0] = Mathf.Cos(rad);
        entries[0,1] = -Mathf.Sin(rad);
        entries[1,0] = Mathf.Sin(rad);
        entries[1,1] = Mathf.Cos(rad);
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
