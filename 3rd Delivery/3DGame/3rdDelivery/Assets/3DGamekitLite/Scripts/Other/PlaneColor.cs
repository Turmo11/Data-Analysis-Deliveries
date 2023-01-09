using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColor : MonoBehaviour
{
    private MeshRenderer p_mesh_r;
    private Color colorStart;
    private Color colorEnd;
    public float duration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        p_mesh_r = GetComponent<MeshRenderer>();
        colorStart = Color.red;
        colorEnd = Color.green;
        p_mesh_r.material.color = colorStart;

    }

    private void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        p_mesh_r.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }

}
