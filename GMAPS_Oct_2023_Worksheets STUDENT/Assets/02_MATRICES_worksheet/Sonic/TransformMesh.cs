// Uncomment this whole file.

using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Translate(1,1);
    }


    void Translate(float x, float y)
    {
        // Set identity and translation matrix from the HMatrix2D script
        HMatrix2D.setidentity();
        HMatrix2D.settranslationmat(x,y);
        Transform(); // Call transform

        // Update position with transform
        pos = Transform() * pos;
    }

    void Rotate(float angle)
    {
        // New variables
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        // Translation matrix that moves vertices to origin
        toOriginMatrix.settranslationmat(-pos.x, -pos.y);
        // Translation matrix that moves vertices to original position
        fromOriginMatrix.settranslationmat(pos.x, pos.y);
        // Rotation matrix
        rotateMatrix.setrotationmat(angle);

        // Initialise to identity
        transformMatrix.SetIdentity();
        // Combine matrices to store in transformMatrix
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        Transform();
    }

    private void Transform()
    {
        // Get vertices from cloned mesh
        vertices = meshManager.clonedMesh.vertices;
        
        // For the length of the vertices
        for (int i = 0; i < vertices.Length; i++)
        {
            // Assign x and y values of vertices matrix to new variable vert
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            // Update vertices matrix with transformation matrix
            vert = transformMatrix * vert;
            // Update the x and y values of the vertices
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }
        // Update vertices for clone mesh
        meshManager.clonedMesh.vertices = vertices;
    }
}
