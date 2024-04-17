using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace PROYECTO_JUEGO
{
    internal class Ventana
    {
        public string Titulo { get; set; }
        public int Ancho { get; set; }
        public int Altura { get; set; }

        public ConsoleColor ColorFondo { get; set; }
        public ConsoleColor ColorLetra { get; set; }
        public Point LimiteSuperior { get; set; }
        public Point LimiteInferior { get; set; }
        public int Area { get; set; }
        public Serpiente SerpienteC { get; set; }
        public Ventana(string titulo, int ancho, int altura, ConsoleColor colorFondo, ConsoleColor colorLetra, Point limiteSuperior, Point limiteInferior)
        {
            Titulo = titulo;
            Ancho = ancho;
            Altura = altura;
            ColorFondo = colorFondo;
            ColorLetra = colorLetra;
            LimiteSuperior = limiteSuperior;
            LimiteInferior = limiteInferior;
            Area = ((LimiteInferior.X - LimiteSuperior.X) - 1 * ((LimiteInferior.Y - LimiteSuperior.Y) - 1));
            Init();
        }
        public void Init()
        {
            Console.SetWindowSize(Ancho, Altura);
            Console.Title = Titulo;
            Console.CursorVisible = false;
            Console.BackgroundColor = ColorFondo;
            Console.Clear();
            SerpienteC = new Serpiente(new Point(LimiteInferior.X / 2, LimiteInferior.Y - 3), ConsoleColor.Magenta, ConsoleColor.White,this,null);
            SerpienteC.IniCuerpo(4);
        }
        public void DibujarMarco()
        {
            Console.ForegroundColor = ColorLetra;
            for (int i = LimiteSuperior.X; i < LimiteInferior.X; i++)
            {
                Console.SetCursorPosition(i, LimiteSuperior.Y);
                Console.Write("=");
                Console.SetCursorPosition(i, LimiteInferior.Y);
                Console.Write("=");
            }
            for ( int i = LimiteSuperior.Y; i < LimiteInferior.Y; i++)
            {
                Console.SetCursorPosition(LimiteSuperior.X, i);
                Console.Write("||");
                Console.SetCursorPosition(LimiteInferior.X, i);
                Console.Write("||");


            }
            Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y);
            Console.Write("╔");
            Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y);
            Console.Write("╚");
            Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y);
            Console.Write("╗");
            Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y);
            Console.Write("╝");
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2)-12, LimiteSuperior.Y + (LimiteInferior.Y / 2)-4);
            Console.Write("J U E G O  S E R P I E N T E  SSSSSS");
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 8, LimiteSuperior.Y + (LimiteInferior.Y / 2) - 2);
            Console.Write("ENTER -- JUGAR");
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 12, LimiteSuperior.Y + (LimiteInferior.Y / 2) - 1);
            Console.Write("ESC -- SALIR ");
            SerpienteC.MovMenu();

        }
        public void Teclado(ref bool ejec,ref bool jugar, Serpiente serpiente)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Enter)
                {
                    jugar = true;
                    Console.Clear();
                    DibujarMarco();
                    serpiente.Int();
                }
                if(tecla.Key == ConsoleKey.Escape)
                {
                    ejec = false;
                }
            }
        }
        public void GameOV(string text)
        {
            Console.Clear();
            DibujarMarco();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 10, LimiteSuperior.Y + (LimiteInferior.Y / 2) - 2);
            Console.Write(text);
            Thread.Sleep(3000);
            Console.Clear();
            DibujarMarco();
        }
    }
}









