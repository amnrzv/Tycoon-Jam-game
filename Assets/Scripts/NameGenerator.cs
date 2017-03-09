using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour {

	public List<string> maleName;
	public List<string> femaleName;
	public List<string> lastName;

	void Start () 
	{
		TextAsset namesResource = Resources.Load<TextAsset>("Names");
		string[] namesInText = namesResource.text.Split("\n"[0]);
		int nameCategory = 0;

		foreach(string currentName in namesInText)
		{
			if(currentName.Contains("-"))
				nameCategory++;
			else
			{
				switch(nameCategory)
				{
					case 0:
						maleName.Add(currentName);
						break;
					case 1:
						femaleName.Add(currentName);
						break;
					case 2:
						lastName.Add(currentName);
						break;
				}
			}
		}
	}
}
