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
			// TODO hidden layer
			for (int i = 0; i < hidden; i++)
			{
//				this.hidden.Add (new Neuron () );
			}

			for(int i = 0; i < outputs; i++)
			{
				this.outputs.Add( new Neuron(inputs, P) );
			}
			this.inputN = inputs;
			this.outputM = outputs;
			this.bias = bias;
		}

		public Vector2 Run(float[] inputs)
		{
			Vector2 output = new Vector2 ();

			output.x = this.outputs [0].Run (inputs, bias[0]);
			output.y = this.outputs [1].Run (inputs, bias[1]);

			return output;
		}

		public List<float> encode()
		{
			List<float> weights = new List<float> ();

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

		public float Run(float[] inputs, float bias)
		{
			if (inputs.Length != this.numInputs - 1)
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
    }
}
