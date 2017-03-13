using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepCurve
{
    private static RepCurve _instance;
    public static RepCurve Instance
    {
        get
        {
            if ( _instance == null )
                _instance = new RepCurve ( );
            return _instance;
        }
    }

    private float curveConstant = 0.1f;

    public uint GetLevelForRep(uint rep)
    {
        return (uint)Mathf.FloorToInt ( curveConstant * Mathf.Sqrt ( rep ) );
    }

    public uint GetRepToReachNextLevel(uint level)
    {
        return (uint)Mathf.FloorToInt ( Mathf.Pow ( (level) / curveConstant, 2 ) );
    }
}
