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
        Funkce cost;
        /// <summary>
        /// Creates neural network with specified number of layers and neurons.
        /// Eq. creating 3 layer network with 2 neurons in first, 5 neurons in second and 1 neuron in third layers, do Network({2, 5, 1});
        /// </summary>
        /// <param name="layerNeuronCount">Array specifying number of neurons in each corresponding layer</param>
        /// <param name="inputLayerNeuronInputCount">Specifies number of inputs for input layer neurons</param>
        public Network(int[] layerNeuronCount, Funkce[] f, Funkce cost)
        {
            this.inputLayerNeuronCount = layerNeuronCount[0];
            this.cost = cost;

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

        public Network(int[] layerNeuronCount, Funkce f, Funkce cost)
        {
            this.inputLayerNeuronCount = layerNeuronCount[0];
            this.cost = cost;

            layers = new Layer[layerNeuronCount.Length];
            for (int n = 0; n < layerNeuronCount.Length; n++)
            {
                layers[n] = new Layer(layerNeuronCount[n], f);
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

        /*** THIS IS WRONG ON SO MANY LEVELS!!!

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
            return prlayer;
        }

        public float backpropagation(LearnData d)
        {
            //throw new NotImplementedException("LULZ");
            float[][] nabla_b = new float[layers.Length][];
            float[][][] nabla_w = new float[layers.Length][][];

            float[][] activations = new float[layers.Length+1][];
            float[] activation = d.idata;

            float[][] zv = new float[layers.Length][];

            int lc = 0;

            activations[0] = d.idata;

            foreach (Layer l in layers) //forward pass
            {
                activations[lc+1] = new float[l.neurons.Length];
                zv[lc] = new float[l.neurons.Length];
                int nc = 0;
                foreach (Neuron n in l.neurons)
                {
                    float zvtmp = 0;
                    for(int inp = 0; inp < n.Inputs.Length; inp++)
                    {
                        zvtmp += n.Inputs[inp].weight * activation[inp];
                    }
                    zvtmp += n.bias;
                    activations[lc+1][nc] = n.f.Activate(zvtmp);
                    zv[lc][nc] = zvtmp;
                    nc++;
                }
                activation = activations[lc+1];
                lc++;
            }


            float[] delta;
            for (int l = layers.Length-1; l<=0; l--) //backprop
            {
                nabla_b[l] = new float[layers[l].neurons.Length];
                nabla_w[l] = new float[layers[l].neurons.Length][];
                delta = new float[layers[l].neurons.Length];

                for (int n = 0; n < layers[l].neurons.Length; n++)
                {
                    
                    if (l == layers.Length-1)
                    {
                        float deriv = layers[l - 1].neurons[n].f.Derivate(zv[l][n]); //NEVÍM
                        delta[n] = cost.Derivate(activations[l + 1][n], new float[] { d.odata[n] * deriv });
                        nabla_b[l][n] = delta[n];
                        nabla_w[l][n] = new float[layers[l].neurons[n].Inputs.Length];
                        for (int inp = 0; inp < layers[l].neurons[n].Inputs.Length; inp++)
                        {
                            nabla_w[l][n][inp] = delta[n] * activations[l - 1][n]; //ASI ŠPATNĚ
                        }
                    }
                    else
                    {
                        float[] odelta = delta;
                        float z = zv[l][n];
                        float deriv = layers[l].neurons[n].f.Derivate(z);
                        float dlt = 0;
                        for(int inp = 0; inp < layers[l+1].neurons[n].Inputs.Length; inp++)
                        {
                            dlt += layers[l + 1].neurons[n].Inputs[inp].weight * delta[n]; //IDK
                        }
                    }
                }
            }


            return 0f; //nothing yet
        }
 
    ***/
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
