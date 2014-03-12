using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{
	private GameObject mainCam;
	public GameObject enterPortal;
	public GameObject exitPortal;
	
	void Start()
	{
		mainCam = GameObject.Find("Main Camera");
	}

	void Update()
	{
		Vector3 result = mainCam.transform.forward + enterPortal.transform.up;
		result.Normalize();
		result = exitPortal.transform.up + result;
		result.Normalize();

		this.transform.eulerAngles = result;
	}
}
