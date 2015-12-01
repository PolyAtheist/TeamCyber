using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {

    public GameObject source;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == gameObject.tag)
        {
            if (coll.gameObject.GetComponent<UnitScript>() != null)
            {
                if (coll.gameObject.GetComponent<UnitScript>().source.Equals(source))
                {
                    gameObject.GetComponent<MoveToPoint>().isMoving = false;
                }
                else
                {
                    Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.collider);
                }
            }
        }
        else
        {
           //battle
            //TODO
        }

    }
    void OnCollisionStay2D(Collision2D coll)
    {


    }
    void OnCollisionExit2D(Collision2D coll)
    {
        gameObject.GetComponent<MoveToPoint>().isMoving = true;
    }
}
