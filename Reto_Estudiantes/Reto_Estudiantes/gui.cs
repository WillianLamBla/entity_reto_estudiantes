using System;
using System.Collections.Generic;
using System.Text;

namespace Reto_Estudiantes
{
    class gui
    {
        public static void Marco(int Xmin, int Xmax, int Ymin, int Ymax)
        {
            for (int x = Xmin; x <= Xmax; x++)
            {
                Console.SetCursorPosition(x, Ymin); Console.Write("▓");
                Console.SetCursorPosition(x, Ymax); Console.Write("▓");
            }

            for (int y = Ymin; y <= Ymax; y++)
            {
                Console.SetCursorPosition(Xmin, y); Console.Write("▓▓");
                Console.SetCursorPosition(Xmax, y); Console.Write("▓▓");
            }

            Console.SetCursorPosition(Xmin, Ymin); Console.Write("▓");
            Console.SetCursorPosition(Xmax, Ymin); Console.Write("▓");
            Console.SetCursorPosition(Xmin, Ymax); Console.Write("▓");
            Console.SetCursorPosition(Xmax, Ymax); Console.Write("▓");

        }

        public static void Linea(int Xmin, int Xmax, int y)
        {
            for (int x = Xmin; x <= Xmax; x++)
            {
                Console.SetCursorPosition(x, y); Console.Write("-");

            }



        }

        public static void BorrarLinea(int Xmin, int y, int Xmax)
        {
            for (int x = Xmin; x <= Xmax; x++)
            {
                Console.SetCursorPosition(x, y); Console.Write(" ");
            }
        }
    }
}

