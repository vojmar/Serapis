using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerapisNN
{
    class Layer
    {
        public Neuron[] neurons { get; private set; }

        public Layer(int neuronCount, Funkce f,int inputsCount)
        {
            neurons = new Neuron[neuronCount];
            for (int i = 0; i < neuronCount; i++)
            {
                //GENERATING NEURONS WITH BIAS FROM -20 TO 20
                neurons[i] = new Neuron(-20, 20, f,inputsCount);
            }
        }

        public void DefineNeuronInputs(float[] inputs)
        {
            foreach (var neuron in neurons)
            {
                neuron.DefineInputs(inputs);
            }
        }

        int NeuronCount
        {
            get
            {
                return neurons.Length;
            }
        }
        public float[] ComputeAll()
        {
            List<float> outputs = new List<float>();
            foreach (var item in neurons)
            {
                outputs.Add(item.Compute());
            }
            return outputs.ToArray();
        }
    }
}
