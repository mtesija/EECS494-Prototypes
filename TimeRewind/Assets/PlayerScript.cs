using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	private float vSpeed = 15;
	private float hSpeed = 15;
	private float jSpeed = 5;

	private float sensitivityX = 1;

	private bool grounded = true;

	void Start()
	{
	
	}

	void Update()
	{
		if(Input.GetMouseButton(1))
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			transform.eulerAngles = new Vector3(0, rotationX, 0);
		}

		float j = 0;

		if(Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			j = jSpeed;
		}
		else
		{
			j = this.rigidbody.velocity.y;
		}
		
		float h = Input.GetAxis("Horizontal") * hSpeed;
		float v = Input.GetAxis("Vertical") * vSpeed;

		this.rigidbody.velocity = new Vector3(h, j, v);
	}
}
