using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerapisNN
{
    class Network
    {

        Layer[] layers;

        /// <summary>
        /// Creates neural network with specified number of layers and neurons.
        /// Eq. creating 3 layer network with 2 neurons in first, 5 neurons in second and 1 neuron in third layers, do Network({2, 5, 1});
        /// </summary>
        /// <param name="layerNeuronCount">Array specifying number of neurons in each corresponding layer</param>
        /// <param name="inputLayerNeuronInputCount">Specifies number of inputs for input layer neurons</param>
        public Network(int[] layerNeuronCount, int inputLayerNeuronInputCount)
        {
            layers = new Layer[layerNeuronCount.Length];
            for(int n = 0; n < layerNeuronCount.Length; n++)
            {
                layers[n] = new Layer(layerNeuronCount[n]);
                if (n != 0) //IF !INPUT LAYER
                {
                    layers[n].GenerateNeuronInputs(layerNeuronCount[n - 1]);
                }
                else //GENERATE 1 INPUT FOR EACH INPUT LAYER NEURON
                {
                    layers[n].GenerateNeuronInputs(inputLayerNeuronInputCount);
                }
            }
        }
    }
}
