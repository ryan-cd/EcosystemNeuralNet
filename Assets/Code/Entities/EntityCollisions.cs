using UnityEngine;
using System;
using System.Collections;

public class EntityCollisions : MonoBehaviour {
    int id;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("entity" + id + " colliding with " + collider.gameObject.name);
        if(collider.gameObject.name.Substring(0,4) == "food")
        {
            int foodID = Int32.Parse(collider.gameObject.name.Substring(4));
            World.collide(id, foodID);
        }
    }

    public void setID(int id)
    {
        this.id = id;
    }
}
