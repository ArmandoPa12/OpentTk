using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Data;
using System.Runtime.CompilerServices;

namespace ConsoleApp1.main
{
    class Basicos
    {
        private float ejeX;
        private float ejeY;
        private float ejeZ;
        static public void drawLine(Punto a, Punto b)
        {
            //GL.Color3(1.0f, 1.0f, 1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(a.X, a.Y, a.Z);
            GL.Vertex3(b.X, b.Y, b.Z);
            GL.End();
        }
        static public void drawPunto(Punto a)
        {
            //GL.Color3(1.0f, 1.0f, 1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(Color.Fuchsia);
            GL.Vertex3(a.X, a.Y, a.Z);
            GL.End();
        }

        static public void drawTriangle(Punto ini,float ancho,float alto,Color color,float thick = 1f) 
        {
            GL.PushMatrix();
            //GL.Translate(0.0f, 0.0f, 0.0f);

            GL.LineWidth(thick);    
            GL.Color4(color);

            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(ini.X, ini.Y,ini.Z);
            GL.Vertex3(ancho,ini.Y,ini.Z);
            GL.Vertex3(ancho/2, alto, ini.Z);
            GL.End();
            GL.PopMatrix();

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

        static public void drawRectangleRelative(Punto ini, Color color, float alto = 0.2f, float largo = 0.3f, float profundidad = 0.3f)
        {
            PrimitiveType tipo = PrimitiveType.LineLoop;

            GL.Color4(color);
            //GL.Translate(0.001f, 0.0f, 0.0f);
            GL.Rotate(0.1f, 0.0f, 0.1f, 0.1f);

            GL.PushMatrix();

            // Cara frontal
            GL.Begin(tipo);
            GL.Vertex3(ini.X - (largo / 2), ini.Y - (alto / 2), ini.Z + (profundidad / 2));
            GL.Vertex3(ini.X + (largo / 2), ini.Y - (alto / 2), ini.Z + (profundidad / 2));
            GL.Vertex3(ini.X + (largo / 2), ini.Y + (alto / 2), ini.Z + (profundidad / 2));
            GL.Vertex3(ini.X - (largo / 2), ini.Y + (alto / 2), ini.Z + (profundidad / 2));
            GL.End();

            GL.Begin(tipo);
            GL.Vertex3(ini.X - (largo / 2), ini.Y - (alto / 2), ini.Z + (profundidad / 2));
            GL.Vertex3(ini.X + (largo / 2), ini.Y - (alto / 2), ini.Z + (profundidad / 2));
            GL.Vertex3(ini.X + (largo / 2), ini.Y + (alto / 2), ini.Z + (profundidad / 2));
            GL.Vertex3(ini.X - (largo / 2), ini.Y + (alto / 2), ini.Z + (profundidad / 2));
            GL.End();




            GL.PopMatrix();

        }
        static public void planos(float escala = 0.1f)
        {
            PrimitiveType tipo = PrimitiveType.LineLoop;
            float width = 0.02f;

            GL.Begin(tipo);
            GL.Color4(Color.Red);
            GL.Vertex3(4f,0f,0);
            GL.Vertex3(-4f, 0f, 0);
            GL.End();

            for (float i = -4f; i <= 4f; i += escala)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color4(Color.Red);
                GL.Vertex3(i, -width, 0);  
                GL.Vertex3(i, width, 0);   
                GL.End();
            }


            GL.Begin(tipo);
            GL.Color4(Color.Green);
            GL.Vertex3(0f, 4f, 0);
            GL.Vertex3(0f, -4f, 0);
            GL.End();
            for (float i = -4f; i <= 4f; i += escala)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color4(Color.Green);
                GL.Vertex3(-width, i, 0);
                GL.Vertex3(width, i, 0);
                GL.End();
            }


