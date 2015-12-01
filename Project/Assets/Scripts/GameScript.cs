using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{

	public myNodeScript selected;
	public UnitHandlerScript handler;
	Color[] teamColor = new Color[2];

	// Use this for initialization
	void Start ()
	{
		teamColor [0] = Color.white;
		teamColor [1] = Color.red;
		handler = GetComponent<UnitHandlerScript> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void clicked (myNodeScript clicker)
	{
		if (clicker.gameObject.tag == "Enemy") {

			//enemy node
			if (selected != null) {
				//Spawn unit
				handler.createUnit (selected.gameObject, clicker.gameObject, 0.02f);
				//fight (clicker);
                selected.color.color = Color.white;
			}
		} else if (selected == null) {
			//no node selected
			selected = clicker;
			clicker.color.color = Color.blue;
			return;
		} else if (clicker.Equals (selected)) {
			//clicked already selected node

			clicker.color.color = Color.white;
		} else if (clicker.gameObject.tag == selected.gameObject.tag) {
			//Spawn unit
			handler.createUnit (selected.gameObject, clicker.gameObject, 0.02f);
			//clicked ally node
			//clicker.army += selected.army;
			//selected.army = 0;
			selected.color.color = Color.white;

		} else {
			//Spawn unit
			handler.createUnit (selected.gameObject, clicker.gameObject, 0.02f);
			//clicked enemy node
			//fight (clicker);
            selected.color.color = Color.white;
		}
		selected = null;
	}

	public void fight (myNodeScript clicker)
	{
		if (clicker.army - selected.army < 0) {
			//conquered
			clicker.army = selected.army - clicker.army;
			clicker.gameObject.tag = selected.gameObject.tag;
			clicker.color.color = Color.white;
			selected.army = 0;
			selected.color.color = Color.white;
		} else {
			//fought but not conquered
			clicker.army -= selected.army;
			selected.army = 0;
			selected.color.color = Color.white;

		}
	}
}
