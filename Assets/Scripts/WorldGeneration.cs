using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject stone;
    public GameObject dirt;
    // public GameObject wood;
    // public GameObject grass;

    // Start is called before the first frame update
    void Start()
    {
        CreateFloor();
    }

    void CreateFloor()
    {
        float y;
        float scale = 7f;
        for (float x = -10; x < 10; x++)
        {
            for (float z = -10; z < 10; z++)
            {
                y = GenerateY(scale, x, z);
                if (y > 3)
                {
                    CreateDepth(stone, new Vector3(x, y, z), 3);
                }
                else
                {
                    CreateDepth(dirt, new Vector3(x, y, z), 3);
                }
            }
        }
    }

    void CreateBlock(GameObject pref, Vector3 position)
    {
        Instantiate(pref, position, Quaternion.identity);
    }

    void CreateDepth (GameObject pref, Vector3 position, int depth)
    {
        for (float y  = position.y; y < position.y + depth; y++)
        {
            var newPosition = new Vector3(position.x, y, position.z);
            CreateBlock(pref, newPosition);
        }
    }

    float GenerateY(float scale, float x, float z)
    {
        var y = scale * Mathf.PerlinNoise(x / 10f, z / 10f);
        y = Mathf.Round(y);
        return y;
    }
}
