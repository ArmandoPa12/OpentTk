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


namespace ConsoleApp1
{
    public class Game : GameWindow
    {
        double a = 0.5;
        private float _angleX;
        private float _angleY;
        private float _rotationSpeed = 1.0f;
        private int _vertexArrayObject;
        private int _vertexBufferObject;
        private int _elementBufferObject;
        private int _shaderProgram;

        private Stopwatch stopwatch;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) 
        {
            stopwatch = new Stopwatch();
        }

        private readonly string _vertexShaderSource = @"
        #version 400
        in vec3 position;
        in vec3 color;
        out vec3 fragColor;
        uniform mat4 model;
        uniform mat4 view;
        uniform mat4 projection;
        void main()
        {
            gl_Position = projection * view * model * vec4(position, 1.0);
            fragColor = color;
        }";

        private readonly string _fragmentShaderSource = @"
        #version 400
        in vec3 fragColor;
        out vec4 color;
        void main()
        {
            color = vec4(fragColor, 1.0);
        }";


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            if (input.IsKeyDown(Key.S))
                _angleX += _rotationSpeed * (float)e.Time;
            if (input.IsKeyDown(Key.W))
                _angleX -= _rotationSpeed * (float)e.Time;
            if (input.IsKeyDown(Key.A))
                _angleY -= _rotationSpeed * (float)e.Time;
            if (input.IsKeyDown(Key.D))
                _angleY += _rotationSpeed * (float)e.Time;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, _vertexShaderSource);
            GL.CompileShader(vertexShader);

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, _fragmentShaderSource);
            GL.CompileShader(fragmentShader);

            // Crear programa de shader y linkear shaders
            _shaderProgram = GL.CreateProgram();
            GL.AttachShader(_shaderProgram, vertexShader);
            GL.AttachShader(_shaderProgram, fragmentShader);
            GL.LinkProgram(_shaderProgram);
            GL.DetachShader(_shaderProgram, vertexShader);
            GL.DetachShader(_shaderProgram, fragmentShader);

            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
            GL.ClearColor(0.1f, 0.3f, 0.2f, 1.0f);


            stopwatch.Start();

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            float time  = (float)stopwatch.ElapsedMilliseconds;
            float angulo = time  * MathHelper.DegreesToRadians(45.0f);

            //Console.WriteLine(angulo);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_shaderProgram);
            GL.BindVertexArray(_vertexArrayObject);

            // Matrices de transformación
            Matrix4 modelMatrix = Matrix4.CreateRotationX(_angleX) * Matrix4.CreateRotationY(_angleY);
            Matrix4 viewMatrix = Matrix4.CreateTranslation(0.0f, 0.0f, -5.0f);
            Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), (float)Size.Width / Size.Height, 0.1f, 100.0f);

            int modelLocation = GL.GetUniformLocation(_shaderProgram, "model");
            int viewLocation = GL.GetUniformLocation(_shaderProgram, "view");
            int projectionLocation = GL.GetUniformLocation(_shaderProgram, "projection");
            int colorLocation = GL.GetUniformLocation(_shaderProgram, "fragColor");

            GL.UniformMatrix4(modelLocation, false, ref modelMatrix);
            GL.UniformMatrix4(viewLocation, false, ref viewMatrix);
            GL.UniformMatrix4(projectionLocation, false, ref projectionMatrix);


            //GL.Color3(1.0f, 0.0f, 0.0f);
            //GL.Uniform3(colorLocation, 1.0f, 0.0f, 0.0f);
            //GL.Clear(ClearBufferMask.ColorBufferBit);

            //GL.Begin(PrimitiveType.LineLoop);


            //GL.Vertex3(-0.5, -0.5, 0);
            //GL.Vertex3(0.5, -0.5, 0);
            //GL.Vertex3(0.0, 0.5, 0);

            //GL.Vertex3(-0.5, -0.5, 0.1);
            //GL.Vertex3(0.5, -0.5, 0.1);
            //GL.Vertex3(0.0, 0.5, 0.1);

            //a += 0.000;


            //GL.End();



            //Punto x = new Punto(0.0f, 0.0f, 0.0f);
            //Punto y = new Punto(0.5f, 0.0f, 0.0f);
            //Punto z = new Punto(0.25f, 0.5f, 0.0f);

            //Punto x1 = new Punto(0.0f, 0.0f, -0.2f);
            //Punto y1 = new Punto(0.5f, 0.0f, -0.2f);
            //Punto z1 = new Punto(0.25f, 0.5f, -0.2f);

            //Basicos.drawLine(x, y);
            //Basicos.drawLine(y, z);
            //Basicos.drawLine(z, x);

            //Basicos.drawLine(x1, y1);
            //Basicos.drawLine(y1, z1);
            //Basicos.drawLine(z1, x1);


            //Punto ini = new Punto();
            //Punto ini2 = new Punto(0.0f,0.0f,0.1f);

            //Basicos.drawTriangle(ini,0.5f,0.5f);
            //Basicos.drawTriangle(ini2, 0.5f, 0.5f
            //

            PrimitiveType tipo = PrimitiveType.LineLoop;

            //T
            //ADELANTE
            GL.Begin(tipo);
            GL.Vertex3(-0.1, -0.3, 0.1);
            GL.Vertex3(0.1, -0.3, 0.1);
            GL.Vertex3(0.1, 0.2, 0.1);
            GL.Vertex3(0.3, 0.2, 0.1);
            GL.Vertex3(0.3, 0.4, 0.1);
            GL.Vertex3(-0.3, 0.4, 0.1);
            GL.Vertex3(-0.3, 0.2, 0.1);
            GL.Vertex3(-0.1, 0.2, 0.1);
            GL.End();


            ////ATRAS
            //GL.Begin(tipo);
            //GL.Vertex3(-0.1, -0.3, -0.1);
            //GL.Vertex3(0.1, -0.3, -0.1);
            //GL.Vertex3(0.1, 0.2, -0.1);
            //GL.Vertex3(0.3, 0.2, -0.1);
            //GL.Vertex3(0.3, 0.4, -0.1);
            //GL.Vertex3(-0.3, 0.4, -0.1);
            //GL.Vertex3(-0.3, 0.2, -0.1);
            //GL.Vertex3(-0.1, 0.2, -0.1);
            //GL.End();


            ////LADOS
            //GL.Begin(tipo);
            //GL.Vertex3(-0.1, -0.3, 0.1);
            //GL.Vertex3(-0.1, -0.3, -0.1);
            //GL.End();

            //GL.Begin(tipo);
            //GL.Vertex3(0.1, -0.3, 0.1);
            //GL.Vertex3(0.1, -0.3, -0.1);
            //GL.End();

            //GL.Begin(tipo);
            //GL.Vertex3(0.1, 0.2, 0.1);
            //GL.Vertex3(0.1, 0.2, -0.1);
            //GL.End();

            //GL.Begin(tipo);
            //GL.Vertex3(0.3, 0.2, 0.1);
            //GL.Vertex3(0.3, 0.2, -0.1);
            //GL.End();

            //GL.Begin(tipo);
            //GL.Vertex3(0.3, 0.4, 0.1);
            //GL.Vertex3(0.3, 0.4, -0.1);
            //GL.End();

            //GL.Begin(tipo);
            //GL.Vertex3(-0.3, 0.4, 0.1);
            //GL.Vertex3(-0.3, 0.4, -0.1);
            //GL.End();

            //GL.Begin(tipo);
            //GL.Vertex3(-0.3, 0.2, 0.1);
            //GL.Vertex3(-0.3, 0.2, -0.1);
            //GL.End();

            //GL.Begin(tipo);
            //GL.Vertex3(-0.1, 0.2, 0.1);
            //GL.Vertex3(-0.1, 0.2, -0.1);
            //GL.End();

            //Punto ini = new Punto(0.0f,0.0f,0.0f);
            //Basicos.drawRectangle3D(ini,0.03f,0.05f,0.01f);


            //Basicos.drawCube(ini, 0.3f, 0.5f, 0.15f);


            Context.SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
        }
    }

}
