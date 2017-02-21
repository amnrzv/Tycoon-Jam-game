using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workspace : MonoBehaviour
{
    [HideInInspector]
    public Chair chair;
    [HideInInspector]
    public Computer computer;

    private void Awake ( )
    {
        chair = GetComponentInChildren<Chair> ( );
        computer = GetComponentInChildren<Computer> ( );
    }
}
