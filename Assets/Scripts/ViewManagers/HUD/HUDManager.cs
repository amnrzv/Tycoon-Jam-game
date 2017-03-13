using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public ProjectOfferScreen projectOfferScreen;

    private static HUDManager _instance;
    public static HUDManager Instance
    {
        get
        {
            if ( _instance == null )
                _instance = FindObjectOfType<HUDManager> ( );
            return _instance;
        }
    }

    private void OnEnable ( )
    {
        EventsManager.OnShowProjectOffer += ShowProjectOffer;
    }

    private void OnDisable ( )
    {
        EventsManager.OnShowProjectOffer -= ShowProjectOffer;
    }

    public void ShowProjectOffer(Project project)
    {
        projectOfferScreen.OfferProject ( project );
    }
}
