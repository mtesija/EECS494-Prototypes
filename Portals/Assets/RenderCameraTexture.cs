using UnityEngine;
using System.Collections;

public class RenderCameraTexture : MonoBehaviour 
{
	public Camera cam;
	private GameObject mainCam;

	void Start()
	{
		mainCam = GameObject.Find("Main Camera");
	}

	void Update()
	{
		StartCoroutine(Capture());
	}

	private IEnumerator Capture()
	{
		yield return new WaitForEndOfFrame();

		cam.Render();

		Texture2D image = new Texture2D(Screen.width, Screen.height);

		image.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);

		image.Apply();

		renderer.material.mainTexture = image;

		mainCam.camera.Render();

		yield break;
	}
}
