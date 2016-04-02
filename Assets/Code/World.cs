using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Assets.Code.Entities;

public class World : MonoBehaviour {
    private GeneticAlgorithm geneticAlgorithm;
    private List<Vector2> foodLocations;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initialize()
    {
        geneticAlgorithm.initialize();
    }

    List<Entity> getEntities() {
        return geneticAlgorithm.getPopulation();
    }

    public void createNextGeneration()
    {
        geneticAlgorithm.createNextGeneration();
    }
}
