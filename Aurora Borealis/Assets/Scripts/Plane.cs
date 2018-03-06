using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public int X;
    public int Y;
    public MeshFilter MeshFilter;

    private Mesh Mesh;
    private Vector3[] Vertices;
    private int[] Triangles;

    private void Start()
    {
        AssembleVertices();
        AssembleTriangles();

        Mesh = new Mesh();
        MeshFilter.mesh = Mesh;
        Mesh.SetVertices(new List<Vector3>(Vertices));
        Mesh.SetTriangles(Triangles, 0);
        Mesh.RecalculateNormals();
    }

    private void AssembleVertices()
    {
        Vertices = new Vector3[X * Y];

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                int idx = i * Y + j;
                Vertices[idx] = new Vector3(i, 0, j);
            }
        }
    }

    private void AssembleTriangles()
    {
        Triangles = new int[(X - 1) * (Y - 1) * 6];
        int idx = 0;

        for (int i = 0; i < X - 1; i++)
        {
            for (int j = 0; j < Y - 1; j++)
            {
                Triangles[idx] = i * Y + j;
                Triangles[idx + 1] = i * Y + j + 1;
                Triangles[idx + 2] = i * Y + j + Y;
                Triangles[idx + 3] = i * Y + j + Y + 1;
                Triangles[idx + 4] = i * Y + j + Y;
                Triangles[idx + 5] = i * Y + j + 1;
                idx += 6;
            }
        }
    }
}
