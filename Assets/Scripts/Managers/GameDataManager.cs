using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    private uint money;
    private uint rep;
    private uint level = 1;
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
    public uint Level { get { return level; } }

    public void AddMoney(uint money)
    {
        this.money += money;
        EventsManager.UpdateStats ( );
    }

    public void ConsumeMoney(uint money)
    {
        this.money -= money;
        EventsManager.UpdateStats ( );
    }

    public void IncreaseRep ( uint rep )
    {
        this.rep += rep;
        level = 1+RepCurve.Instance.GetLevelForRep ( this.rep );
        EventsManager.UpdateStats ( );
    }

    public void DecreaseRep ( uint rep )
    {
        this.rep -= rep;
        EventsManager.UpdateStats ( );
    }
}
