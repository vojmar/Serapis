using System;


namespace SerapisNN
{
    public class NetworkV2
    {
        private int inputc;
        private int hiddenc;
        private int outc;

        private double[] inputs;
        private double[][] ihweights;
        private double[] hbiases;
        private double[] houtputs;

        private double[][] howeights;
        private double[] obiases;
        private double[] outputs;

        private Random rnd;

        private Funkce neuronf;
        private Funkce costf;

        public NetworkV2(int inputcount, int hiddencount, int outputcount, Funkce f, Funkce cost)
        {
            this.inputc = inputcount;
            this.hiddenc = hiddencount;
            this.outc = outputcount;
            this.neuronf = f;
            this.costf = cost;

            //INITIALIZE WEIGHTS



        }
    }
}
