using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeWalkScript : MonoBehaviour 
{
	//Holds all variables needed to define the parent 
	//gameObject at any given point in time
	private struct frameData
	{
		public Vector3 position;
		public Vector3 velocity;
		public Quaternion rotation;
		public bool grounded;
	}

	//The array of all time events
	List<frameData> timeline;
	
	private int currentTime = -1;

	private int timeDirection = 0;

	private bool timetraveling = false;
	
	//The object that is timetraveling
	private GameObject parentObject;

	void Start()
	{
		parentObject = this.transform.parent.gameObject;
		timeline = new List<frameData>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			Time.timeScale = 1;
			parentObject.GetComponent<PlayerScript>().enabled = false;
			timetraveling = true;
		}
		
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			parentObject.GetComponent<PlayerScript>().enabled = true;
			Time.timeScale = 1;
			timeDirection = 0;
			timetraveling = false;
			destroyFuture();
		}
		
		if(Input.GetKeyDown(KeyCode.Q))
		{
			Time.timeScale = 1;
			timeDirection = -1;
		}
		
		if(Input.GetKeyDown(KeyCode.E))
		{
			Time.timeScale = 1;
			timeDirection = 1;
		}
	}

	void FixedUpdate()
	{
		if(timetraveling)
		{
			timeTravel();
		}
		else
		{
			recordTime();
		}
	}

	void destroyFuture()
	{
		if(currentTime != timeline.Count - 1)
		{
			timeline.RemoveRange(currentTime + 1, timeline.Count - currentTime - 1);
		}
	}

	void timeTravel()
	{
		if(currentTime == 0 && timeDirection == -1 || currentTime == timeline.Count - 1 && timeDirection == 1)
		{
			Time.timeScale = 0;
			return;
		}

		frameData timeFrame = timeline[currentTime];

		parentObject.transform.position = timeFrame.position;
		parentObject.rigidbody.velocity = timeFrame.velocity;
		parentObject.transform.rotation = timeFrame.rotation;
		parentObject.GetComponent<PlayerScript>().grounded = timeFrame.grounded;

		currentTime += timeDirection;
	}

	void recordTime()
	{
		frameData timeFrame = new frameData();

		timeFrame.position = parentObject.transform.position;
		timeFrame.velocity = parentObject.rigidbody.velocity;
		timeFrame.rotation = parentObject.transform.rotation;
		timeFrame.grounded = parentObject.GetComponent<PlayerScript>().grounded;

		timeline.Add(timeFrame);
		currentTime++;
	}
}
