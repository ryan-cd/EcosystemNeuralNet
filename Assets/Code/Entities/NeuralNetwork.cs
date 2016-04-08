using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Entities
{

	// No hidden layers.
    class NeuralNetwork
	{
		private List<Neuron> hidden = new List<Neuron> ();
		private List<Neuron> outputs = new List<Neuron> ();
		private int inputN;
		private int hiddenM;
		private int outputP;
		private float[] bias;

		public NeuralNetwork(int inputs, int hidden, int outputs, float[] bias, float P = 1.0f)
		{
			for (int i = 0; i < hidden; i++)
			{
				this.hidden.Add (new Neuron (inputs, P) );
			}

			for(int i = 0; i < outputs; i++)
			{
				this.outputs.Add( new Neuron(hidden, P) );
			}
			this.inputN = inputs;
			this.outputP = outputs;
			this.bias = bias;
		}

		public Vector2 Run(List<float> inputs)
		{
            List<float> midwayOutputs = new List<float>();
            Vector2 output = new Vector2 ();

            Debug.Log("input length " + inputs.Count);
            for (int i = 0; i < this.hidden.Count; i++)
            {
                midwayOutputs.Add(this.hidden[i].Run(inputs, Parameters.bias));
            }
            Debug.Log("Midway length " + midwayOutputs.Count);

			output.x = this.outputs [0].Run (midwayOutputs, bias[0]);
			output.y = this.outputs [1].Run (midwayOutputs, bias[1]);

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
    }

    class Neuron
    {
        private int numInputs;
		private float P;
		private List<float> weights = new List<float>();
		System.Random random = new System.Random();

		public Neuron(int numInputs, float p = 1.0f)
        {
			this.P = p;
            this.numInputs = ++numInputs;
            for(int i = 0; i < this.numInputs; i++)
            {
				weights.Add( (float)random.NextDouble() * 2 - 1);
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
    }
}
