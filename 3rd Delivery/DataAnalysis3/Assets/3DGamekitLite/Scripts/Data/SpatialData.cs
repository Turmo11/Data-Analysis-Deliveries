using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialData : MonoBehaviour
{
    private Vector3 position;
    //private float timestamp;
    private string baseUrl = "citmalumnes.upc.es/~guillemtg1";
    protected string phpUrl;
    protected string url;
    protected string dataUrl;

    public SpatialData(Vector3 s_pos/*, float s_timestamp*/)
    {
        this.position.x = s_pos.x;
        this.position.y = s_pos.y;
        this.position.z = s_pos.z;

        //this.timestamp = s_timestamp;

        this.dataUrl = "?x=" + position.x.ToString() + "&y=" + position.y.ToString() + "&z=" + position.z.ToString()/* + "&timestamp=" + timestamp.ToString()*/; //PHP friendly string

        // this.url = baseUrl + phpUrl + dataUrl;
    }

    public string GetUrl()
    {
        return url;
    }

    public void SetUrl()
    {
        this.url = baseUrl + phpUrl + dataUrl;
    }

}
