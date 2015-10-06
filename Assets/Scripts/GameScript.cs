using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{

    public myNodeScript selected;
    Color[] teamColor = new Color[2];

    // Use this for initialization
    void Start()
    {
        teamColor[0] = Color.white;
        teamColor[1] = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clicked(myNodeScript clicker)
    {
        if(clicker.team == 1)
        {
            //enemy node
            fight(clicker);

        }
        else if (selected == null)
        {
            //no node selected
            selected = clicker;
            clicker.color.color = Color.blue;
        }
        else if (clicker.Equals(selected))
        {
            //clicked already selected node
            selected = null;
            clicker.color.color = Color.white;
        }
        else if (clicker.team == selected.team)
        {
            //clicked ally node
            clicker.army += selected.army;
            selected.army = 0;
            selected.color.color = Color.white;
            selected = null;
        }
        else
        {
            //clicked enemy node
            fight(clicker);
            

        }
    }
    public void fight(myNodeScript clicker)
    {
        if (selected == null)
        {
            return;
        } 
        else if (clicker.army - selected.army < 0)
        {
            //conquered
            clicker.army = selected.army - clicker.army;
            clicker.team = selected.team;
            clicker.color.color = Color.white;
            selected.army = 0;
            selected.color.color = Color.white;
            selected = null;
        }
        else
        {
            //fought but not conquered
            clicker.army -= selected.army;
            selected.army = 0;
            selected.color.color = Color.white;
            selected = null;

        }

    }
}
