using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager
{
    public static event Action<Worker>EmployeeAdded;

    public static void OnEmployeeAdded(Worker worker)
    {
        EmployeeAdded.SafeInvoke (worker);
    }
}
