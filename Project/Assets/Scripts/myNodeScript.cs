using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class myNodeScript : MonoBehaviour
{

	public TextMesh texter;
	public GameScript handler;
	public int army;
	public int team;
	public SpriteRenderer color;
	bool selected;

	// Use this for initialization
	void Start ()
	{
		handler = Camera.main.GetComponent<GameScript> ();
		color = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		texter.text = army.ToString ();
	}

	void OnMouseDown ()
	{
		handler.clicked (this);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
        if (coll.gameObject.GetComponent<MoveToPoint>().targetObject.Equals(gameObject))
        {
            if (coll.gameObject.tag == gameObject.tag)
            {
                army += 1;
            }
            else
            {
                army -= 1;
            }
            Destroy(coll.gameObject);
            if (army <= 0)
            {
                gameObject.tag = coll.gameObject.tag;
            }
        }
        else
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.collider);
        }

	}

    
}
