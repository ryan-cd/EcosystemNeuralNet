using UnityEngine;
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
        Debug.Log("entity" + id + " colliding with " + collider.gameObject);
    }

    public void setID(int id)
    {
        this.id = id;
    }
}
