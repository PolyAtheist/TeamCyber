using UnityEngine;
using System.Collections;

public class UnitHandlerScript : MonoBehaviour
{

	ArrayList units;
	
	// Use this for initialization
	void Start ()
	{
		units = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	public void createUnit (GameObject nodeA, GameObject nodeB, float speed)
	{
        //check valid node
        if (nodeA.GetComponent<myNodeScript>().army > 0)
        {
            nodeA.GetComponent<myNodeScript>().army -= 1;
            // Set up the new sprite
            GameObject newUnit = new GameObject("unit");
            newUnit.AddComponent<SpriteRenderer>();
            newUnit.AddComponent<CircleCollider2D>();
            newUnit.GetComponent<CircleCollider2D>().radius = .14f;
            //newUnit.GetComponent<CircleCollider2D> ().isTrigger = true;
            newUnit.GetComponent<CircleCollider2D>().transform.position = nodeA.transform.position;
            newUnit.AddComponent<Rigidbody2D>();
            newUnit.GetComponent<Rigidbody2D>().gravityScale = 0;
            newUnit.AddComponent<UnitScript>();
            newUnit.GetComponent<UnitScript>().source = nodeA;
            newUnit.tag = nodeA.tag;
            Debug.Log(newUnit.GetComponent<CircleCollider2D>().transform.position);
            MoveToPoint mover = newUnit.AddComponent<MoveToPoint>();
            newUnit.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Units/BU");
            newUnit.transform.position = nodeA.transform.position;
            mover.speed = speed;
            mover.targetObject = nodeB;
            mover.useObjectAsTarget = true;
            mover.startMoving();
            units.Add(newUnit);
        }
	}
}