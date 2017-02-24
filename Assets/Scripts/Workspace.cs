using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workspace : MonoBehaviour
{
    [HideInInspector]
    public Chair chair;
    [HideInInspector]
    public Computer computer;

    private Worker worker;

    private void Awake ( )
    {
        chair = GetComponentInChildren<Chair> ( );
        computer = GetComponentInChildren<Computer> ( );
    }

    public void SetWorker(Worker worker)
    {
        this.worker = worker;
    }

    public bool HasWorker()
    {
        return worker != null;
    }

    public Vector3 GetSeatingPosition ( )
    {
        return Vector3.Lerp ( chair.transform.position, computer.transform.position, 0.1f );
    }
}
