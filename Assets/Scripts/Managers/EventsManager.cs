using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager
{
    public static event Action<Worker> OnEmployeeAdded;
    public static event Action<Worker> OnEmployeeSelected;
    public static event Action OnUpdateStats;
    public static event Action<Project> OnShowProjectOffer;
    public static event Action<Project> OnAcceptProject;

    public static void EmployeeSelected(Worker employee)
    {
        OnEmployeeSelected.SafeInvoke ( employee );
    }

    public static void EmployeeAdded ( Worker employee )
    {
        OnEmployeeAdded.SafeInvoke ( employee );
    }

    public static void UpdateStats()
    {
        OnUpdateStats.SafeInvoke ( );
    }

    public static void ShowProjectOffer(Project project)
    {
        OnShowProjectOffer.SafeInvoke ( project );
    }

    public static void AcceptProject(Project project)
    {
        OnAcceptProject.SafeInvoke ( project );
    }
}
