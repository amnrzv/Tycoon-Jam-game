using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager
{
    public static event Action<Worker> EmployeeAdded;
    public static event Action<Worker> EmployeeSelected;

    public static void OnEmployeeSelected(Worker employee)
    {
        EmployeeSelected.SafeInvoke ( employee );
    }

    public static void OnEmployeeAdded ( Worker employee )
    {
        EmployeeSelected.SafeInvoke ( employee );
    }
}
