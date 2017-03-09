using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HireEmployeeDescription : MonoBehaviour {
	static public Worker employee;
	public Text employeeName;
	public Text rate;
	public Text role;
	public Text gender;

	void Update()
	{
		if(EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.GetComponent<HireEmployeeRow>() != null)
		{
			transform.localScale = new Vector3(1,1,1);
//			employeeName.text = employee.employeeName;
//			rate.text = employee.hourlyRate.ToString();
//			role.text = employee.role.ToString();
			transform.SetSiblingIndex (EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex() + 1);
		}
		else
		{
			transform.localScale = new Vector3(1,0,1);
			transform.SetAsLastSibling();
		}
	}
}
