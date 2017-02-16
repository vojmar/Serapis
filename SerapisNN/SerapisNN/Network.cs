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
        int inputLayerNeuronsInputCount;
        int inputLayerNeuronCount;
        /// <summary>
        /// Creates neural network with specified number of layers and neurons.
        /// Eq. creating 3 layer network with 2 neurons in first, 5 neurons in second and 1 neuron in third layers, do Network({2, 5, 1});
        /// </summary>
        /// <param name="layerNeuronCount">Array specifying number of neurons in each corresponding layer</param>
        /// <param name="inputLayerNeuronInputCount">Specifies number of inputs for input layer neurons</param>
        public Network(int[] layerNeuronCount, Funkce[] f)
        {
            this.inputLayerNeuronCount = layerNeuronCount[0];


            layers = new Layer[layerNeuronCount.Length];
            for(int n = 0; n < layerNeuronCount.Length; n++)
            {
                layers[n] = new Layer(layerNeuronCount[n], f[n]);
                if (n != 0) //IF !INPUT LAYER
                {
                    layers[n].GenerateNeuronInputs(layerNeuronCount[n - 1]);
                }
                else //GENERATE 1 INPUT ON 1ST LAYER
                {
                    layers[n].GenerateNeuronInputs(1);
                }
            }
        }

        public float[] feedforward(Data d)
        {
            //DATA CHECK
            if (d.data.Length != inputLayerNeuronCount) throw new Exception("Unexpected input data, neuron count does not correspond with input lenght");
            //DATA CHECK END
            float[] prlayer = d.data;
            foreach(Layer l in layers)
            {
                float[] tmpdata = new float[l.neurons.Length];
                for(int i = 0; i < l.neurons.Length; i++)
                {
                    tmpdata[i] = l.neurons[i].Compute(prlayer);
                }
                prlayer = tmpdata;
            }
            return prlayer; //nothing yet
        }

        public float backpropagation(LearnData d)
        {
            //throw new NotImplementedException("LULZ");
            float[][] nabla_b = new float[layers.Length][];
            float[][][] nabla_w = new float[layers.Length][][];
            float[][] activations = new float[layers.Length+1][];
            int lc = 0;
            foreach (Layer l in layers)
            {
                nabla_b[lc] = new float[l.neurons.Length];
                nabla_w[lc] = new float[l.neurons.Length][];
                int nc = 0;
                foreach (Neuron n in l.neurons)
                {
                    nabla_b[lc][nc] = 0;
                    nabla_w[lc][nc] = new float[n.Inputs.Length];
                    for(int ic = 0; ic < n.Inputs.Length; ic++)
                    {
                        nabla_w[lc][nc][ic] = 0;
                    }
                        nc++;
                }
                lc++;
            }


            return 0f; //nothing yet
        }
 

        public struct Data
        {
            public float[] data;
        }

        public  struct LearnData
        {
            public float[] idata;
            public float[] odata;
        }
    }
}
