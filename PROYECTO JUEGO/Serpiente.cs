using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PROYECTO_JUEGO
{
    internal class Serpiente
    {
        enum Direccion
        {
            Arriba, Abajo, Derecha, Izquierda
        }
        public bool Viva { get; set; }
        public ConsoleColor ColorHead { get; set; }
        public ConsoleColor ColorBody { get; set; }
        public Ventana VentanaC { get; set; }
        public List<Point> Body { get; set; }
        public Point Head { get; set; }
        public Comida ComidaC { get; set; }
        public int Score { get; set; }
        public int ScoreMax { get; set; }
        public Point PosicioInicial { get; set; }

        private Direccion _direccion;
        private bool _comiendo;

        public Serpiente(Point posicion, ConsoleColor colorhead, ConsoleColor colorbody, Ventana ventana, Comida comida)
        {
            ColorHead = colorhead;
            ColorBody = colorbody;
            VentanaC = ventana;
            Head = posicion;
            ComidaC = comida;
            Score = 0;
            ScoreMax = 0;
            PosicioInicial = posicion;
            Body = new List<Point>();

            _direccion = Direccion.Derecha;

        }

        public void Int()
        {
            Body.Clear();
            Head = PosicioInicial;
            IniCuerpo(2);
            Viva = true;
            _direccion = Direccion.Derecha;
            ComidaC.GeneComida(this);
        }
        public void IniCuerpo(int nuparts)
        {
            int x = Head.X - 1;
            for (int i = 0; i < nuparts; i++)
            {
                Console.SetCursorPosition(x, Head.Y);
                Console.Write("▓");
                Body.Add(new Point(x, Head.Y));
                x--;
            }
        }
        public void Mover()
        {
            Teclado();
            Point posHeadanter = Head;
            MoverHead();
            MoveBody(posHeadanter);
            ColiComida();
            if (ColisBody())
            {
                Dead();
                VentanaC.GameOV("G A M E O V E R :(");
            }


        }
        public void MoverHead()
        {
            Console.ForegroundColor = ColorHead;
            Console.SetCursorPosition(Head.X, Head.Y);
            Console.Write(" ");
            switch (_direccion)
            {
                case Direccion.Derecha:
                    Head = new Point(Head.X + 1, Head.Y);
                    break;
                case Direccion.Izquierda:
                    Head = new Point(Head.X - 1, Head.Y);
                    break;
                case Direccion.Abajo:
                    Head = new Point(Head.X, Head.Y + 1);
                    break;
                case Direccion.Arriba:
                    Head = new Point(Head.X, Head.Y - 1);
                    break;
            }
            coliMarco();
            Console.SetCursorPosition(Head.X, Head.Y);
            Console.Write("█");

        }
        private void MoveBody(Point posHeadanter)
        {
            Console.ForegroundColor = ColorBody;
            Console.SetCursorPosition(posHeadanter.X, posHeadanter.Y);
            Console.Write("▓");
            Body.Insert(0, posHeadanter);

            if (_comiendo)
            {
                _comiendo = false;
                return;
            }

            Console.SetCursorPosition(Body[Body.Count - 1].X, Body[Body.Count - 1].Y);
            Console.Write(" ");
            Body.Remove(Body[Body.Count - 1]);
        }
        private void ColiComida()
        {
            if (Head == ComidaC.Posicion)
            {
                if (!ComidaC.GeneComida(this))
                {
                    Viva = false;
                    VentanaC.GameOV("COMPLETADO :D");
                }

                _comiendo = true;
                Score++;
                if (Score > ScoreMax)
                    ScoreMax = Score;
            }
        }
        private void Teclado()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.RightArrow && (_direccion != Direccion.Izquierda))
                    _direccion = Direccion.Derecha;
                if (tecla.Key == ConsoleKey.LeftArrow && (_direccion != Direccion.Derecha))
                    _direccion = Direccion.Izquierda;
                if (tecla.Key == ConsoleKey.UpArrow && (_direccion != Direccion.Abajo))
                    _direccion = Direccion.Arriba;
                if (tecla.Key == ConsoleKey.DownArrow && (_direccion != Direccion.Arriba))
                    _direccion = Direccion.Abajo;
            }
        }
        private void coliMarco()
        {
            if (Head.X <= VentanaC.LimiteSuperior.X)
                Head = new Point(VentanaC.LimiteInferior.X - 1, Head.Y);
            if (Head.X >= VentanaC.LimiteInferior.X)
                Head = new Point(VentanaC.LimiteSuperior.X + 1, Head.Y);
            if (Head.Y <= VentanaC.LimiteSuperior.Y)
                Head = new Point(Head.X, VentanaC.LimiteInferior.Y - 1);
            if (Head.Y >= VentanaC.LimiteInferior.Y)
                Head = new Point(Head.X, VentanaC.LimiteSuperior.Y + 1);
        } 
        private bool ColisBody()
        {
            foreach(Point item in Body)
            {
                Viva = false;
                return true;
            }
            return false;

        }  
        public void Dead()
        {
            Console.ForegroundColor = ColorBody;
            foreach(Point item in Body)
            {
                if (item == Head)
                    continue;
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("░");
                Thread.Sleep(120);
            }
        }
    public void Info(int distanciaX1, int distanciaX2)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(VentanaC.LimiteSuperior.X + distanciaX1, VentanaC.LimiteSuperior.Y-1);
            Console.Write("Score:" + Score + "  ");
            Console.SetCursorPosition(VentanaC.LimiteSuperior.X + distanciaX2, VentanaC.LimiteSuperior.Y - 1);
            Console.Write("ScoreMax: " + ScoreMax + "  ");
        
        }
        public void MovMenu()
        {
            _direccion = Direccion.Derecha;
            Point posHeadanter = Head;
            MoverHead();
            MoveBody(posHeadanter);
    }
    
}
}
