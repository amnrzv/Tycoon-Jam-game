using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

	public Transform minuteHand;
	public Transform hourHand;
	private IEnumerator coroutine;
	void Start () 
	{
		coroutine = Wait(1);
		StartCoroutine(coroutine);
	}

	IEnumerator Wait (int wait) 
	{
		while(true)
		{
			yield return new WaitForSeconds(wait);
			minuteHand.transform.localEulerAngles = new Vector3(0, 0, TimeManager.Instance.GetCurrentTimeRef().minutes * 6);
			hourHand.transform.localEulerAngles = new Vector3(0, 0, TimeManager.Instance.GetCurrentTimeRef().hours * 30);
		}
	}
}
