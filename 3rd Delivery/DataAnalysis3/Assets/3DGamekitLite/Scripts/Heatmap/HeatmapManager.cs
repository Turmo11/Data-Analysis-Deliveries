using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;

//using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class HeatmapManager : MonoBehaviour
{

    enum HeatmapType
    {
        None,
        Path,
        Jump,
        Hits,
        Deaths
    }
    [SerializeField] HeatmapType type;

    private EventHandler ev;

    public List<GameObject> allCubes;
    public float searchRadius = 2.0f;
    public float maxSearchRadius = 10.0f;
    public GameObject heatmapPointPrefab;
    public Gradient gradient;
    Color startColor = Color.green;
    Color endColor = Color.red;
    private float pathMax = 0;
    private float jumpMax = 0;
    private float hitMax = 0;
    private float deathMax = 0;
    public float max = 0;
    CubeCollision cube;

    

    void Start()
    {
        ev = FindObjectOfType<EventHandler>();
        type = HeatmapType.Path;
    }

    void OptionSelected()
    {
        if (type == HeatmapType.Path)
        {
            DestroyCurrentHeatmap();
            max = pathMax;
            GenerateHeatmap(ev.pathPositionList);
        }
        if (type == HeatmapType.Jump)
        {
            DestroyCurrentHeatmap();
            max = jumpMax;
            GenerateHeatmap(ev.jumpPositionList);
        }
        if (type == HeatmapType.Hits)
        {
            DestroyCurrentHeatmap();
            max = hitMax;
            GenerateHeatmap(ev.hitPositionList);
        }
        if (type == HeatmapType.Deaths)
        {
            DestroyCurrentHeatmap();
            max = deathMax;
            GenerateHeatmap(ev.deathPositionList);
        }
        if (type == HeatmapType.None)
        {
            DestroyCurrentHeatmap();
        }

    }

    void OnValidate()
    {
        OptionSelected();
    }


    void GenerateHeatmap(List<Vector3> positions)
    {
        foreach (Vector3 position in positions)
        {
            GameObject heatmapPoint = Instantiate(heatmapPointPrefab, new Vector3(position.x, position.y, position.z), Quaternion.identity, transform);
            allCubes.Add(heatmapPoint);
        }
    }

    void DestroyCurrentHeatmap()
    {
        if (allCubes.Count > 0)
        {
            for (int i = 0; i < allCubes.Count; i++)
            {
                GameObject cube = allCubes[i];
                Destroy(cube);
            }
            allCubes.Clear();
        }
    }

    public void CompareCubes()
    {
        foreach (GameObject go in allCubes)
        {

            CubeCollision script = go.GetComponent<CubeCollision>();
            if (script.numCubes > max)
            {
                max = script.numCubes;
            }


        }

        if(max == 0)
        {
            max = 1;
        }

        ColorCubes();
    }

    public void ColorCubes()
    {
        foreach (GameObject go in allCubes)
        {
            CubeCollision script = go.GetComponent<CubeCollision>();
            float percentage = (script.numCubes / max);
            Color color = gradient.Evaluate(percentage);
            script.GetComponent<Renderer>().material.color = color;
        }
    }
}

#if UNITY_EDITOR


#endif
