using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireEmployeesManager : MonoBehaviour
{
    [SerializeField]
    private List<Worker> employeesList;
    private static HireEmployeesManager _instance;

    public static HireEmployeesManager Instance
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
