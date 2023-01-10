using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    float searchRadius;
    public HeatmapManager heatmap;
    public List<GameObject> allCubes;
    public float numCubes;
    Color color;

    void Start()
    {
        allCubes = heatmap.allCubes;
        searchRadius = heatmap.searchRadius;
        CheckNearbyCubes(searchRadius, allCubes);
    }

    void CheckNearbyCubes(float radius, List<GameObject> cubes)
    {
        foreach (GameObject cube in cubes)
        {
            if (cube == gameObject) continue; 

            float distance = Vector3.Distance(gameObject.transform.position, cube.transform.position);
            if (distance <= radius)
            {
                numCubes += 1;
            }
        }
        heatmap.CompareCubes();
    }
}
