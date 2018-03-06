using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float width;
    public float height;
    public int X;
    public int Y;
    public MeshFilter MeshFilter;

    private Mesh Mesh;
    private Vector3[] Vertices;
    private int[] Triangles;
    private Vector2[] UVs;

    private void Start()
    {
        AssembleVertices();
        AssembleTriangles();
        AssembleUVs();

        Mesh = new Mesh();
        MeshFilter.mesh = Mesh;
        Mesh.SetVertices(new List<Vector3>(Vertices));
        Mesh.SetTriangles(Triangles, 0);
        Mesh.SetUVs(0, new List<Vector2>(UVs));
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
                Vertices[idx] = new Vector3(i * width / (X - 1), j * height / (Y - 1));
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

    private void AssembleUVs()
    {
        UVs = new Vector2[Vertices.Length];

        for (int i = 0; i < Vertices.Length; i++)
        {
            UVs[i] = new Vector2((Vertices[i].x / X / width) * (X - 1), (Vertices[i].y / Y) / height) * (Y - 1);
        }
    }
}
