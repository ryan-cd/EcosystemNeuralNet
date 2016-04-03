using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    private World world = null;
    private Draw draw = null;
    private Parameters parameters = null;
	// Use this for initialization
	void Start () {
        world = gameObject.AddComponent<World>();
        draw = gameObject.AddComponent<Draw>();
        parameters = gameObject.AddComponent<Parameters>();

        world.initialize();
        draw.draw();
        Debug.Log("hello");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
