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
        public float bias;
        Input[] inputs;
        public float output { get; private set; }
        public Funkce f;
        Random r = new Random();

        public Neuron(float ranBiasRangeMin, float ranBiasRangeMax, Funkce f)
        {
            this.bias =  (float)(r.NextDouble() * (ranBiasRangeMax - ranBiasRangeMin));
            this.f = f;
        }

        public Neuron(float bias, Funkce f)
        {
            this.bias = bias;
            this.f = f;
        }

        public void GenerateInputs(int n)
        {
            inputs = new Input[n];
            
            for(int i = 0; i < n; i++)
            {
                inputs[i] = new Input(r.Next(0,100));
            }
        }

        public Input[] Inputs
        {
            get { return inputs; }
        }


        public float Compute(float[] x)
        {
            float w = 0;
            int it = 0;
            foreach(Input i in inputs)
            {
                w = w + x[it] * i.weight;
                it++;
            }
            w = w - bias;

            //SIGMA FUNCTION FOR THIS NEURON
            //Todo: Implement mathematical function
            return f.Activate(w);
            //output = result;
            //return result;
        }
    }

    public class Input
    {

        public float weight;

        public Input(float w)
        {
            weight = w;
        }

        public void setWeight(float w)
        {
            weight = w;
        }
    }
}
