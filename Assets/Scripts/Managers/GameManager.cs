using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public List<Worker> workerPrefabs;
    public Transform spawnPoint;
    public static GameManager Instance { get { return _instance; } }

    int i=0;

    private void Awake ( )
    {
        _instance = this;
    }

    /*/
    private void OnMouseDown ( )
    {
        if ( workerPrefabs.Count == 0 )
            return;

        Worker newWorker = Instantiate(workerPrefabs[i++], spawnPoint.position + UnityEngine.Random.insideUnitSphere, spawnPoint.rotation) as Worker;
        i = i % workerPrefabs.Count;
        EventsManager.OnEmployeeAdded(newWorker);
        newWorker.Spawn ( );
    }
    //*/
}
