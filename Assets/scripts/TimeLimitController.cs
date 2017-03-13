using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimitController : MonoBehaviour {

	public int timeleft = 60;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("count", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void count(){
		GameObject.Find ("timeLeftValue").GetComponent<Text> ().text = timeleft.ToString ();
		if (timeleft > 0) {
			timeleft--;
		} else {
			//Application.LoadLevel ("");

		}
	}
}