            GL.Begin(tipo);
            GL.Color4(Color.Blue);
            GL.Vertex3(0f, 0f, 4f);
            GL.Vertex3(0f, 0f, -4f);
            GL.End();
            for (float i = -4f; i <= 4f; i += escala)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color4(Color.Blue);
                GL.Vertex3(0, i, -width);
                GL.Vertex3(0, i, width);
                GL.End();
            }
        }

        /// ------------------
        public static void drawRectanguloEje(Punto i,Color color, int eje,PrimitiveType tipo = PrimitiveType.LineLoop, float ancho = 0.4f, float largo = 0.2f)
        {
            //PrimitiveType tipo = PrimitiveType.LineLoop;
            GL.Color4(color);
            GL.Rotate(0.10f, 0.0f, 0.1f, 0.1f);
            GL.PushMatrix();

            GL.Begin(tipo);
            // eje X
            if (eje == 0) 
            {
                GL.Vertex3(i.X - ancho / 2, i.Y - largo / 2, i.Z);          
                GL.Vertex3(i.X + ancho / 2, i.Y - largo / 2, i.Z);          
                GL.Vertex3(i.X + ancho / 2, i.Y + largo / 2, i.Z);           
                GL.Vertex3(i.X - ancho / 2, i.Y + largo / 2, i.Z);
            }
            //  eje Y
            if (eje == 1)
            {
                GL.Vertex3(i.X - ancho / 2, i.Y, i.Z - largo / 2);           
                GL.Vertex3(i.X + ancho / 2, i.Y, i.Z - largo / 2);           
                GL.Vertex3(i.X + ancho / 2, i.Y, i.Z + largo / 2);           
                GL.Vertex3(i.X - ancho / 2, i.Y, i.Z + largo / 2);
            }
            //eje Z
            if (eje == 2)
            {
                GL.Vertex3(i.X, i.Y - largo / 2, i.Z - ancho / 2);          
                GL.Vertex3(i.X, i.Y + largo / 2, i.Z - ancho / 2);           
                GL.Vertex3(i.X, i.Y + largo / 2, i.Z + ancho / 2);          
                GL.Vertex3(i.X, i.Y - largo / 2, i.Z + ancho / 2);
            }
            GL.End();
            GL.PopMatrix();


        }
        public static void drawCuboEje(Punto i, Color color,PrimitiveType tipo = PrimitiveType.LineLoop, float alto = 0.2f, float largo = 0.3f, float profundidad = 0.3f) 
        {
            //PrimitiveType tipo = PrimitiveType.Quads;
            GL.PushMatrix();
            GL.Rotate(0.0f, 0.0f, 0.0f,0.1f);
            Basicos.drawRectanguloEje(new Punto(i.X, i.Y, i.Z + (profundidad / 2)), color, 0, tipo, largo, alto);
            Basicos.drawRectanguloEje(new Punto(i.X, i.Y, i.Z - (profundidad / 2)), color, 0, tipo, largo, alto);

            Basicos.drawRectanguloEje(new Punto(i.X, i.Y + (alto / 2) , i.Z), color, 1, tipo, largo, profundidad);
            Basicos.drawRectanguloEje(new Punto(i.X, i.Y - (alto / 2), i.Z), color, 1, tipo, largo, profundidad);

            Basicos.drawRectanguloEje(new Punto(i.X - (largo/2), i.Y, i.Z), color, 2, tipo, profundidad, alto );
            Basicos.drawRectanguloEje(new Punto(i.X + (largo / 2), i.Y, i.Z), color, 2, tipo, profundidad, alto);


        }


        static public void DrawRect(Punto a, Punto c, int eje, Color color)
        {
            GL.Begin(PrimitiveType.Quads);
            float dx = Math.Abs(c.X - a.X);
            float dy = Math.Abs(c.Y - a.Y);
            float dz = Math.Abs(c.Z - a.Z);
            GL.Color3(color);
            if (eje == 0)   //Eje X
            {
                GL.Vertex3(a.X, a.Z, a.Y);
                GL.Vertex3(a.X, a.Z, a.Y + dy);
                GL.Vertex3(a.X, a.Z + dz, a.Y + dy);
                GL.Vertex3(a.X, a.Z + dz, a.Y);
            }
            else if (eje == 1)  //Eje Y
            {
                GL.Vertex3(a.X, a.Z, a.Y);
                GL.Vertex3(a.X + dx, a.Z, a.Y);
                GL.Vertex3(a.X + dx, a.Z + dz, a.Y);
                GL.Vertex3(a.X, a.Z + dz, a.Y);
            }
            else if (eje == 2)  //Eje Z
            {
                GL.Vertex3(a.X, a.Z, a.Y);
                GL.Vertex3(a.X, a.Z, a.Y + dy);
                GL.Vertex3(a.X + dx, a.Z, a.Y + dy);
                GL.Vertex3(a.X + dx, a.Z, a.Y);
            }
            GL.End();
        }
        static public void DrawRect(float ax, float ay, float az, float cx, float cy, float cz, int eje, Color color)
        {
            Basicos.DrawRect(new Punto(ax, ay, az), new Punto(cx, cy, cz), eje, color);
        }

        static public void DrawCuboide(Punto P, Punto Q, Color color)
        {
            float dx = Math.Abs(Q.X - P.X);
            float dy = Math.Abs(Q.Y - P.Y);
            float dz = Math.Abs(Q.Z - P.Z);
            //Lado L
            Basicos.DrawRect(P.X, P.Y, P.Z, P.X, P.Y + dy, P.Z + dz, 0, color);//0xff4500
            //Lado R
            Basicos.DrawRect(P.X + dx, P.Y, P.Z, P.X + dx, P.Y + dy, P.Z + dz, 0, color);//0xff0000
            //Lado B
            Basicos.DrawRect(P.X, P.Y, P.Z, P.X + dx, P.Y, P.Z + dz, 1, color);//0xff
            //Lado F
            Basicos.DrawRect(P.X, P.Y + dy, P.Z, P.X + dx, P.Y + dy, P.Z + dz, 1, color);//0xff00
            //Lado U
            Basicos.DrawRect(P.X, P.Y, P.Z + dz, P.X + dx, P.Y + dy, P.Z + dz, 2, color);//0
            //Lado D
            Basicos.DrawRect(P.X, P.Y, P.Z, P.X + dx, P.Y + dy, P.Z, 2, color);//0xffff00
        }

    }
}
