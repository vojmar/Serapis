using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerapisNN
{
    class Funkce
    {
        public delegate float F(float x);

        private F activate;
        private F derivate;
        
        public Funkce(F activ, F deriv)
        {
            activate = activ;
            derivate = deriv;
        }

        public float Activate(float x) => activate(x);
        public float Derivate(float x) => derivate(x);
    }

}
