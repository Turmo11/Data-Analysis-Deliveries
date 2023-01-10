using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData : SpatialData
{
    public HitData(Vector3 s_pos/*, float s_timestamp*/) : base(s_pos/*, float s_timestamp*/)
    {
        this.phpUrl = "/inserthit.php";
        this.SetUrl();
    }

}
