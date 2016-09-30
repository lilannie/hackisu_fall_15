using UnityEngine;
using System.Collections;

public class ExitOnClick : MonoBehaviour {

	public void ExitGame(){
		print ("exited");
		Application.Quit();
	}
}
