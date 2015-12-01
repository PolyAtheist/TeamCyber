using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerScript : myNodeScript {

	private float spawnTimer = 1.0f;
	private float lastTime;
	
	// Use this for initialization
	void Start () {
		handler = Camera.main.GetComponent<GameScript> ();
		color = GetComponent<SpriteRenderer>();
		lastTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		texter.text = army.ToString();
		if (Time.realtimeSinceStartup - lastTime >= spawnTimer) {
			army+=1;
			lastTime = Time.realtimeSinceStartup;
		}
	}

	
	
}
