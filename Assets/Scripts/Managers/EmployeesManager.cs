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
}
