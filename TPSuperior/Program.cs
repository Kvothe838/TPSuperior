using System;
using System.Collections.Generic;
using System.Linq;
using TPSuperior.Domain;

namespace TPSuperior
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pedir datos de puntos a interpolar
            List<Punto> puntos = new List<Punto>();

            Console.WriteLine("1. Ingresar nuevo punto");
            Console.WriteLine("2. Evaluar polinomio interpolado en un punto");
            string opcionSeleccionada = Console.ReadLine();

            while (opcionSeleccionada == "1")
            {
                Punto punto = new Punto();

                Console.Write("Introduzca x: ");
                double tryX;

                if (!double.TryParse(Console.ReadLine(), out tryX))
                {
                    //input incorrecto
                }

                punto.x = tryX;

                Console.Write("\nIntroduzca y: ");
                double tryY;

                if (!double.TryParse(Console.ReadLine(), out tryY))
                {
                    //input incorrecto
                }

                punto.y = tryY;

                puntos.Add(punto);

                Console.WriteLine("\n1. Ingresar nuevo punto");
                Console.WriteLine("2. Evaluar polinomio interpolado en un punto");
                opcionSeleccionada = Console.ReadLine();
            }

            if (opcionSeleccionada == "2")
            {
                Console.Write("\nIngresar valor a evaluar: ");
                double valorEvaluar;

                if (!double.TryParse(Console.ReadLine(), out valorEvaluar))
                {
                    //input incorrecto
                }

                double resultado = Lagrange(puntos, valorEvaluar);
                Console.WriteLine("Resultado: " + resultado);

            }

            //Console.WriteLine(puntos.Select(punto => "x: " + punto.x + ", y: " + punto.y).Aggregate((unMensaje, otroMensaje) => unMensaje + "\n" + otroMensaje));
            Console.ReadKey();
        }

        static double Lagrange(List<Punto> puntos, double x)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                List<Punto> temp = puntos.Select(punto => (Punto)punto).ToList();
                temp.RemoveAt(i);
                puntos[i].otrosPuntos = temp;
            }

            return puntos.Select(punto => punto.EvaluarPolinomio_Lagrange(x) * punto.y)
                .Aggregate((unValor, otroValor) => unValor + otroValor);
        }
    }
}
