using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerapisNN
{
    class Layer
    {
        private Neuron[] neurons;

        Layer(int neuronCount)
        {
            neurons = new Neuron[neuronCount];
            for (int i = 0; i < neuronCount; i++)
            {
                neurons[i] = new Neuron(0);
            }
        }

        public void GenerateNeuronInputs(int num)
        {
            foreach(Neuron n in neurons)
            {
                n.GenerateInputs(num);
            }
        }

        int NeuronCount
        {
            get
            {
                return neurons.Length;
            }
        }
    }
}
