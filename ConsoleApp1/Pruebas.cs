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
using System.Diagnostics.Contracts;


namespace ConsoleApp1
{
    public class Pruebas : GameWindow
    {
        private float angulox;
        private float anguloy;
        private float Rotar = 1.0f;

        private Vertices vertices;

        private Stopwatch stopwatch;

        public Pruebas(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            vertices = new Vertices();
        }



        protected override void OnUpdateFrame(FrameEventArgs e)
        {
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

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.Black);

            vertices.AgregarPunto("inicio", new Punto(-0.2f, 0.0f, 0.0f));
            vertices.AgregarPunto("punta", new Punto(0.0f, 0.3f, 0.0f));
            vertices.AgregarPunto("fin", new Punto(0.2f, 0.0f, 0.0f));


            GL.Enable(EnableCap.DepthTest);

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            
            vertices.Aplicar();



            Context.SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
        }
    }
}
