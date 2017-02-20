using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public Agent agent;

    private void Start ( )
    {
        //InvokeRepeating ( "MoveCharAround", 1, 8 );
        agent.GoToWorkspace ( );
    }

    void MoveCharAround()
    {
        //agent.GoToPoint ( transform.position + Random.insideUnitSphere * 4 );
    }
}
