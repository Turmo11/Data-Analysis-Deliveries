using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathData : SpatialData
{
    public DeathData(Vector3 s_pos/*, float s_timestamp*/) : base(s_pos/*, float s_timestamp*/)
    {
        this.phpUrl = "/death.php";
        this.SetUrl();
    }

}
