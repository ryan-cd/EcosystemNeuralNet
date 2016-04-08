using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Entities
{
    [Serializable]
    public class GeneticAlgorithm
    {
        private int populationSize;
        private float crossoverRate;
        private float mutationRate;
        private int numWeights;

        public List<Entity> population;

        public GeneticAlgorithm(int populationSize, float crossoverRate, float mutationRate, int numWeights)
        {
            this.populationSize = populationSize;
            this.crossoverRate = crossoverRate;
            this.mutationRate = mutationRate;
            this.numWeights = numWeights;
        }

        public void initialize()
        {
            population = new List<Entity>();
            for (int i = 0; i < populationSize; i++)
            {
                population.Add(new Entity());
            }
        }

        public List<Entity> getPopulation()
        {
            return this.population;
        }

        public void createNextGeneration()
        {

        }
    }
}
