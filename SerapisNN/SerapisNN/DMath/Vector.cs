using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMath
{
    public class Vector
    {
        private float[] vc;

        public Vector(float[] flt)
        {
            this.vc = flt;
        }

        public int Dimension
        {
            get { return this.vc.Length; }
        }

        public float this[int i]
        {
            get { return this.vc[i]; }
        }

        public static Vector ZeroVector3D()
        {
            return new Vector(new float[] { 0, 0, 0 });
        }

        public static float operator *(Vector v1, Vector v2)
        {
            if (v1.Dimension != v2.Dimension) throw new ArgumentException();
            float dim = 0;
            for(int i = 0; i < v1.Dimension; i++)
            {
                dim += v1[i] * v2[i];
            }
            return dim;
        }

        public static float Dot(Vector v1, Vector v2)
        {
            if (v1.Dimension != v2.Dimension) throw new ArgumentException();
            float dim = 0;
            for (int i = 0; i < v1.Dimension; i++)
            {
                dim += v1[i] * v2[i];
            }
            return dim;
        }

        public static explicit operator Vector(float[] f)
        {
            return new Vector(f);
        }
        

    }
}
