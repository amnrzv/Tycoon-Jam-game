using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public Transform spawnPoint;

    [Range(100, 5000)]
    [SerializeField]
    private int startingAmount;

    private void Start ( )
    {
        Init ( );
    }

    public void Init()
    {
        _instance = this;
        GameDataManager.Instance.AddMoney ( (uint)startingAmount );
    }
}
