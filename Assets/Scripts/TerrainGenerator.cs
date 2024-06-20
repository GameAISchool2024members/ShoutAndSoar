using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TerrainGenerator : MonoBehaviour
{
    private Mesh mesh;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private Vector2 planeSize = new Vector2(1, 1);
    [SerializeField] private int gridSize = 16;
    [SerializeField] private float perlinNoiseScale = 3.0f;
    [SerializeField] private float perlinNoiseStrength = 2.0f;
    [SerializeField] private Vector2 perlinOffset = Vector2.zero;

    private List<Vector3> vertices;
    private List<int> triangles;
    private List<Vector3> normals;
    private List<Vector2> uvs;

    void OnEnable()
    {
        mesh = new Mesh {
            name = "Procedural Mesh"
        };
        CreateMesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();
        mesh.SetUVs(0, uvs.ToArray());
        meshFilter.mesh = mesh;
    }

    void onUpdate()
    {
        mesh.Clear();
        CreateMesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();
        mesh.SetUVs(0, uvs.ToArray());
    }

    void CreateMesh()
    {
        gridSize = Mathf.Clamp(gridSize, 1, 50);
        vertices = new List<Vector3>();
        triangles = new List<int>();
        normals = new List<Vector3>();
        uvs = new List<Vector2>();
        float xPerStep = planeSize.x / gridSize;
        float yPerStep = planeSize.y / gridSize;

        for (int x = 0; x < gridSize + 1; x++)
        {
            for (int y = 0; y < gridSize + 1; y++)
            {
                vertices.Add(new Vector3(x * xPerStep, 0, y * yPerStep));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2((float)x / gridSize, (float)y / gridSize));
                // Based on uv, add perlin noise to y value
                vertices[vertices.Count - 1] += Vector3.up * Mathf.PerlinNoise((vertices[vertices.Count - 1].x + perlinOffset.x) * perlinNoiseScale, (vertices[vertices.Count - 1].z + perlinOffset.y) * perlinNoiseScale) * perlinNoiseStrength;
            }
        }

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                int vertexIndex = x * gridSize + x + y;
                triangles.Add(vertexIndex + gridSize + 2);
                triangles.Add(vertexIndex + gridSize + 1);
                triangles.Add(vertexIndex);

                triangles.Add(vertexIndex + 1);
                triangles.Add(vertexIndex + gridSize + 2);
                triangles.Add(vertexIndex);
            }
        }

    }

}
