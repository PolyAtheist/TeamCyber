using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
    public float scrollSpeed;

    private RectTransform image;
	private float scrollSize;
    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
		image = gameObject.GetComponent<RectTransform>();
		scrollSize = image.rect.width;
	}
	void Awake() {
		//DontDestroyOnLoad(transform.gameObject);

		//if(FindObjectsOfType(GetType()).Length > 4){
		//	Destroy(gameObject);
		//}
	}

	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed , scrollSize);
        transform.position = startPosition + (Vector3.right * newPosition);
	}
}
