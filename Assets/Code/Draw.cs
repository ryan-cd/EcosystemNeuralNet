using UnityEngine;
using System.Collections;

public class Draw : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void draw()
    {
        Debug.Log("draw");
        for (int i = 0; i < Parameters.numFood; i++)
        {
            GameObject foodGO = GameObject.Find("food");
            if (foodGO == null)
            {
                Debug.Log("in loop");
                foodGO = new GameObject("food");
                foodGO.AddComponent<SpriteRenderer>();
                foodGO.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("food");
                foodGO.transform.position = new Vector3(0, 0, 0);
            }
        }
    }
}
