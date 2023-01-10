using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionData : SpatialData
{
    public PositionData(Vector3 s_pos/*, float s_timestamp*/) : base(s_pos/*, float s_timestamp*/)
    {
        this.phpUrl = "/insertposition.php";
        this.SetUrl();
    }

}
