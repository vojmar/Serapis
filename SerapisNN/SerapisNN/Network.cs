using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMath;

namespace SerapisNN
{
    class Network
    {
        
        Layer[] layers;
        int inputLayerNeuronsInputCount;
        int inputLayerNeuronCount;
        Funkce fce;

        public Network(int[] layerNeuronCount, Funkce f)
        {
            this.inputLayerNeuronCount = layerNeuronCount[0];
            this.fce = f;
            layers = new Layer[layerNeuronCount.Length];
            for (int n = 0; n < layerNeuronCount.Length; n++)
            {
                if (n != 0) //IF !INPUT LAYER
                {
                    layers[n] = new Layer(layerNeuronCount[n], f, layers[n - 1].neurons.Length);
                }
                else //GENERATE 1 INPUT ON 1ST LAYER
                {
                    layers[n] = new Layer(layerNeuronCount[n], f,1);
                }
            }
        }
        public Network(int[] layerNeuronCount)
        {
            Funkce f = null;//TODO: Default function
            this.inputLayerNeuronCount = layerNeuronCount[0];

            layers = new Layer[layerNeuronCount.Length];
            for (int n = 0; n < layerNeuronCount.Length; n++)
            {
                if (n != 0) //IF !INPUT LAYER
                {
                    layers[n] = new Layer(layerNeuronCount[n], f, layers[n - 1].neurons.Length);
                }
                else //GENERATE 1 INPUT ON 1ST LAYER
                {
                    layers[n] = new Layer(layerNeuronCount[n], f, 1);
                }
            }
        }
        public float[] Compute(float[] inputs)
        {
            if (layers.Length > 1 && layers != null)
            {
                float[] outputs = inputs;
                for (int i = 0; i < layers.Length; i++)
                {
                    layers[i].DefineNeuronInputs(outputs);
                    outputs = layers[i].ComputeAll();
                }
                return outputs;
            }
            else
            {
                throw new Exception("Něco je špatně! Inputy nesouhlasí!");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">sum data</param>
        /// <param name="iterations">If 0 learns from all the data</param>
        public void Learn(LearnData[] data, int iterations = 0)
        {

        }

        public void BackProp(float[] idata, float[] odata)
        {
            if (odata.Length != layers[layers.Length - 1].neurons.Length) throw new ArgumentException("Output data lenght does not correspond with output layer");
            float[] chdata = Compute(idata);

            float[][] grads;
            //OUTPUT LAYER GRAD
            grads = new float[this.layers.Length][];
            float[] ograds = new float[odata.Length];
            for(int i = 0; i < odata.Length; i++)
            {
                float deriv = (1 - chdata[i]) * chdata[i];
                ograds[i] = deriv * (odata[i] - chdata[i]);
            }
            //OTHER LAYERS
            for (int i = layers.Length - 1; i >= 0; i--)
            {
                grads[i] = new float[this.layers[i].neurons.Length];
                
                for (int j = 0; j < this.layers[i].neurons.Length ; j++)
                {
                    float deriv = (1 - layers[i].neurons[j].output) * layers[i].neurons[j].output;
                }
                    
            }

        }

        public  struct LearnData
        {
            public float[] idata;
            public float[] odata;
        }
    }
}
