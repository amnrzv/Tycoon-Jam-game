using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandOptions : MonoBehaviour {

	public GameObject menu;

	public void OnSelect()
	{
		if(menu.transform.localScale == new Vector3(1, 1, 1))
			menu.transform.localScale = new Vector3(0, 1, 1);
		else
			menu.transform.localScale = new Vector3(1, 1, 1);
	}
}
