using PROYECTO_JUEGO;
using System.Drawing;


Ventana  ventana;
Serpiente serpiente;
Comida comida;
bool jugar = false;
bool ejec = true;
void inicio()
{
    Ventana ventana = new Ventana("Serpiente", 65, 20, ConsoleColor.Black, ConsoleColor.Green, new Point(5, 3), new Point(59, 18));
    ventana.DibujarMarco();
    comida = new Comida(ConsoleColor.Red, ventana);
    serpiente = new Serpiente(new Point(8, 5), ConsoleColor.Green, ConsoleColor.Red, ventana, comida);
}
void Game() 
{ 
    while (ejec)
    {
        ventana.Menu();
        ventana.Teclado(ref ejec, ref jugar, serpiente);
        while (jugar)
        {
            serpiente.Info(0, 34);
            serpiente.Mover();
            if (!serpiente.Viva)
            {
                jugar = false;
                serpiente.Score = 0;
            }
            Thread.Sleep(100);
        }
        Thread.Sleep(100);
    }
    



inicio();
Game();

}

