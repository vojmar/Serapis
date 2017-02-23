using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerapisNN
{
    public class Funkce
    {
        public delegate float F(float x, float[] args = null);

        private F activate;
        private F derivate;
        
        public Funkce(F activ, F deriv)
        {
            activate = activ;
            derivate = deriv;
        }

        public float Activate(float x) => activate(x);
        public float Derivate(float x) => derivate(x);
        public float Derivate(float x, float[] args) => derivate(x, args);
    }

}
