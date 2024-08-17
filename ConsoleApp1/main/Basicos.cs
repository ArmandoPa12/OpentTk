using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp1.main
{
    class Basicos
    {
        static public void drawLine(Punto a, Punto b)
        {
            //GL.Color3(1.0f, 1.0f, 1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(a.X, a.Y, a.Z);
            GL.Vertex3(b.X, b.Y, b.Z);
            GL.End();
        }

        static public void drawTriangle(Punto ini,float ancho,float alto)
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(ini.X, ini.Y,ini.Z);
            GL.Vertex3(ancho,ini.Y,ini.Z);
            GL.Vertex3(ancho/2, alto, ini.Z);
            GL.End();
        }

        static public void drawSquare(Punto ini,float alto, float largo)
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(ini.X, ini.Y, ini.Z);
            GL.Vertex3(ini.X, alto, ini.Z);
            GL.Vertex3(largo, alto, ini.Z);
            GL.Vertex3(largo, ini.Y, ini.Z);
            GL.End();
        }

        static public void drawCube(Punto ini, float alto, float largo, float ancho)
        {
            Punto copia = ini;
            Basicos.drawSquare(ini,alto,largo);
            copia.Z = ancho;
            Basicos.drawSquare(copia, alto, largo);
        }

        static public void drawRectangle3D(Punto ini, float alto, float largo, float profundidad)
        {

            PrimitiveType tipo = PrimitiveType.LineLoop;


            // Cara frontal
            GL.Begin(tipo);
            GL.Vertex3(ini.X, ini.Y, ini.Z);
            GL.Vertex3(ini.X + largo, ini.Y, ini.Z);
            GL.Vertex3(ini.X + largo, ini.Y + alto, ini.Z);
            GL.Vertex3(ini.X, ini.Y + alto, ini.Z);
            GL.End();

            // Cara trasera
            GL.Begin(tipo);

            GL.Vertex3(ini.X, ini.Y, ini.Z + profundidad);
            GL.Vertex3(ini.X + largo, ini.Y, ini.Z + profundidad);
            GL.Vertex3(ini.X + largo, ini.Y + alto, ini.Z + profundidad);
            GL.Vertex3(ini.X, ini.Y + alto, ini.Z + profundidad);
            GL.End();

            // Cara izquierda
            GL.Begin(tipo);

            GL.Vertex3(ini.X, ini.Y, ini.Z);
            GL.Vertex3(ini.X, ini.Y, ini.Z + profundidad);
            GL.Vertex3(ini.X, ini.Y + alto, ini.Z + profundidad);
            GL.Vertex3(ini.X, ini.Y + alto, ini.Z);
            GL.End();

            // Cara derecha
            GL.Begin(tipo);

            GL.Vertex3(ini.X + largo, ini.Y, ini.Z);
            GL.Vertex3(ini.X + largo, ini.Y, ini.Z + profundidad);
            GL.Vertex3(ini.X + largo, ini.Y + alto, ini.Z + profundidad);
            GL.Vertex3(ini.X + largo, ini.Y + alto, ini.Z);
            GL.End();

            // Cara superior
            GL.Begin(tipo);

            GL.Vertex3(ini.X, ini.Y + alto, ini.Z);
            GL.Vertex3(ini.X + largo, ini.Y + alto, ini.Z);
            GL.Vertex3(ini.X + largo, ini.Y + alto, ini.Z + profundidad);
            GL.Vertex3(ini.X, ini.Y + alto, ini.Z + profundidad);
            GL.End();

            // Cara inferior
            GL.Begin(tipo);

            GL.Vertex3(ini.X, ini.Y, ini.Z);
            GL.Vertex3(ini.X + largo, ini.Y, ini.Z);
            GL.Vertex3(ini.X + largo, ini.Y, ini.Z + profundidad);
            GL.Vertex3(ini.X, ini.Y, ini.Z + profundidad);

            GL.End();
        }
    }
}
