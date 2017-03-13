using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDStats : MonoBehaviour
{
    public Text money;
    public Text rep;
    public Text level;
    public Image repBar;

    private void OnEnable ( )
    {
        EventsManager.OnUpdateStats += EventsManager_UpdateStats;
    }

    private void OnDisable ( )
    {
        EventsManager.OnUpdateStats -= EventsManager_UpdateStats;
    }

    private void EventsManager_UpdateStats ( )
    {
        uint repLevel = GameDataManager.Instance.Level;

        money.text = string.Format ( "Money : {0}", GameDataManager.Instance.Money );
        rep.text = string.Format ( "{0}/{1}", GameDataManager.Instance.Rep, RepCurve.Instance.GetRepToReachNextLevel ( repLevel ) );
        level.text = repLevel.ToString ( );
        repBar.fillAmount = ( GameDataManager.Instance.Rep - RepCurve.Instance.GetRepToReachNextLevel ( repLevel - 1 ) ) / ( float ) (RepCurve.Instance.GetRepToReachNextLevel ( repLevel ) - RepCurve.Instance.GetRepToReachNextLevel ( repLevel - 1 ) );
    }
}
