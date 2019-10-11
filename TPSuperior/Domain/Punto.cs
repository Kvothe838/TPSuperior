using System.Collections.Generic;

namespace TPSuperior.Domain
{
    public class Punto
    {
        public double x { get; set; }

        public double y { get; set; }

        public List<Punto> otrosPuntos { get; set; }
        
        public double EvaluarPolinomio_Lagrange(double x)
        {
            double numerador = 1, denominador = 1;

            foreach (Punto punto in otrosPuntos)
            {
                numerador *= (x - punto.x);
                denominador *= (this.x - punto.x);
            }

            return numerador / denominador;
        }
    }
}
