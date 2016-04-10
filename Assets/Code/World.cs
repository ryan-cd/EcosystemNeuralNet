﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Assets.Code.Entities;

[System.Serializable]
public class World : MonoBehaviour {
    private static GeneticAlgorithm geneticAlgorithm;
    private static List<Vector3> foodLocations;

    //This is a duplicate of the static geneticAlgorithm variable.
    //It is non static to be viewed in the UnityEditor.
    public GeneticAlgorithm geneticAlgorithmDuplicate;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        geneticAlgorithmDuplicate = World.geneticAlgorithm;

        List<Entity> population = this.getEntities ();

        foreach (Entity e in population) {
            e.closestFood = getClosestFoodDirection (e.coords);

            Vector2 tankTreadPower = e.getTankTreadPower ();
            float RotForce = Mathf.Clamp(tankTreadPower.x - tankTreadPower.y, -Parameters.maxTurnRate, Parameters.maxTurnRate);
            e.rotation += RotForce;

            e.speed = (tankTreadPower.x + tankTreadPower.y) / 30.0f;
            Vector3 lookAt = e.getLookAtVector ();
            lookAt.Scale(new Vector3(e.speed, e.speed, e.speed));
            e.coords += lookAt;

            if (e.coords.x > Parameters.maxX)
                e.coords = new Vector3(e.coords.x - Parameters.maxX * 2, e.coords.y, 0);
            else if (e.coords.x < Parameters.minX)
                e.coords = new Vector3(e.coords.x + Parameters.maxX * 2, e.coords.y, 0);
            else if (e.coords.y > Parameters.maxY)
                e.coords = new Vector3(e.coords.x, e.coords.y - Parameters.maxY * 2, 0);
            else if (e.coords.y < Parameters.minY)
                e.coords = new Vector3(e.coords.x, e.coords.y + Parameters.maxY * 2, 0);
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
            foodLocations.Add(new Vector3(Random.Range(Parameters.minX, Parameters.maxX), 
                                            Random.Range(Parameters.minY, Parameters.maxY)));
        }
        geneticAlgorithm = new GeneticAlgorithm(Parameters.populationSize, Parameters.crossoverRate, Parameters.mutationRate, Parameters.numWeights);
        geneticAlgorithm.initialize();

        List<Entity> population = this.getEntities();
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

    public static void collide(int entityID, int foodID)
    {
        //Debug.Log("entity" + entityID + "got food " + foodID);
        foodLocations[foodID] = new Vector3(Random.Range(Parameters.minX, Parameters.maxX),
                                            Random.Range(Parameters.minY, Parameters.maxY));
        geneticAlgorithm.incrementFitness(entityID);

    }
}
