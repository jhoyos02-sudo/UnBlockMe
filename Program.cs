using System;
using System.IO;
using System.Numerics;
namespace ConsoleApp1
{
    internal class Program
    {
        // coordenadas (x,y) para representar posiciones y direcciones de desplazamiento
        struct Coor
        {
            public int x, y;
        }
        struct Estado
        { // estado del juego

            public char[,] mat;
            // ’#’ muro; ’.’ libre; letras ’a’,’b’ ... bloques

            public char obj;
            // char correspondiente al bloque objetivo (el que hay que sacar)

            public Coor act, sal; // posiciones del cursor y de la salida
            public bool sel;
            // idica si hay bloque seleccionado para mover o no
        }

        static void Main(string[] args)
        {

        }

        static Estado LeeNivel(string file, int n)
        {
            Estado juego = new Estado();
            StreamReader entrada = new StreamReader(file);

            string cadena = "";

            //Falta saltar una linea aqui (la de nivel x)
            juego.obj = char.Parse(entrada.ReadLine());

            while (!String.IsNullOrWhiteSpace(entrada.ReadLine()))
            {
                cadena += entrada.ReadLine();
                cadena += "$";
            }

            entrada.Close();
            return juego;
        }

        static void Render(Estado est)
        {

        }

        // ’a’->1, ’b’->2... descartar el 0=negro
        static int BloqueToInt(char c)
        {
            return ((int)c) - ((int)'a') + 1;
        }

        static void MarcaSalida(Estado est)
        {
            int i = 0, j = 0, coordx, coordy, dirx = 0, diry = 0;
            char objetivo = est.obj;
            bool ok = false;

            while (i < est.mat.GetLength(0))
            {
                while (j < est.mat.GetLength(1))
                {
                    if (est.mat[i,j] == objetivo)
                    {
                        coordx = i;
                        coordy = j;

                        LocalizaDir(i, j, ref dirx, ref diry);

                        ok = true;
                    }
                    j++;
                }
                i++;
            }
        }

        static void LocalizaDir(int x, int y, ref int dirx, ref int diry)
        {

        }

        static void MueveCursor(Estado est, Coor dir)
        {
            if (!est.sel)
            {
                Coor nuevaPos = new Coor();
                nuevaPos = SumaCoor(est.act, dir);

                if (est.mat[nuevaPos.x, nuevaPos.y] != '#' && !ComparaCoor(nuevaPos, est.sal))
                {
                    est.act = nuevaPos;
                }
            }
        }

        static void MueveBloque(Estado est, Coor dir)
        {

        }

        static void BuscaCabeza()
        {

        }

        static void ProcesaInput(Estado est, char c)
        {

        }

        static char LeeInput()
        {
            char d = ' ';
            while (d == ' ')
            {
                if (Console.KeyAvailable)
                {
                    string tecla = Console.ReadKey().Key.ToString();
                    switch (tecla)
                    {
                        case "LeftArrow": d = 'l'; break; // direccones
                        case "UpArrow":
                            d = 'u'; break;
                        case "RightArrow": d = 'r'; break;
                        case "DownArrow": d = 'd'; break;
                        case "Delete":
                            d = 'z'; break; // deshacer jugada
                        case "Escape":
                            d = 'q'; break; // salir
                        case "Spacebar": d = 's'; break; // selección de bloque
                    }
                }
            }
            return d;
        }

        static bool ComparaCoor(Coor x, Coor y)
        {
            return x.x == y.x && x.y == y.y;
        }

        static Coor SumaCoor(Coor x, Coor y)
        {
            Coor nCoor = new Coor();
            nCoor.x = x.x + y.x;
            nCoor.y = x.y + y.y;
            return nCoor;
        }
    }
}

