using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManagerScript : MonoBehaviour
{
	private bool open = false;

	private List<GameObject> inventoryArray;

	private Rect window;
	private Vector2 scrollPosition;
	
	void Start()
	{
		//Define intial size of window
		window = new Rect(Screen.width / 8, Screen.height / 8, 400, 600);
		inventoryArray = new List<GameObject>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			if(open)
			{
				open = false;
			}
			else
			{
				open = true;
			}
		}
	}

	void OnGUI()
	{
		if(open)
		{
			GUILayout.Window(0, window, windowDisplay, "Inventory");
		}
	}

	void windowDisplay(int windowID)
	{
		scrollPosition = GUILayout.BeginScrollView(scrollPosition);








		GUILayout.EndScrollView();
	}
}
