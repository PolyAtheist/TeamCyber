using UnityEngine;
using System.Collections;

public class myNodeScript : MonoBehaviour {

    public GameObject ass;
    public GameScript handler;

    public int army;
    public int team;
    public SpriteRenderer color;
    bool selected;
    TextMesh text;

	// Use this for initialization
	void Start () {
        text = ass.GetComponent<TextMesh>();
        handler = Camera.main.GetComponent<GameScript>();
        color = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = army.ToString();
	}

    void OnMouseDown() {
        handler.clicked(this);
    }

    
}
