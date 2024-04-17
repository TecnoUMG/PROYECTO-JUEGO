using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PROYECTO_JUEGO
{
    internal class Comida
    {
        public Point Posicion { get; set; }
        public ConsoleColor Color { get; set; }
        public Ventana VentanaC { get; set; }

        public Comida(ConsoleColor color, Ventana ventana) 
        {
            Color = color;
            VentanaC = ventana;

        }
        private void Dibuj()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Posicion.X, Posicion.Y);
            Console.Write("█");
        }
        public bool GeneComida(Serpiente serpiente)
        {
            int longitSerpiente = serpiente.Body.Count + 1;
            if ((VentanaC.Area - longitSerpiente) <= 0)
                return false;
            Random random = new Random();
            int x = random.Next(VentanaC.LimiteSuperior.X + 1, VentanaC.LimiteInferior.X);
            int y = random.Next(VentanaC.LimiteSuperior.Y + 1, VentanaC.LimiteInferior.Y);
            Posicion = new Point(x, y);
            foreach(Point item in serpiente.Body)
            {
                if ((x==item.X&& y==item.Y)||(x==serpiente.Head.X&& y == serpiente.Head.Y))
                {
                    if (GeneComida(serpiente))
                    
                        return true;
                    

                    
                }
            }
            Dibuj();
            return true;
        }



    }

}
