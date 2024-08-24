using ConsoleApp1.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp1
{
    public class Vertices
    {
        private Dictionary<String, Punto> Lpuntos; 

        public Vertices()
        {
            Lpuntos = new Dictionary<string, Punto>();
        }

        public void AgregarPunto(string clave, Punto punto)
        {
            if (!Lpuntos.ContainsKey(clave))
            {
                Lpuntos.Add(clave, punto);
            }
            else
            {
                Lpuntos[clave] = punto;
            }
        }

        public Punto ObtenerPunto(string clave)
        {
            if (Lpuntos.ContainsKey(clave))
            {
                return Lpuntos[clave];
            }
            else
            {
                return null; // O lanzar una excepción si prefieres
            }
        }

        public void Aplicar()
        {
            GL.Begin(PrimitiveType.LineLoop);
            foreach (var punto in Lpuntos.Values)
            {
                GL.Vertex3(punto.X,punto.Y,punto.Z);
            }
            GL.End();
        }
    }
}
