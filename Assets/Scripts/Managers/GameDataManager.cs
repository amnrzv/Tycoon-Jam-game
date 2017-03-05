using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private uint money;
    private uint rep;
    private static GameDataManager _instance;

    public static GameDataManager Instance
    {
        get
        {
            if ( _instance == null )
                _instance = new GameDataManager ( );
            return _instance;
        }
    }

    public uint Money { get { return money;} }
    public uint Rep { get { return rep; } }

    GameDataManager()
    {
        money = 0;
        rep = 0;
    }
}
