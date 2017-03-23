using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeListRow : MonoBehaviour {

	public Text rowName;
	public Text rowRole;

	public Text descriptionName;
	public Text descriptionRole;
	public Text descriptionRate;

	public Transform screen;

	Worker employee;

	public void Populate(Worker employee)
	{
		this.employee = employee;
		rowName.text = employee.employeeName;
		rowRole.text = employee.role.ToString();
	}

	public void OnSelect()
	{
		descriptionName.text = employee.employeeName;
		descriptionRole.text = employee.role.ToString();
		descriptionRate.text = employee.hourlyRate.ToString() + "/Hour";
		screen.GetComponent<EmployeeListView>().selectedEmployee = employee;
	}
}
