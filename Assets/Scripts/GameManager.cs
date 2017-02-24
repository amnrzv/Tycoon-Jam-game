using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public List<Agent> agents;
    public Worker workerPrefab;
    public Transform spawnPoint;

    private void OnMouseDown ( )
    {
        Worker newWorker = Instantiate(workerPrefab, spawnPoint.position, spawnPoint.rotation) as Worker;
        newWorker.Spawn ( );
    }
}
