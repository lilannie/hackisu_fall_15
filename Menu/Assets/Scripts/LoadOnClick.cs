using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	public GameObject loadingImage;

	public void LoadScene()
	{
		loadingImage.SetActive (true);
		Application.LoadLevel (1);
	}
}
