using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float deltaX = 0;
		float deltaY = 0;

		if(Input.GetKey(KeyCode.W))
			deltaX += -.1f;
		if(Input.GetKey(KeyCode.S))
			deltaX += .1f;
		if(Input.GetKey(KeyCode.D))
			deltaY += -.1f;
		if(Input.GetKey(KeyCode.A))
			deltaY += .1f;


		Vector3 pos = this.transform.position;
		pos.z += deltaX;
		pos.x += deltaY;
		this.transform.position = pos;
	}
}
