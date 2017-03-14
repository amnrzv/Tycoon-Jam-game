using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : MonoBehaviour {

	public GameObject obj;

	public void toggle ()
	{

		if(obj.activeInHierarchy)
		{
			int index = obj.transform.GetSiblingIndex();
			if(index == obj.transform.parent.transform.childCount - 1)
			{
				obj.SetActive(false);
			}
			else
			{
				obj.transform.SetAsLastSibling();
			}
		}
		else
			obj.SetActive(true);
	}
}
