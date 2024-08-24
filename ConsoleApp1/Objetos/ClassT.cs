using ConsoleApp1.main;
using OpenTK.Graphics;
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

namespace ConsoleApp1.Objetos
{
    public class ClassT
    {
        private Punto ini;
        private float alto, largo, ancho;
        float centroX, centroY, centroZ;
        private Color color;
        private PrimitiveType tipo;
        public ClassT() 
        {
            this.alto = 0.6f;
            this.largo = 0.5f;
            this.ancho = 0.2f;
            this.centroX = Math.Abs(this.alto / 2);
            this.centroY = Math.Abs(this.largo / 2);
            this.centroZ = Math.Abs(this.ancho / 2);
            this.ini = new Punto();
            this.color = Color.Red;
            this.tipo = PrimitiveType.LineLoop;
        }
        public ClassT(Punto centro,Color color, PrimitiveType tipo=PrimitiveType.LineLoop, float alto=0.6f, float largo=0.5f, float ancho=0.2f)
        {
            this.alto = alto;
            this.largo = largo;
            this.ancho = ancho;
            this.tipo = tipo;
            this.centroX = Math.Abs(this.alto / 2);
            this.centroY = Math.Abs(this.largo / 2);
            this.centroZ = Math.Abs(this.ancho / 2);
            this.ini = centro;
            this.color = color;
        }

        

        public void draw()
        {
            Punto centro = new Punto(ini.X+centroX,ini.Y+centroY,ini.Z+centroZ);
            Basicos.drawCuboEje(new Punto(ini.X, ini.Y, ini.Z), color, tipo, alto - 0.2f, largo - 0.3f, ancho);
            Basicos.drawCuboEje(new Punto(ini.X,ini.Y+(alto/2),ini.Z), color, tipo, alto - 0.4f,largo, ancho);


            //Basicos.drawCuboEje(new Punto(ini.X, ini.Y, ini.Z), Color.Aqua, PrimitiveType.LineLoop,0.4f, 0.2f, 0.2f);
            //Basicos.drawCuboEje(new Punto(ini.X,ini.Y+0.3f,ini.Z), Color.Aqua, PrimitiveType.LineLoop, 0.2f, 0.5f, 0.2f);

            //Basicos.drawCuboEje(centro,Color.Red,alto,largo,ancho);
        }

    }
}
