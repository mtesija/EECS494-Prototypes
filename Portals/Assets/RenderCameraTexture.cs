using UnityEngine;
using System.Collections;

public class RenderCameraTexture : MonoBehaviour 
{
	Camera cam;

	void Update()
	{
		StartCoroutine(Capture());
	}

	private IEnumerator Capture()
	{
		yield return new WaitForEndOfFrame();

		Texture2D image = new Texture2D(Screen.width, Screen.height);

		image.ReadPixels(new Rect(Screen.width, Screen.height), 0, 0, false);

		image.Apply();

		renderer.material.mainTexture = image;

		yield break;
	}
}
