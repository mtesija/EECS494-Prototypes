using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	private float vSpeed = 6;
	private float hSpeed = 6;
	private float jSpeed = 6;

	private float sensitivityX = 1;

	public bool grounded = true;

	void Start()
	{
	
	}

	void Update()
	{
		/*
		if(Input.GetMouseButton(1))
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			transform.eulerAngles = new Vector3(0, rotationX, 0);
		}
		*/

		float j = this.rigidbody.velocity.y;

		if(Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			j += jSpeed;
			grounded = false;
		}
		
		float h = Input.GetAxis("Horizontal") * hSpeed;
		float v = Input.GetAxis("Vertical") * vSpeed;

		this.rigidbody.velocity = new Vector3(h, j, v);
	}

	void OnTriggerEnter(Collider coll)
	{
		grounded = true;
	}
}
