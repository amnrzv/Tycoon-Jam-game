using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesToHireManager : MonoBehaviour
{
    [SerializeField]
    private List<Worker> employeesList;
    private static EmployeesToHireManager _instance;

    public static EmployeesToHireManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public List<Worker> GetHiringEmployeesList()
    {
        return employeesList;
    }

    private void Awake ( )
    {
        _instance = this;
    }
}
