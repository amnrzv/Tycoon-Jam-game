using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireEmployeeDescription : MonoBehaviour {
	GameObject descriptionScreen;
	static public Worker employee;
	public Text employeeName;
	public Text rate;
	public Text role;
	public Text gender;

	void Start()
	{
		descriptionScreen = transform.GetChild(0).gameObject;
	}

	void Update()
	{
		if(employee != null)
		{
			descriptionScreen.SetActive(true);
			employeeName.text = employee.employeeName;
			rate.text = employee.hourlyRate.ToString();
			role.text = employee.role.ToString();
		}
		else
			descriptionScreen.SetActive(false);
	}
}
