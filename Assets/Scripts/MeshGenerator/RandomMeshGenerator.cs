using UnityEngine;

namespace FlexusCannon.MeshGenerator
{
    public class RandomMeshGenerator
    {
        public Mesh Generate(Mesh source, float strength)
        {
            Mesh mesh = new();

            Vector3[] vertices = source.vertices;
            int[] triangles = source.triangles;

            Vector3[] newVertices = new Vector3[vertices.Length];

            int seed = Random.Range(0, 99999);
            System.Random rand = new(seed);

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 v = vertices[i];

                Vector3 offset = new Vector3(
                    (float)(rand.NextDouble() * 2 - 1),
                    (float)(rand.NextDouble() * 2 - 1),
                    (float)(rand.NextDouble() * 2 - 1)
                ) * strength;

                newVertices[i] = v + offset;
            }

            mesh.vertices = newVertices;
            mesh.triangles = triangles;

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            return mesh;
        }
    }
}