using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Entities
{
    [System.Serializable]
    public class NeuralNetwork
    {
        public List<Neuron> hidden = new List<Neuron> ();
        public List<Neuron> outputs = new List<Neuron> ();
        private int numInputs;
        private int numHiddenNeurons;
        private int numOutputNeurons;

        public NeuralNetwork(int numInputs, int numHiddenNeurons, int numOutputNeurons)
        {
            for (int i = 0; i < numHiddenNeurons; i++)
            {
                this.hidden.Add (new Neuron (numInputs, Parameters.P) );
            }

            for(int i = 0; i < numOutputNeurons; i++)
            {
                this.outputs.Add( new Neuron(numHiddenNeurons, Parameters.P) );
            }
            this.numInputs = numInputs;
            this.numHiddenNeurons = numHiddenNeurons;
            this.numOutputNeurons = numOutputNeurons;
        }

        public Vector2 Run(List<float> inputs)
        {
            List<float> midwayOutputs = new List<float>();
            Vector2 output = new Vector2 ();

            for (int i = 0; i < this.hidden.Count; i++)
            {
                midwayOutputs.Add(this.hidden[i].Run(inputs, Parameters.bias));
            }

            output.x = this.outputs [0].Run (midwayOutputs, Parameters.bias);
            output.y = this.outputs [1].Run (midwayOutputs, Parameters.bias);

            return output;
        }

        public List<float> getChromosome()
        {
            List<float> weights = new List<float> ();
            for (int i = 0; i < hidden.Count; i++)
            {
                weights.AddRange(hidden[i].getWeights());
            }

            for (int i = 0; i < outputs.Count; i++)
            {
                weights.AddRange(outputs[i].getWeights());
            }

            return weights;
        }

        public void setChromosome(List<float> weights)
        {
            for(int i = 0; i < hidden.Count; i++)
            {
                hidden[i].setWeights(
                    weights.GetRange(i * hidden[i].getNumWeights(), hidden[i].getNumWeights()));
            }

            for (int i = 0; i < outputs.Count; i++)
            {
                outputs[i].setWeights(
                    weights.GetRange(i * outputs[i].getNumWeights(), outputs[i].getNumWeights()));
            }
        }
    }

    [System.Serializable]
    public class Neuron
    {
        public int numInputs;
        private float P;
        public List<float> weights = new List<float>();
        static System.Random random = new System.Random((int)DateTime.Now.Ticks);

        public Neuron(int numInputs, float p = Parameters.bias)
        {
            this.P = p;
            this.numInputs = ++numInputs;
            for(int i = 0; i < this.numInputs; i++)
            {
                weights.Add( (float)(Neuron.random.NextDouble() * 2 - 1));
            }
        }

        public float Run(List<float> inputs, float bias)
        {
            if (inputs.Count != this.numInputs - 1)
            {
                throw new System.ArgumentException("Inputs do not match the length.");
            }

            // W * x
            float sum = 0.0f;
            for (int i = 0; i < this.numInputs - 1; i++)
            {
                sum += weights [i] * inputs[i];
            }
            sum += weights [this.numInputs - 1] * bias;

            // activation function
            // f(W * x)
            float activation = 0.0f;
            activation = 1.0f / ( 1 + (float) Math.Exp(sum / this.P) );

            return activation;
        }

        public List<float> getWeights()
        {
            return this.weights;
        }

        public int getNumWeights()
        {
            return this.weights.Count;
        }

        public void setWeights(List<float> weights)
        {
            if (weights.Count == this.weights.Count)
            {
                this.weights = weights;
            }
            else
            {
                throw new System.ArgumentException("Trying to set weights with wrong number of weights");
            }
        }
    }
}
