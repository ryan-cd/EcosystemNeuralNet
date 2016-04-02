using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Entities
{
    class GeneticAlgorithm
    {
        private int populationSize;
        private float crossoverRate;
        private float mutationRate;
        private int numWeights;
        public GeneticAlgorithm(int populationSize, float crossoverRate, float mutationRate, int numWeights)
        {
            this.populationSize = populationSize;
            this.crossoverRate = crossoverRate;
            this.mutationRate = mutationRate;
            this.numWeights = numWeights;
        }
    }
}
