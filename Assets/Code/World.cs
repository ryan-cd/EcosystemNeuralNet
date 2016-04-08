﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Assets.Code.Entities;

[System.Serializable]
public class World : MonoBehaviour {
    public GeneticAlgorithm geneticAlgorithm;
    private List<Vector3> foodLocations;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		List<Entity> population = this.getEntities ();

		foreach (Entity e in population) {
			e.closestFood = getClosestFoodDirection (e.coords);

			Vector2 tankTreadPower = e.getTankTreadPower ();
			float RotForce = Mathf.Clamp(tankTreadPower.x - tankTreadPower.y, -Parameters.maxTurnRate, Parameters.maxTurnRate);
			e.rotation += RotForce;

			e.speed = (tankTreadPower.x + tankTreadPower.y) / 100.0f;
			Vector3 lookAt = e.getLookAtVector ();
			lookAt.Scale(new Vector3(e.speed, e.speed, e.speed));
			e.coords += lookAt;
		}
	}

	public Vector3 getClosestFoodDirection(Vector3 entity)
	{
		float minDist = Mathf.Infinity;
		Vector3 closestFood = new Vector3 ();

		Vector3 lookAtVector = new Vector3 ();

		foreach (Vector3 food in foodLocations) {
			float dist = Vector3.Distance (entity, food);
			if (dist < minDist)
			{
				minDist = dist;
				closestFood = food;
			}
		}

		lookAtVector = (closestFood - entity).normalized;

		return lookAtVector;
	}

    public void initialize()
    {
        foodLocations = new List<Vector3>();
        for (int i = 0; i < Parameters.numFood; i++)
        {
            foodLocations.Add(new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f)));
        }
        geneticAlgorithm = new GeneticAlgorithm(Parameters.populationSize, Parameters.crossoverRate, Parameters.mutationRate, Parameters.numWeights);
        geneticAlgorithm.initialize();

        List<Entity> population = this.getEntities();
        Debug.Log(population[0].getTankTreadPower());
        Debug.Log("weight count " + population[0].getChromosome().Count);
    }

    public List<Entity> getEntities() {
        return geneticAlgorithm.getPopulation();
    }

    public List<Vector3> getFood()
    {
        return foodLocations;
    }

    public void createNextGeneration()
    {
        geneticAlgorithm.createNextGeneration();
    }
}
