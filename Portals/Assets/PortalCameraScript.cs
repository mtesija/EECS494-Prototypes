using UnityEngine;
using System.Collections;

public class PortalCameraScript : MonoBehaviour
{
	private GameObject mainCam;
	public GameObject enterPortal;
	public GameObject exitPortal;
	
	void Start()
	{
		mainCam = GameObject.Find("Main Camera");
	}

	void LateUpdate()
	{
		float yPos = enterPortal.transform.position.y - exitPortal.transform.position.y + mainCam.transform.position.y;
		Vector3 position = this.transform.position;
		position.y = yPos;
		this.transform.position = position;

		Vector3 result = mainCam.transform.forward + enterPortal.transform.up + exitPortal.transform.up;
		result.Normalize();
		this.transform.forward = result;
	}
}
