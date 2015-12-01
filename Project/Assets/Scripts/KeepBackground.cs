using UnityEngine;
using System.Collections;

public class KeepBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
