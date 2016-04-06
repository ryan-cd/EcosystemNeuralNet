using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Draw : MonoBehaviour {
    private List<GameObject> foodList;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initialize()
    {
        foodList = new List<GameObject>(Parameters.numFood);
    }

    public void draw()
    {
        if(foodList == null)
        {
            foodList = new List<GameObject>(Parameters.numFood);
        }

        for (int i = 0; i < Parameters.numFood; i++)
        {
            if (foodList.Count <= i)
            {
                GameObject foodGO = new GameObject("food" + i);
                foodGO.AddComponent<SpriteRenderer>();
                foodGO.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("food");
                foodGO.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 0);
                foodList.Add(foodGO);
            }
        }
    }

    public void flush()
    {
        for (int i = 0; i < Parameters.numFood; i++)
        {
            GameObject foodGO = GameObject.Find("Food" + i);
            Destroy(foodGO);
        }
    }
}
