using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.main;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using System.Timers;
using System.Diagnostics;
using ConsoleApp1.Objetos;


namespace ConsoleApp1
{
    public class Game : GameWindow
    {
        private float angulox;
        private float anguloy;
        private float Rotar = 1.0f;

        private float angle1;
        private float angle2;

        public Game(int width, int height, string title) :base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.White);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            GL.PushMatrix();

            GL.Rotate(angulox, 1.0f, 0.0f, 0.0f);
            GL.Rotate(anguloy, 0.0f, 1.0f, 0.0f);
            Basicos.planos();

            ClassT t = new ClassT(new Punto(-0.2f,0.3f,0.1f),Color.Fuchsia,PrimitiveType.Quads);
            t.draw();
            ClassT t1 = new ClassT();
            t1.draw();  


            GL.PopMatrix();
            Context.SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            angle1 += 10.0f * (float)e.Time; // Rotación en grados por segundo
            angle2 += 20.0f * (float)e.Time;

            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            if (input.IsKeyDown(Key.Up))
            {
                //this.angulox += this.Rotar * (float)e.Time;
                this.angulox += this.Rotar;

            }
            if (input.IsKeyDown(Key.Down))
            {
                //this.angulox -= this.Rotar * (float)e.Time;
                this.angulox -= this.Rotar;
            }
            if (input.IsKeyDown(Key.Left))
            {
                //this.anguloy -= this.Rotar * (float)e.Time;
                this.anguloy -= this.Rotar;
            }
            if (input.IsKeyDown(Key.Right))
            {
                //this.anguloy += this.Rotar * (float)e.Time;
                this.anguloy += this.Rotar;
            }
            //if (input.IsKeyDown(Key.W) || input.IsKeyDown(Key.KeypadPlus))
            //{
            //    plano.Escala += 0.1f; // Aumentar la escala
            //}
            //if (input.IsKeyDown(Key.S) || input.IsKeyDown(Key.KeypadMinus))
            //{
            //    plano.Escala -= 0.1f; // Disminuir la escala
            //}
        }

    }
}


