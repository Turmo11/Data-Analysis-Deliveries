using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillData : SpatialData
{
    public KillData(Vector3 s_pos/*, float s_timestamp*/) : base(s_pos/*, float s_timestamp*/)
    {
        this.phpUrl = "/kill.php";
        this.SetUrl();
    }

}
