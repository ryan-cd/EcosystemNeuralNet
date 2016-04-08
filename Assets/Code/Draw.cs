using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Assets.Code.Entities;

public class Draw : MonoBehaviour {
    private List<GameObject> foodGOList;
    private List<GameObject> entityGOList;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initialize()
    {
        
    }

    public void draw(List<Vector3> foodList, List<Entity> entityList)
    {
        drawFood(foodList);
        drawEntities(entityList);
    }

    public void drawFood(List<Vector3> foodList)
    {
        if (foodGOList == null)
        {
            foodGOList = new List<GameObject>(Parameters.numFood);
        }

        for (int i = 0; i < foodList.Count; i++)
        {
			if (foodGOList.Count <= i)
			{
				GameObject foodGO = new GameObject ("food" + i);
				foodGO.AddComponent<SpriteRenderer> ();
				foodGO.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("food");
				foodGO.transform.position = foodList [i];
				foodGOList.Add (foodGO);
			}
        }
    }

    public void drawEntities(List<Entity> entityList)
    {
        if(entityGOList == null)
        {
            entityGOList = new List<GameObject>(Parameters.numEntities);
        }

        for (int i = 0; i < entityList.Count; i++)
        {
			if (entityGOList.Count <= i)
			{
				GameObject entityGO = new GameObject ("entity" + i);
				entityGO.AddComponent<SpriteRenderer> ();
				entityGO.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("entity");
				entityGO.transform.position = entityList [i].coords;
				entityGO.transform.eulerAngles = new Vector3 (0, 0, toDegrees (entityList [i].rotation));
				entityGOList.Add (entityGO);
			}
			else
			{
				entityGOList [i].transform.position = entityList [i].coords;
				entityGOList [i].transform.eulerAngles = new Vector3 (0, 0, toDegrees (entityList [i].rotation));
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

    public float toDegrees(float radians)
    {
        return radians * (180 / Mathf.PI);
    }
}
