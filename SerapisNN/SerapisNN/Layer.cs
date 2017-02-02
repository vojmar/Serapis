﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerapisNN
{
    class Layer
    {
        public Neuron[] neurons { get; private set; }

        public Layer(int neuronCount)
        {
            neurons = new Neuron[neuronCount];
            for (int i = 0; i < neuronCount; i++)
            {
                //GENERATING NEURONS WITH BIAS FROM -20 TO 20
                neurons[i] = new Neuron(-20, 20);
            }
        }

        public void GenerateNeuronInputs(int num)
        {
            foreach(Neuron n in neurons)
            {
                n.GenerateInputs(num);
            }
        }
        public int[] GetNeuronOutputs()
        {
            int[] outputs = new int[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                outputs[i] = neurons[i].output;
            }
            return outputs;
        }
        public Neuron[] GetNeurons()
        {
            return neurons;
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
