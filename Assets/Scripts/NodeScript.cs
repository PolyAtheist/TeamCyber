using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NodeScript : MonoBehaviour {
    int army;
    Text armyvalue;
	// Use this for initialization
	void Start () {
        army =100;
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
	
	}
    void OnMouseDown()
    {

    }
    void OnGUI()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        GUI.Label(new Rect(x, y, Screen.width, Screen.height), army.ToString());
    }
}
