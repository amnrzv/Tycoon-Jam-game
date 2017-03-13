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
        EventsManager.OnEmployeeAdded += OnEmployeeAdded;
    }

    void OnDisable()
    {
        EventsManager.OnEmployeeAdded -= OnEmployeeAdded;
    }

    void OnEmployeeAdded(Worker worker)
    {
        employees.Add(worker);
    }
}
