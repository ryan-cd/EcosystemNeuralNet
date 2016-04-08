using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Code.Entities
{
    [System.Serializable]
    public class Entity
	{
		// this problem
		// 4 inputs (Look_x, Look_y, Mine_direction_x, Mine_direction_y)
		// 2 outputs ( Tread_x, Tread_y )
		const int N_INPUTS = 4;
		const int M_HIDDEN = 6;
		const int P_OUTPUTS = 2;

        public Vector3 coords;
        public Vector3 lookAtVector;
        public float rotation;
        private NeuralNetwork controller;

        public Entity()
        {
            this.coords = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 0);
            this.rotation = Random.Range(0, 2 * Mathf.PI);
			this.lookAtVector = getLookAtVector();

			float[] bias = new float[] { 1.0f, 1.0f	 };
			this.controller = new NeuralNetwork(Entity.N_INPUTS, Entity.M_HIDDEN, Entity.P_OUTPUTS, bias);
        }

        public Vector3 getCoords()
        {
            return this.coords;
        }

        public float getRotation()
        {
            return this.rotation;
        }

		public Vector2 getTankTreadPower()
		{
			List<float> inputs = new List<float> { 2.0f, 5.0f, 3.0f, 4.0f };

			return controller.Run (inputs);
		}

        public Vector3 getLookAtVector()
        {
            return new Vector3(-1 * Mathf.Sin(this.rotation), Mathf.Cos(this.rotation), 0);
        }

        public List<float> getChromosome()
        {
            return controller.getChromosome();
        }

        public void setChromosome(List<float> weights)
        {
            //TODO: set the weights
        }
    }
}
