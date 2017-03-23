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
	public GameObject lastSelected;

	void Start ()
	{
		transform.localScale = new Vector3(1,0,1);
		transform.SetAsLastSibling();
	}

	public void RowSelected()
	{
		if(EventSystem.current.currentSelectedGameObject != lastSelected)
		{
			Enable();
		}
		else
		{
			if(transform.localScale == new Vector3(1,1,1))
				Disable();
			else
				Enable();
		}
		lastSelected = EventSystem.current.currentSelectedGameObject;
	}

	void Enable()
	{
		transform.localScale = new Vector3(1,1,1);
		employeeName.text = employee.employeeName;
		rate.text = employee.hourlyRate.ToString() + "/hr";
		role.text = employee.role.ToString();
		transform.SetSiblingIndex (EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex() + 1);
	}

	void Disable()
	{
		transform.localScale = new Vector3(1,0,1);
		transform.SetAsLastSibling();
	}
}
