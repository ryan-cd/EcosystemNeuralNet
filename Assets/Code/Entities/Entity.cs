using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Entities
{
    public class Entity
    {
        private Vector3 coords;
        private float rotation;
        private NeuralNetwork controller;

        public Entity()
        {
            this.coords = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 0);
            this.rotation = Random.Range(0, 2 * Mathf.PI);
        }

        public Vector3 getCoords()
        {
            return this.coords;
        }

        public float getRotation()
        {
            return this.rotation;
        }
    }
}
