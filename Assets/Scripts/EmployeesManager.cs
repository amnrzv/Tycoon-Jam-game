using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesManager : MonoBehaviour
{
    private List<Worker> employees;

    void Awake()
    {
        employees = new List<Worker>();
    }

    void OnEnable()
    {
        EventsManager.EmployeeAdded += OnEmployeeAdded;
    }

    void OnDisable()
    {
        EventsManager.EmployeeAdded -= OnEmployeeAdded;
    }

    void OnEmployeeAdded(Worker worker)
    {
        employees.Add(worker);
    }

    void Update()
    {
        for(int i=0 ; i < employees.Count ; i++)
        {
            if(TimeManager.time > employees[i].DayStartTime && TimeManager.time < employees[i].DayEndTime)
                employees[i].gameObject.SetActive(true);
            else
                employees[i].gameObject.SetActive(false);
        }
    }
}
