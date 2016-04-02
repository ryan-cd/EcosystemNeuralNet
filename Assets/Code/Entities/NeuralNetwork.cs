using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Entities
{
    class NeuralNetwork
    {
    }

    class Neuron
    {
        private int numInputs;
        private List<double> weights;
        Random random = new Random();
        public Neuron(int numInputs)
        {
            this.numInputs = ++numInputs;
            for(int i = 0; i < this.numInputs; i++)
            {
                weights.Add(random.NextDouble() * 2 - 1);
            }
        }
    }
}
