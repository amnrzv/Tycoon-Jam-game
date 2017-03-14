using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLayer : MonoBehaviour {
	public GameObject panel;


	void OnEnable () 
	{
		transform.SetAsLastSibling();
		transform.localPosition = new Vector2(0, 0);
		if(!panel.activeInHierarchy)
		{
			panel.SetActive(true);
		}
	}
	void OnDisable () 
	{
		transform.SetAsFirstSibling();
		int activeScreens = 0;
		int numChildren = transform.parent.transform.childCount;
		for(int i = 0; i < numChildren; i ++)
		{
			if(transform.parent.transform.GetChild(i).gameObject.activeInHierarchy && transform.parent.transform.GetChild(i) != gameObject)
			{
				activeScreens ++;
			}
		}
		if(activeScreens == 0)
		{
			panel.SetActive(false);
		}
	}
}
