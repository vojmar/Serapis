﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerapisNN
{
    /// <summary>
    /// Sigmoid Neuron
    /// </summary>
    public class Neuron
    {
        public float bias;
        float[] inputs;
        float[] weights;
        private float acv;
        float weightedDiameter;
        public float output { get; private set; }
        Funkce f;
        Random r = new Random();

        public Neuron(float ranBiasRangeMin, float ranBiasRangeMax, Funkce f,int inputsCount)
        {
            this.bias =  (float)(r.NextDouble() * (ranBiasRangeMax - ranBiasRangeMin));
            this.f = f;
            inputs = new float[inputsCount];
            weights = new float[inputsCount];
        }

        public Neuron(float bias, Funkce f)
        {
            this.bias = bias;
            this.f = f;
        }

        public void GenerateInputs(int[] n)
        {
            for (int i = 0; i < n.Length; i++)
            {
                inputs[i] = n[i];
            }
        }
        public void GenerateRandomWeights()
        {
            Random r = new Random();
            if (weights != null)
            {
                for (int i = 0; i < weights.Length; i++)
                {
                    weights[i] = r.Next(1,100);
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public float Compute(float[] x)
        {
            float tmp1=0,tmp2=0;
            for (int i = 0; i < inputs.Length; i++)
            {
                tmp1 = weights[i] * inputs[i]+ tmp1;
                tmp2 = tmp2+weights[i];
            }
            weightedDiameter = tmp1 / tmp2;
            //SIGMA FUNCTION FOR THIS NEURON
            //Todo: Implement mathematical function
            return f.Activate(weightedDiameter);
            //output = result;
            //return result;
        }
    }
}
