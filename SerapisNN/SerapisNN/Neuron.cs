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
        float bias;
        Input[] inputs;
        public float output { get; private set; }

        Random r = new Random();

        public Neuron(float ranBiasRangeMin, float ranBiasRangeMax)
        {
            this.bias =  (float)(r.NextDouble() * (ranBiasRangeMax - ranBiasRangeMin));
        }

        public Neuron(float bias)
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


        public int Compute(float x)
        {
            float w = 0;
            foreach(Input i in inputs)
            {
                w = w + x * i.weight;
            }
            w = w - bias;

            //SIGMA FUNCTION FOR THIS NEURON
            //Todo: Implement mathematical function
            throw new NotImplementedException();
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
