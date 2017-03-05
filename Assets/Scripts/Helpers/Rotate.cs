using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Range(0,1)]
    public float rotationSpeed;

    // Update is called once per frame
    Vector3 eulerAngles;
	void Update ()
    {
        eulerAngles = transform.rotation.eulerAngles;
        eulerAngles += Vector3.up * rotationSpeed * Time.timeScale;
        transform.rotation = Quaternion.Euler(eulerAngles);
	}
}
