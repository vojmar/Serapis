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
        int bias;
        Input[] inputs;
        public int output { get; private set; }

        Random r = new Random();

        public Neuron(int ranBiasRangeMin, int ranBiasRangeMax)
        {
            this.bias = (int) r.Next(ranBiasRangeMax - ranBiasRangeMin);
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


        public int Compute()
        {
            int w = 0;
            foreach(Input i in inputs)
            {
                w = w + i.value * i.weight;
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

        public int weight;
        public int value = 0;

        public Input(int w)
        {
            weight = w;
        }

        /// <summary>
        /// Inputs value for this input
        /// </summary>
        /// <param name="v">Number from 0 to 1</param>
        /// <returns></returns>
        public void setValue(int v)
        {
            value = v;
        }
        public void setWeight(int w)
        {
            weight = w;
        }
    }
}
