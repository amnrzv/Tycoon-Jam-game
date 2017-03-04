using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireEmployeesView : MonoBehaviour
{
    public HireEmployeeRow rowPrefab;
    public Transform rowParent;

    private Worker currentSelectedEmployee;

    private void OnEnable ( )
    {
        EventsManager.EmployeeSelected += UpdateCurrentSelected;
    }

    private void OnDisable ( )
    {
        EventsManager.EmployeeSelected -= UpdateCurrentSelected;
    }

    private void Awake ( )
    {
        Populate ( );
    }

    void Populate()
    {
        List<Worker> hiringEmployees = HireEmployeesManager.Instance.GetHiringEmployeesList ( );
        int length = hiringEmployees.Count;

        for ( int i = 0 ; i < length ; i++ )
        {
            HireEmployeeRow newRow = Instantiate(rowPrefab, rowParent, false);
            newRow.Populate ( hiringEmployees [ i ] );
            newRow.gameObject.SetActive ( true );
        }
    }

    public void UpdateCurrentSelected(Worker employee)
    {
        currentSelectedEmployee = employee;
    }

    public void HireSelected()
    {
        Worker newWorker = Instantiate(currentSelectedEmployee, GameManager.Instance.spawnPoint.position + UnityEngine.Random.insideUnitSphere, GameManager.Instance.spawnPoint.rotation) as Worker;
        EventsManager.OnEmployeeAdded ( newWorker );
        newWorker.Spawn ( );
    }
}
