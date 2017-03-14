using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeListView : MonoBehaviour {

	List<Worker> employees = new List<Worker>();
	List<GameObject> rowClones  = new List<GameObject>();

	public GameObject manager;

	public GameObject rowPrefab;
	public Transform rowParent;


	void OnEnable () 
	{
		Populate();
	}

	void Populate()
	{
		employees.Clear();
		foreach(Worker newWorker in manager.GetComponent<EmployeesManager>().employees)
		{
			employees.Add(newWorker);
		}
		foreach(GameObject clone in rowClones)
		{
			Destroy(clone);
		}
		rowClones.Clear();
		int length = employees.Count;

		for ( int i = 0; i < length; i++)
		{
			GameObject newRow = Instantiate(rowPrefab, rowParent, false);
			rowClones.Add(newRow);
			newRow.GetComponent<EmployeeListRow>().Populate(employees[i]);
			newRow.gameObject.SetActive(true);
		}
	}
}
