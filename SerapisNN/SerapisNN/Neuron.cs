using System;
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
        double bias;
        Input[] inputs;

        Random r = new Random();

        public Neuron(int ranBiasRangeMin, int ranBiasRangeMax)
        {
            this.bias = r.NextDouble()*(ranBiasRangeMax - ranBiasRangeMin) + ranBiasRangeMin;
        }

        public Neuron(int bias)
        {
            this.bias = bias;
        }

        public void GenerateInputs(int n)
        {
            inputs = new Input[n];
            

            for(int i = 0; i < n; i++)
            {
                inputs[i] = new Input(r.Next(0,100));
            }
        }


        public float Compute()
        {
            float w = 0;
            foreach(Input i in inputs)
            {
                w = w + i.value * i.weight;
            }
            w = w - bias;

            //SIGMA FUNCTION FOR THIS NEURON
            float sig = 1 / (1 + (float)Math.Exp(-w));

            return sig;

        }
    }

    public class Input
    {

        public int weight;
        public float value = 0;

        public Input(int w)
        {
            weight = w;
        }

        /// <summary>
        /// Inputs value for this input
        /// </summary>
        /// <param name="v">Number from 0 to 1</param>
        /// <returns></returns>
        public bool setValue(float v)
        {
            if (v >= 0 && v <= 1)
            {
                value = v;
                return true;
            }
            else return false;
        }

    }
}
