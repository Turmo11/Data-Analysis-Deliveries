using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpData : SpatialData
{
    public JumpData(Vector3 s_pos/*, float s_timestamp*/) : base(s_pos/*, float s_timestamp*/)
    {
        this.phpUrl = "/insertjump.php";
        this.SetUrl();
    }

}