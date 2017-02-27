using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager
{
    public static event Action UpdateHUDTimeViewEvent;

    public static void UpdateHUDTimeView()
    {
        UpdateHUDTimeViewEvent.SafeInvoke ( );
    }
}
