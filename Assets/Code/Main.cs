using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    private World world = null;
    private Draw draw = null;

    // Use this for initialization
    void Start () {
        world = gameObject.AddComponent<World>();
        draw = gameObject.AddComponent<Draw>();

        world.initialize();
        draw.draw(world.getFood(), world.getEntities());
    }

    // Update is called once per frame
    void Update () {
        draw.draw(world.getFood(), world.getEntities());
    }
}
