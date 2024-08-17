using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.main
{
    class Punto
    {
        public float X {  get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Punto()
        {
            X = Y = Z = 0;
        }
        public Punto(float v)
        {
            X = Y = Z = v;
        }
        public Punto(float X, float Y, float Z) 
        {
            this.X = X; this.Y = Y; this.Z = Z;
        }

        public Punto(Punto p) 
        {
            X = p.X; this.Y = p.Y; this.Z = p.Z;
        }
    }
}
