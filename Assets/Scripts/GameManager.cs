using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public List<Worker> workerPrefabs;
    public Transform spawnPoint;

    int i=0;
    private void OnMouseDown ( )
    {
        if ( workerPrefabs.Count == 0 )
            return;

        Worker newWorker = Instantiate(workerPrefabs[i++], spawnPoint.position, spawnPoint.rotation) as Worker;
        i = i % workerPrefabs.Count;
        newWorker.Spawn ( );
    }
}
