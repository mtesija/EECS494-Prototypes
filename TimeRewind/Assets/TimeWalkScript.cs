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
	}

	//The array of all time events
	List<frameData> timeline;

	//The object that is timetraveling
	private GameObject parentObject;

	//The amount of frames between recorded time events
	private int frameDelay = 0;
	private int frameCounter = 0;

	void Start()
	{
		parentObject = this.transform.parent.gameObject;
		timeline = new List<frameData>();
		recordTime();
	}

	void Update()
	{
		if(frameCounter >= frameDelay)
		{
			if(Input.GetKey(KeyCode.LeftShift))
			{
				timeTravel();
			}
			else
			{
				recordTime();
			}

			frameCounter = 0;
		}

		frameCounter++;
	}

	void timeTravel()
	{
		if(timeline.Count == 1)
		{
			return;
		}

		parentObject.GetComponent<PlayerScript>().enabled = false;

		frameData timeFrame = timeline[timeline.Count - 1];

		parentObject.transform.position = timeFrame.position;
		parentObject.rigidbody.velocity = timeFrame.velocity;
		parentObject.transform.rotation = timeFrame.rotation;

		timeline.RemoveAt(timeline.Count - 1);
	}

	void recordTime()
	{
		parentObject.GetComponent<PlayerScript>().enabled = true;

		frameData timeFrame = new frameData();

		timeFrame.position = parentObject.transform.position;
		timeFrame.velocity = parentObject.rigidbody.velocity;
		timeFrame.rotation = parentObject.transform.rotation;

		timeline.Add(timeFrame);
	}
}
