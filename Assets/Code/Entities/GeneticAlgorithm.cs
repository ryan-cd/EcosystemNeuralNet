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
        private int totalFitness;
        private int generation;

        public List<Entity> population;

        public GeneticAlgorithm(int populationSize, float crossoverRate, float mutationRate, int numWeights)
        {
            this.populationSize = populationSize;
            this.crossoverRate = crossoverRate;
            this.mutationRate = mutationRate;
            this.numWeights = numWeights;
            this.generation = 1;
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
            List<Entity> newPopulation = new List<Entity>();
            while(newPopulation.Count < population.Count)
            {
                newPopulation.Add(createNewChild());
            }
            population.Clear();
            population.AddRange(newPopulation);
            this.totalFitness = 0;
        }

        private Entity createNewChild()
        {
            Entity child = new Entity();
            List<float> childChromosome = null;
            while(childChromosome == null)
            {
                childChromosome = crossover(getParentChromosome(), getParentChromosome());
            }
            childChromosome = mutate(childChromosome);
            child.setChromosome(childChromosome);
            return child;
        }

        private List<float> getParentChromosome()
        {
            float slice = UnityEngine.Random.Range(0f, 1f) * totalFitness;
            //Debug.Log("slice: " + slice + "total fitness: " + totalFitness);
            int accumulatedFitness = 0;
            for(int i = 0; i < population.Count; i++)
            {
                //Debug.Log("PARENT IS " + i);
                accumulatedFitness += population[i].getFitness();
                if (accumulatedFitness >= slice)
                    return population[i].getChromosome();
            }
            throw new System.Exception("Could not select a parent chromosome");
        }

        private List<float> crossover(List<float> parent1, List<float> parent2)
        {
            if (parent1.SequenceEqual<float>(parent2) 
                || !(UnityEngine.Random.Range(0f, 1f) <= Parameters.crossoverRate))
                return null;
            else
            {
                int index = (int)(UnityEngine.Random.Range(0f, 1f) * (parent1.Count - 2));
                List<float> child = parent1.GetRange(0, index + 1);
                child.AddRange(parent2.GetRange(index + 1, parent2.Count - (index + 1)));
                return child;
            }
        }

        private List<float> mutate(List<float> input)
        {
            List<float> output = new List<float>();
            output.AddRange(input);
            for(int i = 0; i < input.Count; i++)
            {
                if(UnityEngine.Random.Range(0f, 1f) < Parameters.mutationRate)
                {
                    output[i] += UnityEngine.Random.Range(-1f, 1f) * Parameters.maxPertubation;
                }
            }
            return output;
        }

        public void incrementFitness(int entityID)
        {
            population[entityID].incrementFitness();
            updateFittestEntities();
            totalFitness++;
            if(totalFitness > Parameters.populationSize * generation)
            {
                Debug.Log("Generation " + generation++ 
                    + " concludes with avg fitness: " + totalFitness / Parameters.populationSize);
                createNextGeneration();
            }
        }

        public void updateFittestEntities()
        {
            int fittestIndex = 0;
            for(int i = 0; i < populationSize; i++)
            {
                if(population[i].getFitness() > population[fittestIndex].getFitness())
                {
                    fittestIndex = i;
                }
                population[i].setIsTopPerformer(false);
            }
            population[fittestIndex].setIsTopPerformer(true);
            //Debug.Log("assigned " + fittestIndex);
        }
    }
}
