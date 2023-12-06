// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.setIdentity();
        mat.Print();
        Question2();
    }

    public Question2()
    {
        // Declare objects
        HMatrix2D mat1 = new HMatrix2D();
        HMatrix2D mat2 = new HMatrix2D();
        HMatrix2D resultMat;
        HVector2D vec1 = new HVector2D(1.0f, 3.0f);

        // Assign resultMat to the value of mat1 and mat2 multiplied
        resultMat = mat1 * mat2;

    }

}
